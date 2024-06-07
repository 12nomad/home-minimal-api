using HomeMinimalApi.ListingsModule.Entities;

namespace HomeMinimalApi.ListingsModule.Interfaces;

public interface IListingRepository {
    Task<IEnumerable<Listing>> GetAllAsync();

    Task<Listing?> GetAsync(int id);

    Task<Listing> CreateAsync(Listing listing);

    Task UpdateAsync(Listing listing);

    Task DeleteAsync(int id);
}