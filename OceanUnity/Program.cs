using oceanunity.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using oceanunity.data;
using oceanunity.services;
using oceanunity.Services;

var builder = WebApplication.CreateBuilder(args);

#region Contexts
builder.Services.AddDbContext<SensorContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddDbContext<AcoesMitigacaoContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Ocean Unity .NET API", 
        Version = "v1",
        Description = "API responsável em fazer pesquisas personalizadas para o aplicativo Ocean Unity",
        Contact = new OpenApiContact
        {
            Name = "Giovanni Ultramari",
            Email = "giovanniultramari@gmail.com"
        }
    });
});
#region Services
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<IAcoesMitigacaoService, AcoesMitigacaoService>();
#endregion
var app = builder.Build();
#region Endpoints
app.RegisterSensorEndpoints();
app.RegisterAcaoEndpoints();
#endregion

#region Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseReDoc(options =>
                {
                    options.DocumentTitle = $"API Documentation";
                    options.SpecUrl = $"/swagger/v1/swagger.json";
                    options.RoutePrefix = $"docs";
                });


}
#endregion
app.UseHttpsRedirection();

app.Run();

