using Microsoft.AspNetCore.Http.HttpResults;
using OneElevenAPI.DTO;
using OneElevenAPI.Repository;

var _main = new Main();

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/", (RequestBody request) =>
{
    if (request.Data is null) return Results.BadRequest("Data must be of type string");

    if (request.Data.Length == 0) return Results.Ok(new ResponseBody { Word = [] });

    if (request.Data.Length == 1) return Results.Ok(new ResponseBody { Word = request.Data.ToCharArray() });

    return Results.Ok(new ResponseBody { Word = _main.sortString(request.Data.ToCharArray()) });
});

app.UseHttpsRedirection();

app.Run();
