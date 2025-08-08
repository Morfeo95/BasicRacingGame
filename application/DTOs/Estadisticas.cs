
using System.Text.Json;

public class Estadisticas
{
    public Dictionary<string, int> VecesGanadasPorVehiculo { get; set; }
    public Dictionary<string, double> PromedioTiemposPorVehiculo { get; set; }
    public int TotalCarreras { get; set; }

    public Estadisticas()
    {
        VecesGanadasPorVehiculo = new Dictionary<string, int>();
        PromedioTiemposPorVehiculo = new Dictionary<string, double>();
        TotalCarreras = 0;
    }
}