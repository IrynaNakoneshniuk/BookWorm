using BookWorm.ModelDB;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<ReadingBooks> ReadingBooks { get; set; }
        public DbSet<FavoriteBooks> FavoriteBooks { get; set; }
        public DbSet<RecommendedBook> RecommendedBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=mysqlserver2589.database.windows.net;Initial Catalog=mySampleDatabase;User ID=azureuser;Password=homer+2589;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
