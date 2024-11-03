
using Microsoft.OpenApi.Models;
using Usuario.Api.Extensions;
using Usuario.Application;
using Usuario.Infraestructure;
using Usuario.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Doc Api",
            Description = "Api para la gestión de docentes",
            Contact = new OpenApiContact
            {
                Name = "Junior Llancari",
                Email = "junior@correo.com"
            }
        });
    }
);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.InitialiseDatabaseAsync();

}


app.UseCustomExceptionHandler();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();