using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public  class PermissionType
    {
        public PermissionType()
        {
            RolePermissions = new HashSet<RolePermission>();
            userPermissions = new HashSet<UserPermission>();
        }



         [Required]
         public int id { get; set; }

         public string name { get; set; }

         [Range(0,1)]
         public int active { get; set; }



        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<UserPermission> userPermissions { get; set; }

    }
}
