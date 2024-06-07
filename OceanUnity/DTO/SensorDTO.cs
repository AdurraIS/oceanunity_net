namespace oceanunity.dto;

[Serializable]
public record SensorDTO(long id_sensor, string modelo_sensor, string status_sensor, string fabricante_sensor, DateTime data_instalacao_sensor);