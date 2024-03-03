using AutoMapper;
using MovieApi.Dtos;
using MovieApi.Entity;

namespace MovieApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddMovieDto, Movie>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ActorDto, Actor>();
            CreateMap<DirectorDto, Director>();
            CreateMap<GenreDto, Genre>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<AddAwardDto, Award>();
            CreateMap<UpdateAwardDto, Award>();
        }
    }

}
