using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using api.Services;
using api.Data; 

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly permissionService _permissionservice;

        public PermissionsController(permissionService permissionservice) => _permissionservice = permissionservice;



        [HttpGet]
        public async Task<ActionResult> GetAllRolePermissions() => Ok(await _permissionservice.GetAllRolePermission());



    }
}
