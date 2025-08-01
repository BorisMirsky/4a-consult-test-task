using Microsoft.EntityFrameworkCore;
using _4aconsultMVC.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace _4aconsultMVC.DataAccess
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Bookstable { get; set; }
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
