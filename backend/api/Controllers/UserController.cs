using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



using api.Services;
using api.Data.DTOs;
using api.SignalR;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserServices _userServices;
    private readonly IHubContext<Notificacion> _hubContext;


    public UserController(UserServices userServices, IHubContext<Notificacion> hubContext)
    {
        _userServices = userServices;
        _hubContext = hubContext;


    }



    [HttpGet]
    public async Task<ActionResult> getAllUsers()  {

        await _hubContext.Clients.All.SendAsync("Se han realizado cambios en los datos","juan");
        
        return Ok(await _userServices.getAllUsers());

    }




  
}



