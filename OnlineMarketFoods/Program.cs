using System.Xml.Linq;
using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using OnlineMarketFoods.Examples;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.ExampleFilters(); // This enables examples via Swashbuckle.Filters

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Online Market Foods API",
        Version = "v1",
        Description = "API for managing online market foods",
        TermsOfService = new Uri("https://marketfoods.readme.io/terms"),
        Contact = new OpenApiContact
        {
            Name = "Socials Team",
            Url = new Uri("https://marketfoods.readme.io/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://marketfoods.readme.io/license")
        }
    });
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateCustomerExamples>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateOrderExamples>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateProductExamples>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true; // Serialize as Swagger 2.0
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineMarketFoods API V1");
    });
    app.UseReDoc(options =>
    {
        options.SpecUrl = "/swagger/v1/swagger.json";
        options.RoutePrefix = "docs"; // Set the route prefix for ReDoc
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();