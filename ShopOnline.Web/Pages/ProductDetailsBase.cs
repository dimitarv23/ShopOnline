using Microsoft.AspNetCore.Components;
using ShopOnline.Models.DTOs;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int ID { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IManageProductsLocalStorage ManageProductsLocalStorage { get; set; }

        [Inject]
        public IManageCartItemsLocalStorage ManageCartItemsLocalStorage { get; set; }

        public ProductDto Product { get; set; }

        public string ErrorMessage { get; set; }

        private List<CartItemDto> ShoppingCartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ManageCartItemsLocalStorage.GetCollection();
                Product = await GetProductByID(ID);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto itemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(itemToAddDto);

                if (cartItemDto != null)
                {
                    ShoppingCartItems.Add(cartItemDto);
                    await ManageCartItemsLocalStorage.SaveCollection(ShoppingCartItems);
                }

                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {
                //Log Exception
                throw;
            }
        }

        private async Task<ProductDto> GetProductByID(int id)
        {
            var productDtos = await ManageProductsLocalStorage.GetCollection();

            if (productDtos != null)
            {
                return productDtos.SingleOrDefault(p => p.ID == id);
            }

            return null;
        }
    }
}
