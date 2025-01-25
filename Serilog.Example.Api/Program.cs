using Destructurama;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Example.Api;
using Serilog.Example.Api.Behavior;
using Serilog.Example.Api.Core;
using Serilog.Example.Api.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices();

// Serilog Configuration
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration) 
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseHttpsRedirection();

app.MapPost("/serilog-sample", async ([FromBody] PayloadRequest request, ISender sender) =>
{
    var command = new PayloadRequestCommand(request);

    var result = await sender.Send(command);

    return Results.Ok(result);
})
.WithName("SerilogSample")
.WithOpenApi();





app.Run();

 