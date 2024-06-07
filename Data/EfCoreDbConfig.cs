using HomeMinimalApi.ListingsModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeMinimalApi.Data;

public class EfCoreDbConfig : IEntityTypeConfiguration<Listing> {
  public void Configure(EntityTypeBuilder<Listing> builder) {
    builder.Property(listing => listing.Price).HasPrecision(5, 2);
  }
}