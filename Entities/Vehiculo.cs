namespace TestFA.Backend.WebApi.Entities;

public class Vehiculo
{
    public int Vehiculo_Id { get; set; }
    public string Vehiculo_Placa { get; set; }
    public int Vehiculo_Color { get; set; }
    public int Vehiculo_Marca { get; set; }
    public string Vehiculo_Linea { get; set; }
    public int Vehiculo_Anio { get; set; }
    public int Vehiculo_Km { get; set; }
    public double Vehiculo_Valor { get; set; }
    public string Vehiculo_Observaciones { get; set; }
    public int Vehiculo_Fase { get; set; }
    public IEnumerable<string> Vehiculo_Fotos { get; set; }
}
