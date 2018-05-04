using Microsoft.EntityFrameworkCore;
using BookStore.Data.EntityModels;

namespace BookStore.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H32;Persist Security Info=False;User ID=VLN2_2018_H32_usr;Password=bigRe)48;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");                    
        }
    }
}