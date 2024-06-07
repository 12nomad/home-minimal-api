using HomeMinimalApi.Data;
using HomeMinimalApi.ListingsModule.Entities;
using HomeMinimalApi.ListingsModule.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeMinimalApi.ListingsModule.Repositories;

public class EfListingRepository : IListingRepository {
  private readonly EfCoreDbContext _dbContext;

  public EfListingRepository(EfCoreDbContext dbContext) {
    _dbContext = dbContext;
  }

  public async Task<IEnumerable<Listing>> GetAllAsync() {
    return await _dbContext.Listings.AsNoTracking().ToListAsync();
  }
  public async Task<Listing?> GetAsync(int id) {
    return await _dbContext.Listings.FindAsync(id);
  }

  public async Task<Listing> CreateAsync(Listing listing) {
    _dbContext.Listings.Add(listing);
    await _dbContext.SaveChangesAsync();

    return listing;
  }

  public async Task UpdateAsync(Listing listing) {
    _dbContext.Entry(listing).State = EntityState.Modified;
    await _dbContext.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id) {
    await _dbContext.Listings.Where(listing => listing.Id == id).ExecuteDeleteAsync();
  }
}