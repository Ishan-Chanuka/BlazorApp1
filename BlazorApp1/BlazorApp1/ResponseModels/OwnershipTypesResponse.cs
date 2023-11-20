using BlazorApp1.Models;

namespace BlazorApp1.ResponseModels
{
    public class OwnershipTypesResponse
    {
        public string Message { get; set; }
        public IEnumerable<OwnerShipTypes> Data { get; set; }
    }
}
