using System.ComponentModel.DataAnnotations;

namespace Repository.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
