using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public class RolePermission
    {

        public int id {  get; set; }

        public int roleTypeId { get; set; }


        public int  permissionTypeId { get; set; }


        public int active { get; set; }


        public virtual RoleType? RoleType { get; set; }  

        public virtual  PermissionType? PermissionType { get; set; }  



    }
}
