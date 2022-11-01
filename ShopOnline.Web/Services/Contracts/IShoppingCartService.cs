using ShopOnline.Models.DTOs;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>> GetItems(int userID);
        Task<CartItemDto> AddItem(CartItemToAddDto itemToAddDto);
        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateQuantity(CartItemQuantityUpdateDto itemQuantityUpdateDto);
    }
}
