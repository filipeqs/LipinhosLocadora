using Repository.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    [Serializable]
    public class Movie : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int MovieRateAge { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]
        public double RentPrice { get; set; }

        [NotMapped]
        public List<Rent> Rents { get; set; }
    }
}
