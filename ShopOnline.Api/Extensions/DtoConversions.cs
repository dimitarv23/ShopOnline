using ShopOnline.Api.Entities;
using ShopOnline.Models.DTOs;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> productCategories)
        {
            return (from productCategory in productCategories
                    select new ProductCategoryDto
                    {
                        ID = productCategory.ID,
                        Name = productCategory.Name,
                        IconCSS = productCategory.IconCSS,
                    }).ToList();
        }

        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        ID = product.ID,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CategoryID = product.ProductCategory.ID,
                        CategoryName = product.ProductCategory.Name
                    }).ToList();
        }

        public static ProductDto ConvertToDto(this Product product)
        {
            return new ProductDto
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryID = product.ProductCategory.ID,
                CategoryName = product.ProductCategory.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                                IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductID equals product.ID
                    select new CartItemDto
                    {
                        ID = cartItem.ID,
                        ProductID = cartItem.ProductID,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartID = cartItem.CartID,
                        Quantity = cartItem.Quantity,
                        TotalPrice = product.Price * cartItem.Quantity
                    }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                    Product product)
        {
            return new CartItemDto
            {
                ID = cartItem.ID,
                ProductID = cartItem.ProductID,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                CartID = cartItem.CartID,
                Quantity = cartItem.Quantity,
                TotalPrice = product.Price * cartItem.Quantity
            };
        }
    }
}
