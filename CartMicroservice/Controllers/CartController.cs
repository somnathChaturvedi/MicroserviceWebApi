using CartMicroservice.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CartMicroservice.Model;

namespace CartMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartRepository _repo;

        public CartController(CartRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Carts>> GetCart(string userId)
        {
            var cart = await _repo.GetCartAsync(userId);
            if (cart is null)
                return NotFound();
            return cart;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] Carts cart)
        {
            await _repo.SaveCartAsync(cart.UserId, cart);
            return Ok(cart);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCart(string userId)
        {
            await _repo.DeleteCartAsync(userId);
            return NoContent();
        }
    }

}
