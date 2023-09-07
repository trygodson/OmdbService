using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OMDBService.Dto;
using OMDBService.Models;
using OMDBService.Services;

namespace OMDBService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : Controller
	{
		
        private readonly OMDBApiService _movieService;
        private readonly IMapper _mapper;
        public MovieController(OMDBApiService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        [HttpGet("omdb")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SearchMovies([FromQuery] string search, [FromQuery] string year, [FromQuery] string plot)
        {
            try
            {
                var res = await _movieService.searchMovies(search, year, plot);
                var movie = _mapper.Map<MovieDto>(res);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }

        }
    }
}

