public class Avion : Vehiculo
{
    public Avion(Random random)
        : base(random)
    {
        string[] colores = { "Blanco", "Azul", "Gris", "Rojo" };
        ColorAlAzar(random, colores);
        string[] nombres = { "Jet", "Boeing", "Airbus", "Cessna" };
        NombreAlAzar(random, nombres);
        VelocidadBaseAlAzar(random, 200, 600);
        ProbabilidadFalloAlAzar(random, 0.01, 0.05);
        avatar = @"
          __|__
--@--@--(_)--@--@--
        ";
    }
}