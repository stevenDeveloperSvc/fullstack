using System.ComponentModel.DataAnnotations;

namespace api.Data.DTOs
{
    public class loginDTO
    {

        [Required(ErrorMessage = "UserName is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }





}
