using System.ComponentModel.DataAnnotations;

namespace TestFA.Backend.WebApi.Models;

public class VehiculoCreateRequest
{
    [Required]
    public string Vehiculo_Placa { get; set; }
    [Required]
    public int Vehiculo_Color { get; set; }
    [Required]
    public int Vehiculo_Marca { get; set; }
    [Required]
    public string Vehiculo_Linea { get; set; }
    [Required]
    public int Vehiculo_Anio { get; set; }
    [Required]
    public int Vehiculo_Km { get; set; }
    [Required]
    public double Vehiculo_Valor { get; set; }
    [Required]
    public string Vehiculo_Observaciones { get; set; }
    [Required]
    public int Vehiculo_Fase { get; set; }
    [Required]
    public IEnumerable<string> Vehiculo_Fotos { get; set; }
}

public class VehiculoUpdateRequest
{
    [Required]
    public int Vehiculo_Id { get; set; }
    [Required]
    public string Vehiculo_Placa { get; set; }
    [Required]
    public int Vehiculo_Color { get; set; }
    [Required]
    public int Vehiculo_Marca { get; set; }
    [Required]
    public string Vehiculo_Linea { get; set; }
    [Required]
    public int Vehiculo_Anio { get; set; }
    [Required]
    public int Vehiculo_Km { get; set; }
    [Required]
    public double Vehiculo_Valor { get; set; }
    [Required]
    public string Vehiculo_Observaciones { get; set; }
    [Required]
    public int Vehiculo_Fase { get; set; }
    [Required]
    public IEnumerable<string> Vehiculo_Fotos { get; set; }
}
