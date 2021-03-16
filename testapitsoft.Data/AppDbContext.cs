using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using testapitsoft.Core.Data.Entity;
using testapitsoft.Data.Configurations;

namespace testapitsoft.Data
{
    public class AppDbContext:DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=tsoftDb;Username=postgres;Password=alicem.tsoft");


        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
          
        }
    }
}
