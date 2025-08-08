
public class Caballo : Vehiculo
{
    public Caballo(Random random)
        : base(random)
    {
        string[] colores = { "Blanco", "Negro", "Marrón", "Gris" };
        ColorAlAzar(random, colores);
        string[] nombres = { "Relámpago", "Tornado", "Centella", "Furia", "Sardinilla" };
        NombreAlAzar(random, nombres);
        VelocidadBaseAlAzar(random, 10, 20);
        ProbabilidadFalloAlAzar(random, 0.1, 0.3);
        avatar = @"
           .''
  ._.-.___.' (`\
 //(        ( `'
'/ )\ ).__. ) 
' <' `\ ._/'\
   `   \     \\
";
    }
}
