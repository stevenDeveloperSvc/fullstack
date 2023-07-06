using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public partial class UserRole
    {

        [Required]
        public int id { get; set; }

        [Required]
        public int userId { get; set; } 

        [Required]
        public int roleTypeId { get; set; }


        [Required]
        public int active { get; set; }

        public virtual User? User { get; set; }

        public virtual RoleType? RoleType { get; set; }  



    }
}
