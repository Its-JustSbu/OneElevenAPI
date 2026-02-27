using Microsoft.AspNetCore.Http.HttpResults;
using OneElevenAPI.DTO;
using OneElevenAPI.Repository;

var _main = new Main();

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/", (RequestBody request) =>
{
    if (request.Data is null) return Results.BadRequest("Data must be of type string");

    if (request.Data.Length == 0) return Results.Ok(new { word = Array.Empty<Char>() });

    if (request.Data.Length == 1) return Results.Ok(new { word = request.Data.ToCharArray() });

    return Results.Ok(new { word = _main.sortString(request.Data.ToCharArray()) });
});

app.UseHttpsRedirection();

app.UseCors();

app.Run();
