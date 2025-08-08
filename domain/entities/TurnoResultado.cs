
public class TurnoResultado
{
  public Vehiculo Vehiculo { get; }
  public int DistanciaRecorrida { get; }
  public bool Fallo { get; }

  public TurnoResultado(Vehiculo vehiculo, int distanciaRecorrida)
  {
      Vehiculo = vehiculo;
      DistanciaRecorrida = distanciaRecorrida;
      Fallo = distanciaRecorrida == 0; // Si la distancia recorrida es 0, se considera que hubo un fallo
  }
}