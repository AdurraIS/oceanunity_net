
using Microsoft.EntityFrameworkCore;
using oceanunity.data;
using oceanunity.dto;
using oceanunity.entities;
using oceanunity.Services;

namespace oceanunity.services
{
    public class SensorService : ISensorService // Consider adding an interface
    {
        private readonly SensorContext _context;

        public SensorService(SensorContext context)
        {
            _context = context;
        }

        #region CRUD

        public async Task<IResult> CreateSensorAsync(SensorDTO sensor)
        {
            if (sensor == null)
            {
                return TypedResults.BadRequest("Dados do sensor inválidos.");
            }
            Sensor sensorObj = new Sensor(sensor.id_sensor, sensor.modelo_sensor, sensor.status_sensor
            , sensor.fabricante_sensor, sensor.data_instalacao_sensor);
                _context.Sensores.Add(sensorObj);
                await _context.SaveChangesAsync();
                return TypedResults.Created($"/sensors/{sensor.id_sensor}", sensor);
        }

        public async Task<IResult> GetSensorByIdAsync(long sensorId)
        {
            if (sensorId <= 0)
            {
                return TypedResults.BadRequest("ID do sensor inválido.");
            }

            var sensor = await _context.Sensores.FindAsync(sensorId);

            if (sensor == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(sensor);
        }

        public async Task<IResult> UpdateSensorAsync(SensorDTO sensor)
        {
            if (sensor == null || sensor.id_sensor
             <= 0)
            {
                return TypedResults.BadRequest("Dados do sensor inválidos.");
            }

            var existingSensor = await _context.Sensores.FindAsync(sensor.id_sensor);

            if (existingSensor == null)
            {
                return TypedResults.NotFound();
            }

            existingSensor.modelo_sensor = sensor.modelo_sensor;
            existingSensor.status_sensor = sensor.status_sensor;
            existingSensor.fabricante_sensor = sensor.fabricante_sensor;
            existingSensor.data_instalacao_sensor = sensor.data_instalacao_sensor;
                await _context.SaveChangesAsync();
                return TypedResults.Ok(sensor);

        }

        public async Task<IResult> DeleteSensorAsync(long sensorId)
        {
            if (sensorId <= 0)
            {
                return TypedResults.BadRequest("ID do sensor inválido.");
            }

            var sensor = await _context.Sensores.FindAsync(sensorId);

            if (sensor == null)
            {
                return TypedResults.NotFound();
            }

            _context.Sensores.Remove(sensor);
                await _context.SaveChangesAsync();
                return TypedResults.Ok();
        }

        #endregion

        #region findAllPaginado

        public async Task<IResult> FindAllPaginadoAsync(int pagina, int tamanhoPagina)
        {
            if (pagina <= 0 || tamanhoPagina <= 0)
            {
                return TypedResults.BadRequest("Parâmetros de paginação inválidos.");
            }

            int skip = (pagina - 1) * tamanhoPagina;

            var sensores = await _context.Sensores
                .Skip(skip)
                .Take(tamanhoPagina)
                .ToListAsync();

            return TypedResults.Ok(sensores);
        }
        #endregion
    }
}
