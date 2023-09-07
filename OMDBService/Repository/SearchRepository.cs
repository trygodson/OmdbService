using System;
using Microsoft.EntityFrameworkCore;
using OMDBService.Data;
using OMDBService.Interface;
using OMDBService.Models;

namespace OMDBService.Repository
{
    public class SearchRepository : ISearchRepository
	{
        private readonly DataContext _context;

        public SearchRepository(DataContext context)
		{
            _context = context;
        }

        public ICollection<SearchQueries> GetSearchQueries()
        {
          return  _context.SearchQueries.ToList();
        }
        public ICollection<SearchQueries> GetSearchQuery(string searchQuery)
        {;
          return  _context.SearchQueries.Where(p =>  p.Name.Contains(searchQuery)  ).ToList();
        }
        public bool SaveSearch(SearchQueries searchQueries)
        {
            var dd = new SearchQueries()
            {
                Name = searchQueries.Name
            };
            _context.Add(dd);
            return Save();
        }
        public bool SearchQueryExist(string searchQueries)
        {
            return _context.SearchQueries.Any(p => p.Name == searchQueries);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}

