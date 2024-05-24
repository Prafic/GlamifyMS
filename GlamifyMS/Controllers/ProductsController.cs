using FinalProject.Models;
using FinalProject.Repository.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct productRepo;

        public ProductsController(IProduct productRepo)
        {
            this.productRepo = productRepo;
        }

        // GET: api/Products
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await productRepo.GetAllProducts();
            //if (result != null)
            //{
            //    return Ok(result);
            //}
            //return NoContent();
            return Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await productRepo.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {

            try
            {
                await productRepo.UpdateProduct(id, product);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var result = await productRepo.AddProduct(product);

            return Ok(result);
            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productRepo.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return productRepo.ProductExists(id);
        }

        [HttpGet]
        [Route("search/{searchItem}")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProductByNameOrDesc(string searchItem)
        {
            var result = await productRepo.SearchProduct(searchItem);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("GetAllProductsByCategoryId")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategoryId(int categoryId)
        {
            var result = await productRepo.GetProductsByCategoryId(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
