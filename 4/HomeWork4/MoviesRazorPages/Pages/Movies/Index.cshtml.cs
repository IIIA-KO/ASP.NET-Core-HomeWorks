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
            this._movieRepository.Repopulate();
            Movies = this._movieRepository.GetAll().ToList();
        }
    }
}
