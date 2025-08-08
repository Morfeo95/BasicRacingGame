
public abstract class Vehiculo : ICloneable
{
    public string nombre { get; set; } = string.Empty;
    public string color { get; set; } = string.Empty;
    public int velocidadBase { get; set; }
    public double probabilidadFallo { get; set; }
    public int distaciaRecorrida { get; set; }
    public string avatar { get; set; } = string.Empty;
    public RandomEventGenerator randomEventGenerator { get; set; }

    public Vehiculo(Random random)
    {
        this.randomEventGenerator = new RandomEventGenerator(random);
        this.distaciaRecorrida = 0;
    }

    protected void ProbabilidadFalloAlAzar(Random random, double probabilidadFalloMinima, double probabilidadFalloMaxima)
    {
        probabilidadFallo = random.NextDouble() * (probabilidadFalloMaxima - probabilidadFalloMinima) + probabilidadFalloMinima;
    }

    protected void VelocidadBaseAlAzar(Random random, int velocidadMinima, int velocidadMaxima)
    {
        velocidadBase = random.Next(velocidadMinima, velocidadMaxima + 1);
    }

    protected void NombreAlAzar(Random random, string[] nombresValidos)
    {
        nombre = nombresValidos[random.Next(nombresValidos.Length)];
    }

    protected void ColorAlAzar(Random random, string[] coloresValidos)
    {
        color = coloresValidos[random.Next(coloresValidos.Length)];
    }

    public int Avanzar(RandomEventGenerator randomEventGenerator)
    
    {
        if (randomEventGenerator.GenerarFallo(probabilidadFallo))
        {
            return 0;
        }

        int distanciaAvanzada = (int)(velocidadBase * randomEventGenerator.GenerarFactorAleatorio());
        distaciaRecorrida += distanciaAvanzada;
        return distanciaAvanzada;
    }

    public void Reiniciar()
    {
        distaciaRecorrida = 0;
    }

    public override string ToString()
    {
        return $"{avatar} \n {nombre} ({color}) - Distancia recorrida: {distaciaRecorrida}m";
    }

    public object Clone()
    {
        Vehiculo clone = (Vehiculo)this.MemberwiseClone();
        clone.randomEventGenerator = this.randomEventGenerator;
        return clone;
    }
}