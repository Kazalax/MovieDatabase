namespace Movies.Api.Models
{
    public class MovieFilterDto
    {
        public uint? DirectorId { get; set; }
        public uint? ActorId { get; set; }
        public string? Genre { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public int? Limit { get; set; }
    }
}
