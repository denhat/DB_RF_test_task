using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace DB_RF_test_task.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "DB_RF_test_task";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                })
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
