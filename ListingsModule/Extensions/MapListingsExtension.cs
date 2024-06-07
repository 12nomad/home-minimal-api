using HomeMinimalApi.Common.Auth.Enums;
using HomeMinimalApi.ListingsModule.Dto;
using HomeMinimalApi.ListingsModule.Entities;
using HomeMinimalApi.ListingsModule.Interfaces;

namespace HomeMinimalApi.ListingsModule.Extensions;

public static class MapListingsExtension {
    public static RouteGroupBuilder? MapListings(this IEndpointRouteBuilder application) {
        var group = application
                                .NewVersionedApi()
                                .MapGroup("/v{version:apiVersion}/listings")
                                .HasApiVersion(1.0)
                                .HasApiVersion(2.0)
                                .WithParameterValidation();

        group.MapGet("/", async (IListingRepository listingRepository) => {
            var listings = await listingRepository.GetAllAsync();
            return Results.Ok(listings.Select(listing => listing.AsDtoV1()));
        })
        .MapToApiVersion(1.0);

        group.MapGet("/{id}", async (IListingRepository listingRepository, int id) => {
            var listing = await listingRepository.GetAsync(id);

            if (listing is null) return Results.NotFound();

            return Results.Ok(listing.AsDtoV1());
        })
        .WithName("GetListingById")
        .MapToApiVersion(1.0);

        group.MapPost("/", async (IListingRepository listingRepository, CreateListingDto createListingDto) => {
            var listing = new Listing {
                Description = createListingDto.Description,
                HostName = createListingDto.HostName,
                ImageUri = createListingDto.ImageUri,
                Location = createListingDto.Location,
                Name = createListingDto.Name,
                Price = createListingDto.Price,
                AlternativeLocation = createListingDto.AlternativeLocation,
                HostComment = createListingDto.HostComment,
                CreatedAt = new DateTime(),
                UpdatedAt = new DateTime(),
            };

            var newListing = await listingRepository.CreateAsync(listing);
            return Results.CreatedAtRoute("GetListingById", new { id = newListing.Id }, newListing.AsDtoV1());
        })
        .MapToApiVersion(1.0);

        group.MapPut("/{id}", async (IListingRepository listingRepository, int id, UpdateListingDto updateListingDto) => {
            var listing = await listingRepository.GetAsync(id);

            if (listing is null) return Results.NotFound();

            listing.Description = updateListingDto.Description;
            listing.HostName = updateListingDto.HostName;
            listing.ImageUri = updateListingDto.ImageUri;
            listing.Location = updateListingDto.Location;
            listing.Name = updateListingDto.Name;
            listing.Price = updateListingDto.Price;
            listing.UpdatedAt = new DateTime();
            listing.AlternativeLocation = String.IsNullOrWhiteSpace(updateListingDto.AlternativeLocation) ? listing.AlternativeLocation : updateListingDto.AlternativeLocation;
            listing.HostComment = String.IsNullOrWhiteSpace(updateListingDto.HostComment) ? listing.HostComment : updateListingDto.HostComment;

            await listingRepository.UpdateAsync(listing);
            return Results.Ok(listing.AsDtoV1());
        })
        .MapToApiVersion(1.0);

        group.MapDelete("/{id}", async (IListingRepository listingRepository, int id) => {
            var listing = await listingRepository.GetAsync(id);

            if (listing is null) return Results.NotFound();

            await listingRepository.DeleteAsync(listing.Id);
            return Results.NoContent();
        })
        .RequireAuthorization(Policies.WRITE_ACCESS.ToString())
        .MapToApiVersion(1.0);

        return group;
    }
}