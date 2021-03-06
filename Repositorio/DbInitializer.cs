﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    /// <summary>
    /// Seed for initial database
    /// </summary>
    public class DbInitializer
    {
        public static void Seed(AppDbContext appDbContext)
        {
            if (!appDbContext.Movies.Any())
            {
                appDbContext.AddRange
                    (
                        new Movie()
                        {
                            Id = 1,
                            MovieName = "Deadpool",
                            MovieRateAge = 18,
                            ReleaseDate = new DateTime(2016, 2, 12, 0, 0, 0),
                            RentPrice = 10.00,
                            Rents = new List<Rent>()
                            {
                                new Rent()
                                {
                                    Id = 1,
                                    RentDate = new DateTime(2018, 6, 14, 0, 0, 0),
                                    ReturnDate = new DateTime(2018, 6, 21, 0, 0, 0),
                                },
                                new Rent()
                                {
                                    Id = 2,
                                    RentDate = new DateTime(2018, 6, 07, 0, 0, 0),
                                    ReturnDate = new DateTime(2018, 6, 15, 0, 0, 0),
                                }
                            }
                        },
                        new Movie()
                        {
                            Id = 2,
                            MovieName = "Ted",
                            MovieRateAge = 18,
                            ReleaseDate = new DateTime(2012, 6, 29, 0, 0, 0),
                            RentPrice = 8.00
                        },
                        new Movie()
                        {
                            Id = 3,
                            MovieName = "Ted2",
                            MovieRateAge = 18,
                            ReleaseDate = new DateTime(2015, 6, 26, 0, 0, 0),
                            RentPrice = 8.00
                        }
                    );
            }

            if (!appDbContext.Users.Any())
            {
                appDbContext.AddRange
                    (
                        new User { Id = 1, Email = "lipinholocadora@outlook.com", Password = "P@assword" },
                        new User { Id = 2, Email = "lipinholocadora@gmail.com", Password = "P@assword" }
                    );
            }

            appDbContext.SaveChanges();
        }

    }
}
