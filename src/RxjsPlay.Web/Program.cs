using Topshelf;

namespace RxjsPlay.Web
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<Bootstrapper>(s =>
                {
                    s.ConstructUsing(_ => new Bootstrapper());
                    s.WhenStarted(b => b.Run());
                    s.WhenStopped(b => b.Dispose());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetDescription("ZomgRxRocks");
                x.SetDisplayName("ZomgRxRocks");
                x.SetServiceName("ZomgRxRocks");
            });
        }
    }
}
