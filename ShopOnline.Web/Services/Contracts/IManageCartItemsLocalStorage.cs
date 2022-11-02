using ShopOnline.Models.DTOs;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IManageCartItemsLocalStorage
    {
        Task<List<CartItemDto>> GetCollection();
        Task SaveCollection(List<CartItemDto> cartItemDtos);
        Task RemoveCollection();
    }
}
