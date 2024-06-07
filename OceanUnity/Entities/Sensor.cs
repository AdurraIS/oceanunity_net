using System.ComponentModel.DataAnnotations;

namespace oceanunity.entities;

public class Sensor
{
    [Key]
    public long id_sensor { get; set; }
    public string modelo_sensor { get; set; }
    public string status_sensor { get; set; }
    public string fabricante_sensor { get; set; }
    public DateTime data_instalacao_sensor { get; set; }

    public Sensor(long id_sensor, string modelo_sensor, string status_sensor, string fabricante_sensor, DateTime data_instalacao_sensor)
    {
        this.id_sensor = id_sensor;
        this.modelo_sensor = modelo_sensor;
        this.status_sensor = status_sensor;
        this.fabricante_sensor = fabricante_sensor;
        this.data_instalacao_sensor = data_instalacao_sensor;
    }
}