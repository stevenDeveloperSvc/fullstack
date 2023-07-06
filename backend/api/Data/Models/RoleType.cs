using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public class RoleType
    {
        public RoleType()
        {

            UserRoles = new HashSet<UserRole>();
            RolePermissions = new HashSet<RolePermission>();

        }


        [Required]
        public int id { get; set; }

        public string name { get; set; }

        [Range(0,1)]
        public int active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

    }
}