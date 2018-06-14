using Repository.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class Rent : EntityBase
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RentDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }

        public double Price { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
