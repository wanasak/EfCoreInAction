﻿using ServiceLayer.BookService.QueryObjects;
using System;
using System.Linq;

namespace ServiceLayer.BookService
{
    public class SortFilterPageOptions
    {
        public const int DefaultPageSize = 10;

        private int _pageSize = DefaultPageSize;

        public OrderByOptions OrderByOptions { get; set; }
        public BooksFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }

        private int _pageNum = 1;
        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int[] PageSizes = new[] { 5, DefaultPageSize, 20, 50, 100, 500, 1000 };

        public int NumPages { get; private set; }

        public string PrevCheckState { get; set; }

        public void SetupRestOfDto<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            PageNum = Math.Min(Math.Max(1, PageNum), NumPages);

            var newCheckState = GenerateCheckState();
            if (PrevCheckState != newCheckState)
                PageNum = 1;

            PrevCheckState = newCheckState;
        }

        private string GenerateCheckState()
        {
            return $"{(int)FilterBy}, {FilterValue}, {PageSize}, {NumPages}";
        }
    }
}
