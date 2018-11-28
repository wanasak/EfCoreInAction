using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Codes
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }

        public EfCoreContext(DbContextOptions<EfCoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new { x.AuthorId, x.BookId });
        }
    }
}
