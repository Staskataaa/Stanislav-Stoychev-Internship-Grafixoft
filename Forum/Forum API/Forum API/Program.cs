using Forum_API.Controllers;
using Forum_API.Filters;
using Forum_API.ForumAPILogger;
using Forum_API.Repository;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();;
builder.Services.AddSingleton<ILoggerProvider, ForumAPIFileLoggerProvider>();
builder.Services.Configure<ILoggerProvider>(builder.Configuration.GetSection("Logging"));
builder.Services.AddControllers();
builder.Services.Configure<ForumAPIFileLoggerOptions>(builder.Configuration.GetSection("LoggerProvider"));
builder.Services.AddControllers(opt => opt.Filters.Add(new ExceptionFilter()));
builder.Services.AddDbContext<ForumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<IAccountRoleService, AccountRoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
