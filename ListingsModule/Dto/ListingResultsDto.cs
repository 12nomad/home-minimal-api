namespace HomeMinimalApi.ListingsModule.Dto;

public record ListingResultsDtoV1(
    int Id,
    string Name,
    string HostName,
    string Description,
    string? AlternativeLocation,
    string Location,
    string? HostComment,
    decimal Price,
    string ImageUri,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record ListingResultsDtoV2(
    int Id,
    string Name,
    string HostName,
    string Description,
    string? AlternativeLocation,
    string Location,
    string? HostComment,
    decimal Price,
    decimal MemberPrice,
    string ImageUri,
    DateTime CreatedAt,
    DateTime UpdatedAt
);