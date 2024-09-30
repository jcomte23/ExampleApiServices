using System.ComponentModel.DataAnnotations;

namespace ExampleApiServices.DTOs;

public class VehicleDTO
{
    [Required(ErrorMessage = "La marca es obligatoria.")]
    [StringLength(50, ErrorMessage = "La marca no puede exceder los 50 caracteres.")]
    public required string Make { get; set; }

    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El modelo no puede exceder los 50 caracteres.")]
    public required string Model { get; set; }

    [Range(1970, 2025, ErrorMessage = "El año debe estar entre 1970 y el año de hoy.")]
    public int Year { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "El color es obligatorio.")]
    [StringLength(30, ErrorMessage = "El color no puede exceder los 30 caracteres.")]
    public required string Color { get; set; }
}
