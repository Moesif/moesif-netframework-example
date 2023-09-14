using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Moesif.Middleware;
using Moesif.NetFramework.Example.Settings;
using System.IO;

[assembly: OwinStartup(typeof(Moesif.NetFramework.Example.Startup))]
namespace Moesif.NetFramework.Example
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Use<MoesifMiddleware>(MoesifOptions.moesifOptions);
            StreamWriter writer = new System.IO.StreamWriter("C:\\ConsoleOutput2.txt", true);
            writer.AutoFlush = true;

            Console.SetOut(writer);
        }
    }
}
