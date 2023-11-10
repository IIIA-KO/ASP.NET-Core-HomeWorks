using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieLibrary;
using MovieService;

namespace MoviesRazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        public Movie Movie { get; set; } = default!;
        public List<Showtime> Showtimes { get; set; } = default!;

        public DetailsModel(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie;
            try
            {
                movie = this._movieRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }

            Movie = movie;

            Showtimes = movie.Showtimes.ToList();

            return Page();
        }
    }
}
