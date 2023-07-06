using api.Data.DTOs;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService) => _roleService = roleService;

        [HttpPost("user")]
        public async Task<IActionResult> assingRoleToUser(roleToUserDTO roleToUserDTO) => await _roleService.assingRoleToUser(roleToUserDTO);


        [HttpDelete("user")]
        public async Task<IActionResult> DeleteRoleToUser(roleToUserDTO roleToUserDTO) => await _roleService.deleteRoleToUser(roleToUserDTO);


    }
}
