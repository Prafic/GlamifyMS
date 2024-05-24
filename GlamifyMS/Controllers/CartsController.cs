using FinalProject.Models;
using FinalProject.Repository.CartRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICart cartRepo;

        public CartsController(ICart cartRepo)
        {
            this.cartRepo = cartRepo;
        }

        // GET: api/Carts
        [HttpGet]
        //[Authorize(Roles ="Admin")]
        [Route("GetCartItems")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts(int userId)
        {
            var result = cartRepo.GetAllCartItems(userId);
            return Ok(result);
        }



        [HttpPut]
        [Route("UpdateCartItemsDatabase")]
       // [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateCartDatabase(int userId, [FromBody] ShoppingCartUpdate[] cartItems)
        {
            try
            {
                cartRepo.UpdateCartItemDB(userId, cartItems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(cartItems);
        }

        [HttpPost]
        [Route("AddItemToCart")]
        public async Task<ActionResult<Cart>> PostCart(int productId, int userId)
        {
            var result = await cartRepo.AddToCart(productId, userId);


            return Ok(result);
        }

        // DELETE: api/Carts/5
        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> RemoveItem(int productId, int userId)
        {
            var cart = await cartRepo.RemoveItem(productId, userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok("Item removed from Cart");

        }

        [HttpGet]
        [Route("TotalPrice")]
        public ActionResult<int> GetTotalPrice(int userId)
        {
            var result = cartRepo.GetToTalPrice(userId);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateItem")]
        public IActionResult UpdateItem(int userId, int productId, int quantity)
        {
            cartRepo.UpdateItem(userId, productId, quantity);
            return Ok("Updated successfully!");
        }

        [HttpDelete]
        [Route("EmptyCart")]
        public IActionResult EmptyCart(int userId)
        {
            cartRepo.EmptyCart(userId);
            return Ok("Cart Empty");
        }

        [HttpGet]
        [Route("GetCount")]
        public ActionResult<int> TotalCount(int userId)
        {
            var result = cartRepo.GetCount(userId);
            return Ok(result);
        }
    }
}
