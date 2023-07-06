using api.Data;
using api.Data.DTOs;
using api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.Services.Helpers
{
    public static class TokenHelper
    {
        private static apiContext _context;


        private static IConfiguration _config;




        public static void InitContext(apiContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        public async static Task<TokenResponseDTO> GenerateToken(User user)
        {
            List<userPermissionsDTO> userWithPermissions = await _context.userPermissions
                                            .Where(o => o.userId == user.id && o.active == 1)
                                            .Select(o => new userPermissionsDTO
                                            {

                                                permissions = o.PermissionType.name
                                            }).ToListAsync();



            List<userRolesDTO> userRolesdto = await _context.UserRoles
                                            .Where(o => o.userId == user.id && o.active == 1)
                                             .Select(o => new userRolesDTO
                                             {
                                                 roles = o.RoleType.name,

                                             }).ToListAsync();



            string permisionsJson = JsonConvert.SerializeObject(userWithPermissions.Select(o => o.permissions));

            string rolesJson = JsonConvert.SerializeObject(userRolesdto.Select(o => o.roles));



            var claims = new[]
            {
                     new Claim (ClaimTypes.Name, user.username),
                     new Claim  (ClaimTypes.Email, user.email),
                     new Claim ("id", user.id.ToString()),
                     new Claim("Role", rolesJson, JsonClaimValueTypes.JsonArray),
                     new Claim("Permissons", permisionsJson, JsonClaimValueTypes.JsonArray),
                };


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
            );

            Console.WriteLine(permisionsJson);
            Console.WriteLine(rolesJson);


            TokenResponseDTO tokenResponseDTO = new TokenResponseDTO()
            {
                UserId = user.id,
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Roles = JsonConvert.DeserializeObject<List<string>>(rolesJson),
                Permissions = JsonConvert.DeserializeObject<List<string>>(permisionsJson),
            };


            return tokenResponseDTO;


        }





    }
}
