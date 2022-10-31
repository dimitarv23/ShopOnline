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

        public ProductDto Product { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(ID);
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
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {
                //Log Exception
            }
        }
    }
}
