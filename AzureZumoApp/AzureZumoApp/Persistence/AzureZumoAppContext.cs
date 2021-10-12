using AzureZumoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureZumoApp.Persistence
{
    class AzureZumoAppContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        private readonly string _databasePath;

        public AzureZumoAppContext()
        {

        }

        public AzureZumoAppContext(string databasePath) : this()
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
