using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORMEnitityFramework.Models;

namespace ORMEnitityFramework
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-BIJFUOL;Initial Catalog=DBMSLab5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.Language);
            modelBuilder.Entity<Client>().HasIndex(c => c.PhoneNumber);
            modelBuilder.Entity<Author>().HasIndex(a => a.FullName);
        }

        public virtual DbSet<Author> Authors { set; get; }
        public virtual DbSet<Book> Books { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<BookAuthor> BookAuthors { set; get; }
        public virtual DbSet<BookGivenAway> BookGivenAways { set; get; }
    }
}
