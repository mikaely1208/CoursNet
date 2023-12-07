
namespace webapi;
using System.Reflection;
using System;
using AutoMapper;
using BookService.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Assembly a = typeof(Program).Assembly;

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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
    }
}

public class Mapping:Profile
{
    public Mapping()
    {
       // mapping de book vers bookDTO
       CreateMap<BookDTO, Book>();
    }
}
