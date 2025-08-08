
public class Humano : Vehiculo
{
    public Humano(Random random)
        : base(random)
    {
        string[] colores = { "Piel Clara", "Piel Oscura", "Piel Media" };
        ColorAlAzar(random, colores);
        string[] nombres = { "Juan", "María", "Carlos", "Ana", "Luis" };
        NombreAlAzar(random, nombres);
        VelocidadBaseAlAzar(random, 5, 15);
        ProbabilidadFalloAlAzar(random, 0.2, 0.4);
        avatar = @"
  O
 /|\
 / \
";
    }
}

