using Microsoft.AspNetCore.Components;
using ShopOnline.Models.DTOs;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsByCategoryBase : ComponentBase
    {
        [Parameter]
        public int CategoryID { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IManageProductsLocalStorage ManageProductsLocalStorage { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        public string CategoryName { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products = await GetProductCollectionByCategoryID(CategoryID);

                if (Products != null && Products.Count() > 0)
                {
                    var productDto = Products.FirstOrDefault(p => p.CategoryID == CategoryID);

                    if (productDto != null)
                    {
                        CategoryName = productDto.CategoryName;

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async Task<IEnumerable<ProductDto>> GetProductCollectionByCategoryID(int categoryID)
        {
            var productCollection = await ManageProductsLocalStorage.GetCollection();

            if (productCollection != null)
            {
                return productCollection.Where(p => p.CategoryID == categoryID);
            }
            else
            {
                return await ProductService.GetItemsByCategory(categoryID);
            }
        }
    }
}
