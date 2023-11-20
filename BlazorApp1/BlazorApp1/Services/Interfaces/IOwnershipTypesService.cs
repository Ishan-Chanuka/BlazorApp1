using BlazorApp1.Models;

namespace BlazorApp1.Services.Interfaces
{
    public interface IOwnershipTypesService
    {
        Task<IEnumerable<OwnerShipTypes>> GetOwnershipTypesAsync();
    }
}
