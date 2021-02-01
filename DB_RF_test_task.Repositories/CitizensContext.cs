using DB_RF_test_task.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DB_RF_test_task.Repositories
{
    public class CitizensContext : DbContext
    {
        public DbSet<CitizenEntity> Citizens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(string.IsNullOrEmpty(environmentName) 
                    ? "appsettings.json"
                    : $"appsettings.{environmentName}.json", 
                    optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
