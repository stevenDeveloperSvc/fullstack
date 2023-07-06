using api.Data;
using api.Data.DTOs;
using api.Data.Models;
using api.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Services;

public class AuthServices
{

    private readonly apiContext _context;
    private readonly IConfiguration _configuration;

    public AuthServices(apiContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration; 
    }

    public async Task<IActionResult> signup(registerDTO _registerDTO)
    {
        bool isUserAlreadyRegister = await _context.users.AnyAsync(o => o.username == _registerDTO.userName || o.email == _registerDTO.email);

        if (isUserAlreadyRegister)
            return new BadRequestObjectResult(new { result = $"Ya existe en la base de datos" });
        else

        {
            PasswordHelper.InitContext(_context);

            User user = new User()
            {
                username = _registerDTO.userName,
                email = _registerDTO.email,
                passwordHash = PasswordHelper.HashPassword(_registerDTO.passwordHash),
                regDate = DateTime.Now,
                active = 1,
            };
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        return new OkObjectResult(new
        {
            result = $"Enhorabuena! " +
            $"el usuario {_registerDTO.userName} " +
            $"se agregado al sistema con fecha {DateTime.Now}"
        });

    }




    public async Task<IActionResult> signin(loginDTO login)
    {

        PasswordHelper.InitContext(_context);
        TokenHelper.InitContext(_context, _configuration);
        UserHelpers.InitContext(_context, _configuration);

        bool userIsOnSystem = await PasswordHelper.VerifyPassword(login);

        string token;

        if (userIsOnSystem)
        {
            User user = await UserHelpers.GetCurrentLogedUser(login);
           var obj = await TokenHelper.GenerateToken(user);

            return new OkObjectResult(obj);

        }
        return   new UnauthorizedObjectResult(new { result = "Contrasena incorrecta" });



    }



}
