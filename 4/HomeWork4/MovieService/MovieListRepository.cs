using MovieLibrary;

namespace MovieService
{
    public class MovieListRepository : IMovieRepository
    {
        private List<Movie> _movies;

        public MovieListRepository()
        {
            this._movies = new List<Movie>();
        }

        public Movie GetById(Guid? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id), "Movie with specified Id was not found in repository");
            }

            return this._movies.Where(m => m.Id == id).FirstOrDefault()
                ?? throw new ArgumentException("Movie with specified Id was not found in repository");
        }

        public IEnumerable<Movie> GetAll()
        {
            return this._movies ?? new List<Movie>();
        }

        public void Add(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Unable to add null entity to the repository");
            }

            this._movies.Add(entity);
        }

        public void Update(Movie entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Unable update null value entity");
            }

            Movie movie;
            try
            {
                movie = this.GetById(entity.Id);
            }
            catch (ArgumentNullException)
            {
                throw;
            }

            movie.Title = entity.Title;
            movie.Director = entity.Director;
            movie.Style = entity.Style;
            movie.ShortDescription = entity.ShortDescription;
            movie.Showtimes = new List<Showtime>(entity.Showtimes);
        }

        public void Delete(Guid id)
        {
            this._movies.RemoveAll(m => m.Id == id);
        }

        public void Repopulate()
        {
            this._movies.Clear();

            this._movies.Add(new Movie
            {
                Id = new Guid(),
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

            this._movies.Add(new Movie
            {
                Id = new Guid(),
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

            this._movies.Add(new Movie
            {
                Id = new Guid(),
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