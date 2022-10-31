using ShopOnline.Models.DTOs;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CartItemDto> AddItem(CartItemToAddDto itemToAddDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/ShoppingCart", itemToAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CartItemDto>> GetItems(int userID)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/ShoppingCart/{userID}/GetItems");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
