using BookWorm.ModelDB;
using Microsoft.EntityFrameworkCore;
using UserSecrets;

namespace BookWorm.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Users> ?Users { get; set; }
        public DbSet<Books> ?Books { get; set; }
        public DbSet<ReadingBooks> ?ReadingBooks { get; set; }
        public DbSet<FavoriteBooks> ?FavoriteBooks { get; set; }
        public DbSet<RecommendedBook>? RecommendedBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secrets.ConnectionString);
        }
    }
}
