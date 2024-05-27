using Microsoft.EntityFrameworkCore;
using StoreProcedureCRUD.Data;
using StoreProcedureCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreProcedureCRUD.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC CreateProduct @Name = {product.Name}, @Price = {product.Price}");
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FromSqlInterpolated($"EXEC GetProductById @Id = {id}").FirstOrDefaultAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC UpdateProduct @Id = {product.Id}, @Name = {product.Name}, @Price = {product.Price}");
        }

        public async Task DeleteProductAsync(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC DeleteProduct @Id = {id}");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.FromSqlRaw("EXEC GetProducts").ToListAsync();
        }
    }
}
