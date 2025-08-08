
public class RandomEventGenerator
{
    private readonly Random _random;

    public RandomEventGenerator(Random random)
    {
        _random = random;
    }

    public bool GenerarFallo(double probabilidadFallo)
    {
        return _random.NextDouble() < probabilidadFallo;
    }

    internal int GenerarFactorAleatorio()
    {
        // Genera un factor aleatorio entre 0.5 y 1.5
        return (int)(_random.NextDouble() * 1.0 + 0.5);
    }
}