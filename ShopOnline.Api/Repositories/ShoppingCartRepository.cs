using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.DTOs;

namespace ShopOnline.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopOnlineDbContext _db;

        public ShoppingCartRepository(ShopOnlineDbContext db)
        {
            _db = db;
        }

        private async Task<bool> CartItemExists(int cartID, int productID)
        {
            return await _db.CartItems.AnyAsync(c => c.CartID == cartID && c.ProductID == productID);
        }

        public async Task<CartItem> AddItem(CartItemToAddDto itemToAddDto)
        {
            if (await CartItemExists(itemToAddDto.CartID, itemToAddDto.ProductID) == false)
            {
                var item = await (from product in _db.Products
                                  where product.ID == itemToAddDto.ProductID
                                  select new CartItem
                                  {
                                      CartID = itemToAddDto.CartID,
                                      ProductID = product.ID,
                                      Quantity = itemToAddDto.Quantity
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await _db.CartItems.AddAsync(item);
                    await _db.SaveChangesAsync();

                    return result.Entity;
                }
            }

            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await _db.CartItems.FindAsync(id);

            if (item != null)
            {
                _db.CartItems.Remove(item);
                await _db.SaveChangesAsync();
            }

            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in _db.Carts
                          join cartItem in _db.CartItems
                          on cart.ID equals cartItem.CartID
                          where cartItem.ID == id
                          select new CartItem
                          {
                              ID = cartItem.ID,
                              ProductID = cartItem.ProductID,
                              Quantity = cartItem.Quantity,
                              CartID = cartItem.CartID
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userID)
        {
            return await (from cart in _db.Carts
                          join cartItem in _db.CartItems
                          on cart.ID equals cartItem.CartID
                          where cart.UserID == userID
                          select new CartItem
                          {
                              ID = cartItem.ID,
                              ProductID = cartItem.ProductID,
                              Quantity = cartItem.Quantity,
                              CartID = cartItem.CartID
                          }).ToListAsync();
        }

        public Task<CartItem> UpdateQuantity(int id, CartItemQuantityUpdateDto itemQuantityUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
