using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Account_Code_Filter_Service
{
    public class Program
    {
        public static int httpPort = 8080;
        public static int httpsPort = 8443;
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.WriteLine($"**************************************");
            Console.WriteLine($"**** AccountCode Filter Service  ****");
            Console.WriteLine($"IP{IPAddress.Any}************");
            Console.WriteLine($"Ports:{httpPort} & {httpsPort}************");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(options =>
                {
                    //options.Limits.MaxConcurrentConnections = 100;
                    //options.Limits.MaxConcurrentUpgradedConnections = 100;
                    //options.Limits.MaxRequestBodySize = 10 * 1024;
                    //options.Limits.MinRequestBodyDataRate =
                    //    new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    //options.Limits.MinResponseDataRate =
                    //    new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                    options.Listen(IPAddress.Any, httpPort);
                    //options.Listen(IPAddress.Any, httpsPort, listenOptions => { listenOptions.UseHttps("mycert.pfx", "Testing"); });
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();
    }
}
