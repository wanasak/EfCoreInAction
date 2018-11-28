using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceLayer.BookService.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "sort by...")]
        SimpleOrder = 0,
        [Display(Name = "Votes ↑")]
        ByVotes,
        [Display(Name = "Publication Date ↑")]
        ByPublicationDate,
        [Display(Name = "Price ↓")]
        ByPriceLowestFirst,
        [Display(Name = "Price ↑")]
        ByPriceHigestFirst
    }

    public static class BookListDtoSort
    {
        public static IQueryable<BookListDto> OrderBooksBy
            (this IQueryable<BookListDto> books,
             OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return books.OrderByDescending(b => b.BookId);
                case OrderByOptions.ByVotes:
                    return books.OrderByDescending(b => b.ReviewsAvarageVotes);
                case OrderByOptions.ByPublicationDate:
                    return books.OrderByDescending(b => b.PublishedOn);
                case OrderByOptions.ByPriceLowestFirst:
                    return books.OrderBy(b => b.ActualPrice);
                case OrderByOptions.ByPriceHigestFirst:
                    return books.OrderByDescending(b => b.ActualPrice); ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
