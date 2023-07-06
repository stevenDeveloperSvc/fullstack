using api.Data;
using api.Data.DTOs;
using api.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.Services
{
    public class RoleService
    {

        private readonly apiContext _apiContext;

        public RoleService(apiContext apiContext) => _apiContext = apiContext;


        public async Task<IActionResult> assingRoleToUser(roleToUserDTO roleToUserDTO)
        {

            UserHelpers.InitContext(_apiContext);


            var isRoleAlreadyToUser = await UserHelpers.verifiyRoleToUser(roleToUserDTO);


            return isRoleAlreadyToUser ? new BadRequestObjectResult(new { result = "Este usuario ya tiene este rol asignado" }) :
            new OkObjectResult(new { result = await UserHelpers.assingRoleToUser(roleToUserDTO) });


        }


        public async Task<IActionResult> deleteRoleToUser(roleToUserDTO roleToUserDTO)
        {
            UserHelpers.InitContext(_apiContext);


            bool isRoleAlreadyDeletedFromUser = await UserHelpers.verifyAlreadyDeleted(roleToUserDTO);

            return isRoleAlreadyDeletedFromUser ? new BadRequestObjectResult(new { result = "Ya este usuario tiene este rol eliminado" }) :
            new OkObjectResult(new { result = await UserHelpers.deleteRoleFromUser(roleToUserDTO) });



        }
    }
}
