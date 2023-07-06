using System.ComponentModel.DataAnnotations;

namespace api.Data.DTOs
{
    public class registerDTO
    {

        [Required]
        public string userName { get; set; }    

        [EmailAddress]
        public string email { get; set; }

        [MinLength(5)]
        public string passwordHash { get; set; }

    }
}
