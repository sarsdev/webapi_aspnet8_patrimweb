using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PatrimWeb API",
        Description = "Projeto de estudo: Criação de Web API usando ASP.Net Core 8 + Swagger + Arquitetura REST.",
        TermsOfService = new Uri("https://github.com/sarsdev/webapi_aspnet8_patrimweb/blob/main/README.md"),
        Contact = new OpenApiContact
        {
            Name = "Sars Dev",
            Url = new Uri("https://github.com/sarsdev")
        },
        License = new OpenApiLicense
        {
            Name = "GNU GENERAL PUBLIC LICENSE",
            Url = new Uri("https://github.com/sarsdev/webapi_aspnet8_patrimweb/blob/main/LICENSE")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
