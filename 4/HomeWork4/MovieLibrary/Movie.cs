namespace MovieLibrary
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;

        public string Director { get; set; } = default!;

        public string Style { get; set; } = default!;

        public string ShortDescription { get; set; } = default!;

        public IEnumerable<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}