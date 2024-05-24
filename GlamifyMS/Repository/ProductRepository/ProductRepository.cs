using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository.ProductRepository
{
    public class ProductRepository:IProduct
    {
        private readonly FinalDbContext context;

        public ProductRepository(FinalDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await context.Products.FirstOrDefaultAsync(t => t.ProductId == id);
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await context.Products.Where(t => t.CategoryId == categoryId).ToListAsync();
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var result = await context.Products.FirstOrDefaultAsync(t => t.ProductId == id);
            if (result != null)
            {
                result.ProductName = product.ProductName;
                result.ProductDescription = product.ProductDescription;
                result.Price = product.Price;
                result.quantity = product.quantity;
                result.CategoryId = product.CategoryId;

                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public bool ProductExists(int id)
        {
            return context.Products.Any(t => t.ProductId == id);
        }
        public async Task<List<Product>> GetByPrice(int price)
        {
            string filterByPrice = "exec FilterPrdPrice @price = " + price;
            return await context.Products.FromSqlRaw(filterByPrice).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProduct(string productString)
        {
            var result = context.Products.Where(p => p.ProductName.Contains(productString) || p.ProductDescription.Contains(productString));
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var result = await context.Products.FirstOrDefaultAsync(t => t.ProductId == id);
            if (result != null)
            {
                context.Products.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Category> GetCategoriesByCategoryId(int categoryId)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var result = await context.Categories.FirstOrDefaultAsync(t => t.CategoryId == id);
            if (result != null)
            {
                result.CategoryName = category.CategoryName;

                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var result = await context.Categories.FirstOrDefaultAsync(t => t.CategoryId == id);
            if (result != null)
            {
                context.Categories.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public bool CategoryExists(int id)
        {
            return context.Categories.Any(t => t.CategoryId == id);
        }
    }
}
