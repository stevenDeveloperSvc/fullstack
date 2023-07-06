namespace api.Data.DTOs
{
    public class TokenResponseDTO
    {
        public string Token { get; set; }   
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public int UserId { get; set; }
    }
}

