using System;
using OMDBService.Models;

namespace OMDBService.Interface
{
	public interface ISearchRepository
	{
        ICollection<SearchQueries> GetSearchQueries();
        ICollection<SearchQueries> GetSearchQuery(string searchQuery);
        bool SaveSearch(SearchQueries searchQueries);
        bool SearchQueryExist(string searchQueries);
        bool Save();
    }
}

