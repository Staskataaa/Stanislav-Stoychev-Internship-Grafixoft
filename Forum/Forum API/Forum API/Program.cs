using Forum_API.Configuration;
using Forum_API.Filters;
using Forum_API.ForumAPILogger;
using Forum_API.Repository;
using Forum_API.Repository.Reposiory_Models;
using Forum_API.Repository.Repository_Interfaces;
using Forum_API.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dependencies = new Dependencies();
var dependenciesConfig = new LoggerConfig();

dependenciesConfig.ConfigureLogger(builder);
dependencies.DefineDependencies(builder);

builder.Services.AddAuthorization();

builder.Services.AddControllers(opt => {
    opt.Filters.Add(new ExceptionFilter());
});

builder.Services.AddDbContext<ForumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
