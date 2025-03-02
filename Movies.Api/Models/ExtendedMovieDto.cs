using System.Text.Json.Serialization;

namespace Movies.Api.Models
{
    public class ExtendedMovieDto :MovieDto
    {
        [JsonPropertyName("director")]
        public PersonDto Director { get; set; } = new PersonDto();

        [JsonPropertyName("actors")]
        public List<PersonDto> Actors { get; set; } = new List<PersonDto>();
    }
}
