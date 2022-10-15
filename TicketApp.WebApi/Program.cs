using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using TicketApp.WebApi.Commons.Configurations;
using TicketApp.WebApi.Commons.Middlewares;
using TicketApp.WebApi.Commons.Security;
using TicketApp.WebApi.DbContexts;
using TicketApp.WebApi.Interfaces.Managers;
using TicketApp.WebApi.Interfaces.Repositories;
using TicketApp.WebApi.Interfaces.Services;
using TicketApp.WebApi.Repositories;
using TicketApp.WebApi.Services;
using TodoList.WebApi.Commons.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureJwt(builder.Configuration.GetSection("Jwt"));
builder.Services.ConfigureSwaggerAuthorize();

//Caching 
builder.Services.AddMemoryCache();

var connectionString = builder.Configuration.GetConnectionString("PostgresDevelopmentDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
   loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

// Repository Relations
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Service Relations
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

var app = builder.Build();

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandleMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();
#endregion