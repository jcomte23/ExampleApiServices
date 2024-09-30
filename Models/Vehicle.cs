using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleApiServices.Models;

[Table("vehicles")]
public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("make")]
    public required string Make { get; set; }

    [Column("model")]
    public required string Model { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("color")]
    public required string Color { get; set; }
}
