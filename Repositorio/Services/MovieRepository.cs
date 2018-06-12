using Repository.Base;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class MovieRepository : ReposityBase<Movie>
    {
        public MovieRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return GetAll().OrderBy(m => m.MovieName).ToList();
        }
    }
}
