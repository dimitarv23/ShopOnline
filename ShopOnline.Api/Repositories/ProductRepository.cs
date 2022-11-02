using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _db;

        public ProductRepository(ShopOnlineDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _db.ProductCategories.ToListAsync();

            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await _db.ProductCategories.SingleOrDefaultAsync(c => c.ID == id);

            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await _db.Products
                .Include(p => p.ProductCategory)
                .SingleOrDefaultAsync(p => p.ID == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            return await _db.Products
                .Include(p => p.ProductCategory)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            return await _db.Products
                .Include(p => p.ProductCategory)
                .Where(p => p.CategoryID == id)
                .ToListAsync();
        }
    }
}
