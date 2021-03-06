﻿using Domain.Base;
using Repository;
using Repository.Entities;
using Repository.Services;

namespace Domain.Queries
{
    public class GetMovieQuery : IQuery<Movie>
    {
        /// <summary>
        /// Query to get a movie in databe by id
        /// </summary>
        private readonly int Id;

        public GetMovieQuery(int id)
        {
            Id = id;
        }

        public Movie Execute(AppDbContext context)
        {
            var repository = new MovieRepository(context);
            if (repository.Exists(Id))
            {
                return repository.GetById(Id);
            }
            else
                return null;
        }
    }
}
