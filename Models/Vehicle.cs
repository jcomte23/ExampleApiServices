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
    public string Make { get; set; }

    [Column("model")]
    public string Model { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("color")]
    public string Color { get; set; }


    public Vehicle(string make, string model, int year, double price, string color)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
        Color = color;
    }
}
