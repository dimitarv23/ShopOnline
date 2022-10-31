using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.DTOs;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepo;
        private readonly IProductRepository _productRepo;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepo, IProductRepository productRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("{usedID}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userID)
        {
            try
            {
                var cartItems = await _shoppingCartRepo.GetItems(userID);

                if (cartItems == null)
                {
                    return NoContent();
                }

                var products = await _productRepo.GetItems();

                if (products == null)
                {
                    throw new Exception("No products exist in the system");
                }

                var cartItemsDto = cartItems.ConvertToDto(products);
                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _shoppingCartRepo.GetItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await _productRepo.GetItem(cartItem.ProductID);

                if (product == null)
                {
                    return NotFound();
                }

                var cartItemDto = cartItem.ConvertToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto itemToAddDto)
        {
            try
            {
                var newCartItem = await _shoppingCartRepo.AddItem(itemToAddDto);

                if (newCartItem == null)
                {
                    return NoContent();
                }

                var product = await _productRepo.GetItem(newCartItem.ProductID);

                if (product == null)
                {
                    throw new Exception($"Something went wrong while attempting to retrieve product (productID: {itemToAddDto.ProductID})");
                }

                var newCartItemDto = newCartItem.ConvertToDto(product);
                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.ID }, newCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
