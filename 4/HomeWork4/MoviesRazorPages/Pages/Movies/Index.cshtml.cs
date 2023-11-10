using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;
using MovieService;

namespace MoviesRazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public List<Movie> Movies { get; set; }

        public IndexModel(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        public void OnGet()
        {
            GenerateData();
            Movies = this._movieRepository.GetAll().ToList();
        }

        public void GenerateData()
        {
            this._movieRepository.Add(new Movie
            {
                Title = "Title1",
                Director = "Director1",
                Style = "Style1",
                Showtimes = new List<Showtime>
                {
                    new Showtime
                    {
                        StartTime = DateTime.Now,
                        TicketPrice = 100
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(1),
                        TicketPrice = 120
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(2),
                        TicketPrice = 90
                    }
                },
                ShortDescription = "Short description 1"
            });

            this._movieRepository.Add(new Movie
            {
                Title = "Title2",
                Director = "Director2",
                Style = "Style2",
                Showtimes = new List<Showtime>
                {
                    new Showtime
                    {
                        StartTime = DateTime.Now,
                        TicketPrice = 100
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(1),
                        TicketPrice = 120
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(2),
                        TicketPrice = 90
                    }
                },
                ShortDescription = "Short description 2"
            });

            this._movieRepository.Add(new Movie
            {
                Title = "Title3",
                Director = "Director3",
                Style = "Style3",
                Showtimes = new List<Showtime>
                {
                    new Showtime
                    {
                        StartTime = DateTime.Now,
                        TicketPrice = 100
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(1),
                        TicketPrice = 120
                    },
                    new Showtime
                    {
                        StartTime = DateTime.Now.AddDays(2),
                        TicketPrice = 90
                    }
                },
                ShortDescription = "Short description 3"
            });
        }
    }
}
