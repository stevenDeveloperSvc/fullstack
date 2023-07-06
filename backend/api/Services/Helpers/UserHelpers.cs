using api.Data;
using api.Data.Models;
using api.Data.DTOs;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace api.Services.Helpers
{
    public static class UserHelpers
    {

        private static apiContext _context;
        private static IConfiguration _config;



        public static void InitContext(apiContext context)
        {
            _context = context;
        }

        public static void InitContext(apiContext context, IConfiguration config )
        {

            _context = context;

            _config = config;

        }



        public static  async Task<User> GetCurrentLogedUser(loginDTO login) => await _context.users.Where(o => o.username == login.userName).SingleOrDefaultAsync();

        public static async Task<int> GetIdUserByName(roleToUserDTO role) => await _context.users.Where(o => o.username == role.username).Select(o => o.id).SingleAsync();







        public static async Task<bool> verifiyRoleToUser(roleToUserDTO roleToUserDTO)

        {
            var userId = await GetIdUserByName(roleToUserDTO);
            return await _context.UserRoles.AnyAsync(e => e.roleTypeId == roleToUserDTO.roleId && e.userId == userId);


        }

         



        public static async Task<roleToUserDTO> assingRoleToUser( roleToUserDTO roleToUserDTO )
        {

            //Se consgiue el Id del usuario.
            int id = await GetIdUserByName(roleToUserDTO);

            //aca se asigna el rol al usuario
            UserRole userRole = new UserRole()
            {
                roleTypeId = roleToUserDTO.roleId,
                userId = id,
                active= 1

            };


            List<RolePermission> rolePermissions = _context.rolePermissions
                                                 .Where(o => o.roleTypeId == userRole.roleTypeId).ToList();



            List<UserPermission> userPermissions = rolePermissions.Select(o => new UserPermission
            {
                userId = id,
                permissionTypeId = o.permissionTypeId,
                roleTypeId = o.roleTypeId,
                active = o.active
            }).ToList();


            await _context.UserRoles.AddAsync(userRole);

            await _context.userPermissions.AddRangeAsync(userPermissions);
            await _context.SaveChangesAsync();  

            return roleToUserDTO;
        }











        public static async Task<bool> verifyAlreadyDeleted(roleToUserDTO roleToUserDTO)
        {

            int userId = await GetIdUserByName(roleToUserDTO);
            return await _context.UserRoles.AnyAsync(e => e.roleTypeId == roleToUserDTO.roleId && e.userId == userId && e.active == 0);



        }



        public static async Task<bool> deleteRoleFromUser (roleToUserDTO roleToUserDTO)
        {

            try
            {
   

            int userId = await GetIdUserByName(roleToUserDTO);

            UserRole userRole = await _context.UserRoles.SingleOrDefaultAsync(o => o.userId == userId && o.roleTypeId == roleToUserDTO.roleId);

            userRole.active = 0;


            IEnumerable<UserPermission> userPermissions = await _context.userPermissions
                                 .Where(o => o.userId == userId && o.roleTypeId == userRole.roleTypeId)
                                 .Select(o => new UserPermission
                                 {
                                     id = o.id,
                                     userId = userId,
                                     roleTypeId = o.roleTypeId,
                                     permissionTypeId = o.permissionTypeId,
                                     active = 0,
                                     User = o.User,
                                     PermissionType = o.PermissionType,
                                     RoleType = o.RoleType

                                 }).ToListAsync();

             _context.userPermissions.UpdateRange(userPermissions);

            await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                return false;
            }
    

        }







    }
}
