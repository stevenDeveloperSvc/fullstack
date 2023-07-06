using api.Data;
using api.Data.DTOs;
using api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using api.Services.Helpers;
using Microsoft.Extensions.Configuration;

namespace api.Services;



public class UserServices
{
    private readonly apiContext _context;




    public UserServices(apiContext context) { 
    
        _context = context;



    }



    public async Task<IEnumerable<User?>> getAllUsers() => await _context.users.ToListAsync();


 


}

