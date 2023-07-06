using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public partial  class UserPermission
    {
        public int id { get; set; }

        [Required]
        public int userId { get; set; } 


        public int permissionTypeId { get; set; }

        public int roleTypeId { get; set; }

        [Range(0, 1)]
        public int active { get; set; }

        public virtual PermissionType? PermissionType { get; set; }

        public virtual  User? User { get; set; }

        public virtual RoleType? RoleType { get; set; } 


    }
}
