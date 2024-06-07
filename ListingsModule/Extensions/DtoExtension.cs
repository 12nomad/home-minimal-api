using HomeMinimalApi.ListingsModule.Dto;
using HomeMinimalApi.ListingsModule.Entities;

namespace HomeMinimalApi.ListingsModule.Extensions;

public static class DtoExtension {
    public static ListingResultsDtoV1 AsDtoV1(this Listing listing) {
        return new ListingResultsDtoV1(
            listing.Id,
            listing.Name,
            listing.HostName,
            listing.Description,
            listing.AlternativeLocation,
            listing.Location,
            listing.HostComment,
            listing.Price,
            listing.ImageUri,
            listing.CreatedAt,
            listing.UpdatedAt
        );
    }

    public static ListingResultsDtoV2 AsDtoV2(this Listing listing) {
        return new ListingResultsDtoV2(
            listing.Id,
            listing.Name,
            listing.HostName,
            listing.Description,
            listing.AlternativeLocation,
            listing.Location,
            listing.HostComment,
            listing.Price,
            listing.Price - (listing.Price * .2m),
            listing.ImageUri,
            listing.CreatedAt,
            listing.UpdatedAt
        );
    }
}