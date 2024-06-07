using System.ComponentModel.DataAnnotations;

namespace HomeMinimalApi.ListingsModule.Dto;

public record UpdateListingDto(
    [Required]
    [StringLength(50)]
    string Name,

    [Required]
    [StringLength(20)]
    string HostName,

    [Required]
    [StringLength(250)]
    string Description,

    [StringLength(50)]
    string? AlternativeLocation,

    [Required]
    [StringLength(50)]
    string Location,

    [StringLength(150)]
    string? HostComment,

    [Required]
    [Range(1, 10_000)]
    decimal Price,

    [Required]
    [Url]
    string ImageUri
);