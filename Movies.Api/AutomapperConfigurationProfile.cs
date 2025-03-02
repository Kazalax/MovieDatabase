using AutoMapper;
using Movies.Api.Models;
using Movies.Data.Models;

namespace Movies.Api
{
    public class AutomapperConfigurationProfile : Profile
    {
        public AutomapperConfigurationProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            CreateMap<Genre, string>()
                .ConstructUsing((genre, resolutionContext) => genre.Name);

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie,ExtendedMovieDto>();

            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.ActorIds, opt => opt.MapFrom(m => m.Actors.Select(p => p.PersonId).ToList()));
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Genres, opt => opt.Ignore())
                .ForMember(m => m.Actors, opt => opt.Ignore());

            CreateMap<Movie, ExtendedMovieDto>()
                .ForMember(m => m.ActorIds, opt => opt.MapFrom(m => m.Actors.Select(p => p.PersonId).ToList()));
        }
    }
}
