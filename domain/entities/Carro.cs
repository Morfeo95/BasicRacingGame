public class Carro : Vehiculo
{
    public Carro(Random random)
        : base(random)
    {
        string[] colores = { "Rojo", "Azul", "Verde", "Amarillo" };
        ColorAlAzar(random, colores);
        string[] nombres = { "Mercedez", "Ferrari", "Lamborghini", "Porsche", "Audi" };
        NombreAlAzar(random, nombres);
        VelocidadBaseAlAzar(random, 50, 100);
        ProbabilidadFalloAlAzar(random, 0.05, 0.15);
        avatar = @"
      ______
     /|_||_\`.__
    (   _    _ _\
    =`-(_)--(_)-'
";
    }

}