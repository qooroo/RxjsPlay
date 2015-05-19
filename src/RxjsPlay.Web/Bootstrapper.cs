using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using log4net.Config;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using RxjsPlay.Web.EventStream;
using RxjsPlay.Web.Hubs;

namespace RxjsPlay.Web
{
    public class Bootstrapper : IDisposable
    {
        private IDisposable _webApp;

        public void Run()
        {
            XmlConfigurator.Configure();

            var builder = new ContainerBuilder();

            builder.RegisterType<EventPump>().As<IEventPump>().SingleInstance();
            builder.RegisterType<Broadcaster>().As<IBroadcaster>().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            _webApp = WebApp.Start("http://localhost:8888", app =>
            {
                app.UseCors(CorsOptions.AllowAll);
                app.UseWelcomePage("/");

                var httpConfiguration = new HttpConfiguration
                {
                    IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always,
                    DependencyResolver = new AutofacWebApiDependencyResolver(container)
                };
                httpConfiguration.MapHttpAttributeRoutes();
                app.UseWebApi(httpConfiguration);

                var hubConfig = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    Resolver = new AutofacDependencyResolver(container)
                };

                app.MapSignalR(hubConfig);

                app.UseStaticFiles();
            });
        }

        public void Dispose()
        {
            _webApp?.Dispose();
        }
    }
}