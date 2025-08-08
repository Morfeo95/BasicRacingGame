
using System.Text.Json.Serialization;

public class ResultadoCarrera
{
    public string? ganador { get; set; }
    public Dictionary<string, int>? distancias { get; set; }

    public ResultadoCarrera() { }

    [JsonConstructor]
    public ResultadoCarrera(string ganador, Dictionary<string, int> distancias)
    {
        this.ganador = ganador;
        this.distancias = distancias;
    }

    public ResultadoCarrera(Vehiculo ganador, Dictionary<Vehiculo, int> tiempos)
    {
        this.ganador = ganador.nombre;
        this.distancias = new Dictionary<string, int>();
        foreach (var kvp in tiempos)
        {
            this.distancias[kvp.Key.nombre] = kvp.Value;
        }
    }
}