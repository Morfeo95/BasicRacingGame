
using System.Text.Json;

public class EstadisticasRepository
{
    public void GuardarResultados(ResultadoCarrera resultado)
    {
        string ruta = "resultados.json";
        List<ResultadoCarrera> resultados;

        if (File.Exists(ruta))
        {
            string jsonExistente = File.ReadAllText(ruta);
            resultados = JsonSerializer.Deserialize<List<ResultadoCarrera>>(jsonExistente) ?? new List<ResultadoCarrera>();
        }
        else
        {
            resultados = new List<ResultadoCarrera>();
        }

        resultados.Add(resultado);

        string json = JsonSerializer.Serialize(resultados, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ruta, json);
    }
    public Dictionary<string, double> ObtenerPromedios()
{
    string ruta = "resultados.json";
    if (!File.Exists(ruta))
        return new Dictionary<string, double>();

    string json = File.ReadAllText(ruta);
    List<ResultadoCarrera> resultados = JsonSerializer.Deserialize<List<ResultadoCarrera>>(json) ?? new List<ResultadoCarrera>();

    var suma = new Dictionary<string, double>();
    var conteo = new Dictionary<string, int>();

    foreach (var resultado in resultados)
    {
        if (resultado.distancias != null)
        {
            foreach (var distancia in resultado.distancias)
            {
                if (!suma.ContainsKey(distancia.Key))
                {
                    suma[distancia.Key] = 0;
                    conteo[distancia.Key] = 0;
                }
                suma[distancia.Key] += distancia.Value;
                conteo[distancia.Key]++;
            }
        }
    }

    var promedios = new Dictionary<string, double>();
    foreach (var nombre in suma.Keys)
    {
        promedios[nombre] = suma[nombre] / conteo[nombre];
    }

    return promedios;
}

    internal int ObtenerTotalCarreras()
    {
        string ruta = "resultados.json";
        if (!File.Exists(ruta))
        {
            return 0;
        }

        string json = File.ReadAllText(ruta);
        List<ResultadoCarrera> resultados = JsonSerializer.Deserialize<List<ResultadoCarrera>>(json) ?? new List<ResultadoCarrera>();

        return resultados.Count;
    }

    internal Dictionary<string, int> ObtenerVecesGanadasPorVehiculo()
    {
        string ruta = "resultados.json";
        if (!File.Exists(ruta))
        {
            return new Dictionary<string, int>();
        }

        string json = File.ReadAllText(ruta);
        List<ResultadoCarrera> resultados = JsonSerializer.Deserialize<List<ResultadoCarrera>>(json) ?? new List<ResultadoCarrera>();

        Dictionary<string, int> vecesGanadas = new Dictionary<string, int>();

        foreach (var resultado in resultados)
        {
            if (!string.IsNullOrEmpty(resultado.ganador))
            {
                if (!vecesGanadas.ContainsKey(resultado.ganador))
                {
                    vecesGanadas[resultado.ganador] = 0;
                }
                vecesGanadas[resultado.ganador]++;
            }
        }

        return vecesGanadas;
    }
}