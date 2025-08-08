public class ConsoleUI
{
    private List<Vehiculo> participantes = new List<Vehiculo>();
    private bool salir = false;
    public Random random { get; set; } = new Random();
    private int distancia = 1000; // Distancia total de la carrera en metros
    private CarreraService carreraService;

    public ConsoleUI()
    {
        carreraService = new CarreraService(random);
    }

    public void MostrarMenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al simulador de Carreras");
            Console.WriteLine("1. Iniciar Carrera");
            Console.WriteLine("2. Salir");
            Console.WriteLine("3. Ver Estadisticas de las Carreras");
            Console.WriteLine("4. Opciones de Carrera");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Seleccion();
                    break;
                case "2":
                    Console.WriteLine("Saliendo del simulador...");
                    salir = true;
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Estadísticas de las Carreras:");
                    var estadisticas = carreraService.CalcularEstadisticas();
                    Console.WriteLine($"Total de Carreras: {estadisticas.TotalCarreras}");
                    Console.WriteLine("Veces Ganadas por Vehículo:");
                    foreach (var item in estadisticas.VecesGanadasPorVehiculo)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    Console.WriteLine("Promedio de Distancia recorrida por Vehículo:");
                    foreach (var item in estadisticas.PromedioTiemposPorVehiculo)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value:F2} metros");
                    }
                    Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                    Console.ReadKey();
                    salir = false;
                    break;

                case "4":
                    Console.WriteLine("Opciones de Carrera:");
                    Console.WriteLine("1. Cambiar distancia de la carrera");
                    Console.WriteLine("2. Volver al menú principal");
                    Console.Write("Seleccione una opción: ");
                    string? opcionCarrera = Console.ReadLine();
                    if (opcionCarrera == "1")
                    {
                        Console.Write("Ingrese la nueva distancia de la carrera en metros: ");
                        if (int.TryParse(Console.ReadLine(), out int nuevaDistancia) && nuevaDistancia > 0)
                        {
                            distancia = nuevaDistancia;
                            Console.WriteLine($"Distancia de la carrera actualizada a {distancia} metros.");
                        }
                        else
                        {
                            Console.WriteLine("Distancia no válida. Volviendo al menú principal.");
                        }
                    }
                    System.Threading.Thread.Sleep(2000); // Pausa para que el usuario lea el mensaje
                    salir = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    salir = false;
                    break;
            }
        } while (!salir);

    }
    private void Seleccion()
    {
        participantes.Clear();
        do
        {
            Console.Clear();
            Console.WriteLine("Seleccione a los 5 participantes de la carrera:");
            Console.WriteLine($"Participantes seleccionados: {participantes.Count}/5");
            Console.WriteLine("Distancia de la carrera: " + distancia + " metros");
            Console.WriteLine("1. Avión\n2. Caballo\n3. Humano\n4. Carro\n5. Cancelar");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    participantes.Add(new Avion(random));
                    break;
                case "2":
                    participantes.Add(new Caballo(random));
                    break;
                case "3":
                    participantes.Add(new Humano(random));
                    break;
                case "4":
                    participantes.Add(new Carro(random));
                    break;
                case "5":
                    Console.WriteLine("Saliendo del simulador...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    return;
            }
        } while (participantes.Count < 5);
        Console.WriteLine("5 participantes seleccionados. Iniciando carrera...");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        var estadosPorTurno = carreraService.IniciarCarrera(new Carrera(distancia, participantes));
        ImprimirCarrera(estadosPorTurno, distancia);
    }

    public void ImprimirCarrera(List<List<Vehiculo>> estadosPorTurno, int distanciaTotal)
    {
        int anchoPista = 50;

        for (int turno = 0; turno < estadosPorTurno.Count; turno++)
        {
            Console.Clear();
            Console.WriteLine($"Turno {turno + 1}:");

            foreach (var participante in estadosPorTurno[turno])
            {
                int posicion = Math.Min(participante.distaciaRecorrida * anchoPista / distanciaTotal, anchoPista - 1);
                string pista = new string('-', posicion) + participante.nombre[0] + new string('-', anchoPista - 1 - posicion);
                Console.WriteLine($"{participante.nombre.PadRight(12)}({participante.color[0..2]}) |{pista}| {participante.distaciaRecorrida}m");
            }

            System.Threading.Thread.Sleep(1500); // Pausa de 1.5 segundos entre turnos
        }

        // Mostrar ganador
        var ultimoTurno = estadosPorTurno.Last();
        var ganador = ultimoTurno.OrderByDescending(p => p.distaciaRecorrida).First();
        Console.Clear();
        Console.WriteLine($"\n ganador de la carrera!\n{ganador} ");

        Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
        Console.ReadKey();
        participantes.Clear();
    }
}