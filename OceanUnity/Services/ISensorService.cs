
using oceanunity.dto;
using oceanunity.entities;

namespace oceanunity.Services
{
    public interface ISensorService
    {
        Task<IResult> CreateSensorAsync(SensorDTO sensorDTO);
        Task<IResult> GetSensorByIdAsync(long sensorId);
        Task<IResult> UpdateSensorAsync(SensorDTO sensorDTO);
        Task<IResult> DeleteSensorAsync(long sensorId);
        Task<IResult> FindAllPaginadoAsync(int pagina, int tamanhoPagina);
    }
}
