using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMDBService.Dtos;
using OMDBService.Interface;
using OMDBService.Models;

namespace OMDBService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class SearchController : Controller
	{
        private readonly ISearchRepository _searchRepository;
        private readonly IMapper _mapper;

        public SearchController(ISearchRepository searchRepository, IMapper mapper)
		{
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SearchQueries>))]
        [ProducesResponseType(400)]
        public  IActionResult GetSearchQueries([FromQuery] string query)
        {

            if (!_searchRepository.SearchQueryExist(query))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var res = _mapper.Map<List<SearchQueriesDto>>(_searchRepository.GetSearchQuery(query));


            return Ok(res);
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult SaveSearch([FromBody] SearchQueriesDto searchBody)
        {
            if (searchBody == null)
                return BadRequest(ModelState);

            var search = _searchRepository.GetSearchQueries()
                .Where(c => c.Name.Trim().ToUpper() == searchBody.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (search != null)
            {
                //ModelState.AddModelError("", "already exists");
              
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var searchQueryMap = _mapper.Map<SearchQueries>(searchBody);
            var searchQueryMap = new SearchQueries() { Name = searchBody.Name};

            if (!_searchRepository.SaveSearch(searchQueryMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

    }
}

