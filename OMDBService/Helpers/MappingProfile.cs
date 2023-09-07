using System;
using System.Diagnostics.Metrics;
using AutoMapper;
using OMDBService.Dto;
using OMDBService.Dtos;
using OMDBService.Models;
namespace pokemon.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SearchQueries, SearchQueriesDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Rating, RatingDto>();

        }


    }
}
