using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SamauraiDBcontext : DbContext
    {
        public DbSet<Samaurais>  Samaurais{get; set;}
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = SamauraisApp ");
            
        }

    }
}
