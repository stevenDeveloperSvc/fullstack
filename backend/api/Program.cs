

using api.Data;
using api.Services;
using api.Services.Helpers;
using api.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlServer<apiContext>(builder.Configuration.GetConnectionString("apiDatabase"));


string cors = "politicasDeOrigin";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "politicasDeOrigin",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7156/login/auth/signin",
                                              "http://localhost:4200");
                      });
});

builder.Services.AddAuthorization(options =>
      options.AddPolicy(cors,
      policy => policy.RequireClaim("Permissons", "canRegisterClient"))

      );



//Services

builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<permissionService>();
builder.Services.AddScoped<RoleService>();



builder.Services.AddSignalR();

var app = builder.Build();





app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


app.MapHub<Notificacion>("/check");

app.Run();
