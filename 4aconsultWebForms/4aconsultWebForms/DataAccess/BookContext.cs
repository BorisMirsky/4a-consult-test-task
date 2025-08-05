using Microsoft.EntityFrameworkCore;
using _4aconsultWebForms.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;



namespace _4aconsultWebForms.DataAccess
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Bookstable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}