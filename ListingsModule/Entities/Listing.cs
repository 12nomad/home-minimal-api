using System.ComponentModel.DataAnnotations;

namespace HomeMinimalApi.ListingsModule.Entities;

public class Listing {
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string HostName { get; set; }

    [Required]
    [StringLength(250)]
    public required string Description { get; set; }

    [StringLength(50)]
    public string? AlternativeLocation { get; set; }

    [Required]
    [StringLength(50)]
    public required string Location { get; set; }

    [StringLength(150)]
    public string? HostComment { get; set; }

    [Required]
    [Range(1, 10_000)]
    public required decimal Price { get; set; }

    [Required]
    [Url]
    public required string ImageUri { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.Date)]
    public DateTime UpdatedAt { get; set; }
}