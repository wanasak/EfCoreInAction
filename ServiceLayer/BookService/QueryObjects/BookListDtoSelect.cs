using DataLayer.Models;
using System.Linq;

namespace ServiceLayer.BookService.QueryObjects
{
    public static class BookListDtoSelect
    {
        public static IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books)
        {
            return books.Select(b => new BookListDto
            {
                BookId = b.BookId,
                Title = b.Title,
                Price = b.Price,
                PublishedOn = b.PublishedOn,
                ActualPrice = b.Promotion == null
                    ? b.Price
                    : b.Promotion.NewPrice,
                PromotionPromotionalText = b.Promotion == null
                    ? null
                    : b.Promotion.PromotionalText,
                ReviewsCount = b.Reviews.Count,
                AuthorsOrdered = string.Join(",", b.BookAuthor.OrderBy(ba => ba.Order)
                    .Select(ba => ba.Author.Name)),
                ReviewsAvarageVotes = b.Reviews
                    .Select(r => (double?)r.NumStars)
                    .Average()
            });
        }
    }
}
