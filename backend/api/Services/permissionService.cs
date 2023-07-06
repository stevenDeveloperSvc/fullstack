using api.Data;
using api.Data.DTOs;
using api.Data.Models;
using api.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class permissionService
    {
        private readonly apiContext _apicontext;


        public permissionService(apiContext apiContext) => _apicontext = apiContext;



        public async Task<IEnumerable<RolePermission>> GetAllRolePermission() => await _apicontext.rolePermissions.ToListAsync();




      


    }
}
