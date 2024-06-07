
using oceanunity.dto;
using oceanunity.entities;
using oceanunity.Services;

namespace oceanunity.Endpoints
{
    public static class SensorEndpoints
    {
        public static void RegisterSensorEndpoints(this WebApplication app)
        {
            var sensors = app.MapGroup("/api/v1/sensores");

            #region CRUD Operations
        

            sensors.MapPost("/", async (ISensorService sensorService, SensorDTO sensor) => await sensorService.CreateSensorAsync(sensor))
                .WithOpenApi()
                .WithDescription("Cria um novo sensor.")
                .Accepts<SensorDTO>("application/json")
                .Produces<SensorDTO>(StatusCodes.Status201Created);

            sensors.MapGet("/", async (ISensorService sensorService, int pagina = 1, int tamanhoPagina = 10) => await sensorService.FindAllPaginadoAsync(pagina, tamanhoPagina))
                .WithOpenApi()
                .WithDescription("Recupera todos os sensores paginado.")
                .Produces<IEnumerable<Sensor>>(StatusCodes.Status200OK);

            sensors.MapGet("/{sensorId}", async (ISensorService sensorService, int sensorId) => await sensorService.GetSensorByIdAsync(sensorId))
                .WithOpenApi()
                .WithDescription("Recupera um sensor específico pelo ID.")
                .Produces<SensorDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            sensors.MapPut("/", async (ISensorService sensorService, SensorDTO sensor) =>
            {
                await sensorService.UpdateSensorAsync(sensor);
            })
                .WithOpenApi()
                .WithDescription("Atualiza um sensor existente.")
                .Accepts<SensorDTO>("application/json")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            sensors.MapDelete("/{sensorId}", async (ISensorService sensorService, int sensorId) => await sensorService.DeleteSensorAsync(sensorId))
                .WithOpenApi()
                .WithDescription("Exclui um sensor existente.")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            #endregion
        }
    }
}
