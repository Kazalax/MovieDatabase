using System.Text.Json.Serialization;
using Movies.Data.Models;

namespace Movies.Api.Models
{
    public class PersonDto
    {
        [JsonPropertyName("_id")]
        public uint PersonId { get; set; }
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Country { get; set; } = "";
        public string Biography { get; set; } = "";
        public PersonRole Role { get; set; }
    }
}
