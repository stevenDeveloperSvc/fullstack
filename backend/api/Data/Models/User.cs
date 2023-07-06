using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace api.Data.Models
{
    public  class User
    {
        public User()
        {
            userRoles = new HashSet<UserRole>();
            userPermissions = new HashSet<UserPermission>();
        }

        public int id { get; set; }
        
        [Required]
        public string username { get; set; }    

        [EmailAddress]
        public string email { get; set; }

        public string passwordHash { get; set; }

        public DateTime? regDate { get; set; }

        [Range(0, 1)]
        public int active { get; set; }


        [JsonIgnore]
        public virtual ICollection<UserPermission> userPermissions { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserRole> userRoles { get; set; }

    }
}
