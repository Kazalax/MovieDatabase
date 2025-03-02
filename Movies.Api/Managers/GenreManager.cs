using AutoMapper;
using Movies.Api.Interfaces;
using Movies.Data.Interfaces;

namespace Movies.Api.Managers
{
    public class GenreManager : IGenreManager
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenreManager(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }   
        public IList<string> GetAllGenres()
        {
            return mapper.Map<IList<string>>(genreRepository.GetAll());
        }
    }
}
