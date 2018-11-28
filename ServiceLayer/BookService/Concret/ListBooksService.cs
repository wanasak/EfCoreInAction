using DataLayer.Codes;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BookService.QueryObjects;
using System.Linq;

namespace ServiceLayer.BookService.Concret
{
    public class ListBooksService
    {
        private readonly EfCoreContext _context;

        public ListBooksService(EfCoreContext context)
        {
            _context = context;
        }

        public IQueryable<BookListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var booksQuery = _context.Books
                .AsNoTracking()
                .MapBookToDto()
                .OrderBooksBy(options.OrderByOptions)
                .FilterBooksBy(options.FilterBy, options.FilterValue);

            // This stage sets up the number
            // of pages and makes sure
            // PageNum is in the right range
            options.SetupRestOfDto(booksQuery);

            return booksQuery.Page(options.PageNum - 1, options.PageSize);
        }
    }
}
