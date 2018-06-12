using Repository.Base;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class User : EntityBase
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
