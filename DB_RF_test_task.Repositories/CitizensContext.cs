using DB_RF_test_task.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_RF_test_task.Repositories
{
    public class CitizensContext : DbContext
    {
        public DbSet<CitizenEntity> Citizens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=DB_RF_test_task;User=local_admin;Password=local_admin;");
        }
    }
}
