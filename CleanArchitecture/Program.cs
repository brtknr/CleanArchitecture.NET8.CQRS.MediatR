using CleanArchitecture.Api.BackgroundServices;
using CleanArchitecture.Api.Middlewares;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Identity.Enums;
using CleanArchitecture.Infrastructure.Identity.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StackExchange.Redis;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    //.WriteTo.Seq(,)
    .WriteTo.File("logs/log-.txt",rollingInterval:RollingInterval.Day)
    //.WriteTo.Seq() // to do seq implementation
    .CreateLogger();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["ConnectionStrings:Redis"];
    //options.InstanceName = "SampleInstance";
});

//builder.Services.AddHostedService<MessageConsumer>();
builder.Services.AddSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration)
                .AddApplication()
                .AddIdentityDbContext(builder.Configuration)
                .AddInfrastructureIdentityServices()
                .AddIdentityAuth()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                        
                    };
                });
                
builder.Services.AddAuthorization(x => x.AddPolicy("BusinessPolicy", policy => policy.RequireClaim(ClaimTypes.Role,Roles.Business.ToString())));
builder.Services.AddAuthorization(x => x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role,Roles.Customer.ToString())));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
