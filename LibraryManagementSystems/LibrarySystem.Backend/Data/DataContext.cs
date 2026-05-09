using LibrarySystem.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LibrarySystem.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //evita duplicados de variable (Name ) en la bd 
            modelBuilder.Entity<Category>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(x => x.Title).IsUnique();
        }
    }
}