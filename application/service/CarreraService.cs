
public class CarreraService
{
    public Random random { get; set; }
    public CarreraService(Random random)
    {
        this.random = random;
    }
    public List<List<Vehiculo>> IniciarCarrera(Carrera carrera)
    {
        List<List<Vehiculo>> estadosPorTurno = new List<List<Vehiculo>>();
        RandomEventGenerator randomEventGenerator = new RandomEventGenerator(random);
        EstadisticasRepository estadisticasRepository = new EstadisticasRepository();

        while (!carrera.HaFinalizado)
        {
            // Clona el estado actual antes de avanzar
            List<Vehiculo> estadoActual = carrera.Participantes
                .Select(p => (Vehiculo)p.Clone())
                .ToList();
            estadosPorTurno.Add(estadoActual);

            foreach (Vehiculo participante in carrera.Participantes)
            {
                participante.Avanzar(randomEventGenerator);
            }

            if (carrera.Participantes.Any(p => p.distaciaRecorrida >= carrera.Distancia))
            {
                carrera.HaFinalizado = true;
                // Guarda el estado final después de avanzar
                List<Vehiculo> estadoFinal = carrera.Participantes
                    .Select(p => (Vehiculo)p.Clone())
                    .ToList();
                estadosPorTurno.Add(estadoFinal);
            }
        }
        estadisticasRepository.GuardarResultados(new ResultadoCarrera(carrera.ObtenerGanador().nombre, carrera.obtenerDistancias()));
        return estadosPorTurno;
    }

    public Estadisticas CalcularEstadisticas()
    {
        EstadisticasRepository repo = new EstadisticasRepository();
        Estadisticas estadisticas = new Estadisticas();

        estadisticas.VecesGanadasPorVehiculo = repo.ObtenerVecesGanadasPorVehiculo();

        Dictionary<string, double> promedios = repo.ObtenerPromedios();
        foreach (var promedio in promedios)
        {
            estadisticas.PromedioTiemposPorVehiculo[promedio.Key] = promedio.Value;
        }

        estadisticas.TotalCarreras = repo.ObtenerTotalCarreras();
        
        return estadisticas;
    }
}