using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class MovieRepository : ReposityBase<Movie>
    {
        private readonly AppDbContext Context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return GetAll().OrderBy(m => m.MovieName).ToList();
        }

        public void EditMovie(Movie movie)
        {

            var movieRepository = Context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            movieRepository.MovieName = movie.MovieName;
            movieRepository.MovieRateAge = movie.MovieRateAge;
            movieRepository.ReleaseDate = movie.ReleaseDate;
            movieRepository.RentPrice = movie.RentPrice;

            Context.Attach(movieRepository).State = EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<Rent> GetRentsForMovie (int movieId)
        {
            return Context.Rents.Where(r => r.Id == movieId).OrderBy(r => r.RentDate).ToList();
        }

    }
}
