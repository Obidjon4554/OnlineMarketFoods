using System.Reflection;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using OnlineMarketFoods.Examples;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.ExampleFilters(); 

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
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Online Market Foods API",
        Version = "v2",
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
    options.SwaggerDoc("v3", new OpenApiInfo
    {
        Title = "Online Market Foods API",
        Version = "v3",
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
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    //options.ApiVersionReader = ApiVersionReader.Combine(
    //    new QueryStringApiVersionReader("v"),
    //    new HeaderApiVersionReader("X-Version"),
    //    new MediaTypeApiVersionReader("x-api-version")
    //    );
})
    .AddMvc()
    .AddApiExplorer(options =>
      {
          options.GroupNameFormat = "'v'VVV";
          options.SubstituteApiVersionInUrl = true;
      });



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
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "OnlineMarketFoods API V2");
        options.SwaggerEndpoint("/swagger/v3/swagger.json", "OnlineMarketFoods API V3");
    });
    app.UseReDoc(options =>
    {
        options.SpecUrl = "/swagger/v1/swagger.json";
        options.SpecUrl = "/swagger/v2/swagger.json";
        options.SpecUrl = "/swagger/v3/swagger.json";
        options.RoutePrefix = "docs"; // Set the route prefix for ReDoc
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();