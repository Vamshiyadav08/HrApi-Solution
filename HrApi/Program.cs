global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations;
global using AutoMapper;


using HrApi.Models;

using HrApi.Repositories.Interface;
using HrApi.Repositories.SqlServer;
using HrApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add dbcontext
builder.Services.AddDbContext<HrStopssContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("hrapidb")));
builder.Services.AddMvc();
builder.Services.AddScoped<IHrApiRepositary, HrApiRepositary>();
//automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//build app
var app = builder.Build();

// Configure the HTTP request pipeline.
//add global exception handler
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
