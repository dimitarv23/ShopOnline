using ShopOnline.Models.DTOs;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorage
    {
        public Task<List<CartItemDto>> GetCollection()
        {
            throw new NotImplementedException();
        }

        public Task RemoveCollection()
        {
            throw new NotImplementedException();
        }

        public Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            throw new NotImplementedException();
        }
    }
}
