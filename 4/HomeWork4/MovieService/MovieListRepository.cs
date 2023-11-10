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
    }
}