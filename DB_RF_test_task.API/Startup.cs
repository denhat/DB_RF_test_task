using DB_RF_test_task.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.AspNetCore;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System;
using System.Text;
using DB_RF_test_task.Repositories.Repositories;
using Microsoft.OpenApi.Models;

namespace DB_RF_test_task.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{RequestId}] [{Level:u}] {Message}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithHttpRequestId()
                .WriteTo
                .Logger(lc => lc.Filter
                                .ByIncludingOnly(e =>
                                    e.Level == LogEventLevel.Information
                                    || (env.EnvironmentName == "Development" && e.Level == LogEventLevel.Debug)
                                    || e.Level == LogEventLevel.Warning
                                    || e.Level == LogEventLevel.Error
                                    || e.Level == LogEventLevel.Fatal)
                                .WriteTo.Console(outputTemplate: logTemplate))
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DB_RF_test_task API", Version = "v1" });
            });

            services.AddCors();
            services.AddControllers();
            services.AddApiVersioning();

            //my services
            services.AddTransient<ICitizensService, CitizensService>();
            services.AddTransient<IImportExportService, ImportExportService>();

            //my repositories
            services.AddTransient<ICitizensRepository, CitizensRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DB_RF_test_task API V1");
            });

            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
