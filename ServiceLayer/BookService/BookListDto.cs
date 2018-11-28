﻿using System;

namespace ServiceLayer.BookService
{
    public class BookListDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal Price { get; set; }
        public decimal ActualPrice { get; set; }
        public string PromotionPromotionalText { get; set; }
        public string AuthorsOrdered { get; set; }
        public int ReviewsCount { get; set; }
        public double? ReviewsAvarageVotes { get; set; }
    }
}
