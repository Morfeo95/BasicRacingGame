
using System.ComponentModel.Design;

public class Carrera
{
    public int Distancia { get; private set; }

    public List<Vehiculo> Participantes { get; private set; }
    public bool HaFinalizado { get; internal set; } = false;

    public Carrera(int distancia, List<Vehiculo> participantes)
    {
        Distancia = distancia;
        Participantes = participantes;
    }

    public IEnumerable<TurnoResultado> SimularTurno(){
        List<TurnoResultado> resultados = new List<TurnoResultado>();
        foreach (Vehiculo participante in Participantes)
        {
            int distanciaRecorrida = participante.Avanzar(participante.randomEventGenerator);
            resultados.Add(new TurnoResultado(participante, distanciaRecorrida));
        }
        return resultados;
    }

    public Vehiculo ObtenerGanador()
    {
        return Participantes.OrderByDescending(p => p.distaciaRecorrida).First();
    }

    public Dictionary<string, int> obtenerDistancias()
{
    var clavesUsadas = new Dictionary<string, int>();
    var dict = new Dictionary<string, int>();

    foreach (var p in Participantes)
    {
        string baseClave = $"Nombre: {p.nombre} Color:({p.color[0..2]})";
        string clave = baseClave;

        if (clavesUsadas.ContainsKey(baseClave))
        {
            clavesUsadas[baseClave]++;
            clave = $"{baseClave}_{clavesUsadas[baseClave]}";
        }
        else
        {
            clavesUsadas[baseClave] = 1;
        }

        dict[clave] = p.distaciaRecorrida;
    }
    return dict;
}
}
