using RentACar.Models.Entities.Concreate;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int id { get; set; }

    [Required]
    public string plate { get; set; }

    [Required]
    public int dailyPrice { get; set; }

    // CarModel ile olan ilişki
    public int modelId { get; set; }

    [ForeignKey("modelId")]

    public CarModel model { get; set; }

    // Brand ile olan ilişki (Yeni Eklendi)
    public int brandId { get; set; }
    [ForeignKey("brandId")]

    public Brand brand { get; set; }
}
