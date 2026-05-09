using LibrarySystem.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LibrarySystem.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoryAsync();
            await CheckBookyAsync();

        }

        private async Task CheckCategoryAsync()
        {
            if (!_context.Categories.Any())
            {
                _ = _context.Categories.Add(new Category
                {
                    Description = "Quimica",
                    State = true
                });
                _ = _context.Categories.Add(new Category    
                {
                    Description = "Psicologia",
                    State = true
                });
                _ = _context.Categories.Add(new Category    
                {
                    Description = "Fantasia",
                    State = true
                });
                _ = _context.Categories.Add(new Category
                {
                    Description = "Ciencia Ficcion",
                    State = true
                });
                _ = _context.Categories.Add(new Category
                {
                    Description = "Poema",
                    State = true
                }); 
                _ = _context.Categories.Add(new Category
                {
                    Description = "Novela Gotica",
                    State = true
                });
                _ = _context.Categories.Add(new Category
                {
                    Description = "Biografias",
                    State = true
                });
                _ = _context.Categories.Add(new Category
                {
                    Description = "Novela",
                    State = true
                });
                _ = _context.Categories.Add(new Category
                {
                    Description = "Historia Geografia",
                    State = true
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckBookyAsync()
        {
            if (!_context.books.Any())
            {
                var Category = await _context.Categories.FirstOrDefaultAsync(x => x.Description == "Quimica");
                _ = _context.books.Add(new Book
                {
                    Title = "libr01",
                    Author = "libr01Author",
                    Category = Category,
                    CreationDate = DateTime.Now,
                    Editorial = "libr01Editorial",
                    Exemplars = 10,
                    Home = "libr01Home",
                    Location = "libr01Location",
                    State = true,
                    Status = true
                });
                _ = _context.books.Add(new Book
                {
                    Title = "libr2",
                    Author = "libr02Author",
                    Category = Category,
                    CreationDate = DateTime.Now,
                    Editorial = "libr02Editorial",
                    Exemplars = 10,
                    Home = "libr02Home",
                    Location = "libr02Location",
                    State = true,
                    Status = true
                });
                _ = _context.books.Add(new Book
                {
                    Title = "libr3",
                    Author = "libr03Author",
                    Category = Category,
                    CreationDate = DateTime.Now,
                    Editorial = "libr03Editorial",
                    Exemplars = 10,
                    Home = "libr03Home",
                    Location = "libr03Location",
                    State = true,
                    Status = true
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
