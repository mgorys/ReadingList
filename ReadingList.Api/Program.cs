using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ReadingList.Abstractions.IRepositories;
using ReadingList.Abstractions.IServices;
using ReadingList.Api.Validators;
using ReadingList.Infrastructure.Exceptions;
using ReadingList.Infrastructure.Mapping;
using ReadingList.Models.Dto;
using ReadingList.Persistence;
using ReadingList.Repositories;
using ReadingList.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IValidator<CreateBookDto>, CreateBookDtoValidator>();
builder.Services.AddAutoMapper(cfg=>
    cfg.AddProfile<BookMappingProfile>());
builder.Services.AddDbContext<ReadingListDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReadingListConnectionString")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
