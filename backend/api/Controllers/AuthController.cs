using api.Data.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;




[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{


    private readonly  AuthServices _authServices;

    public AuthController(AuthServices authservices)
    {
        _authServices = authservices;
    }



    [HttpPost("signin")]
    public async Task<IActionResult> userSigin(loginDTO loginDTO) => await _authServices.signin(loginDTO);


    [HttpPost("signup")]
    public async Task<IActionResult> userSignup(registerDTO register) => await _authServices.signup(register);


}

