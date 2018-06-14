using Domain.Base;
using Repository;
using Repository.Entities;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public class GetRentsForMovieQuery : IQuery<IEnumerable<Rent>>
    {
        /// <summary>
        /// Query to get all rents from a movie in database
        /// </summary>
        private readonly int MovieId;

        public GetRentsForMovieQuery(int movieId)
        {
            MovieId = movieId;
        }

        public IEnumerable<Rent> Execute(AppDbContext context)
        {
            var movieRepository = new MovieRepository(context);

            if (!movieRepository.Exists(MovieId))
            {
                return null;
            }

            return movieRepository.GetRentsForMovie(MovieId);

        }
    }
}
