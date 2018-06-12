using Repository.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Movie : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public int MovieRateAge { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double RentPrice { get; set; }
    }
}
