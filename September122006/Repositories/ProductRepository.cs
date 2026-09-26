using September122006.Models.Data;
using September122006.Models.Domain;
using September122006.Repositories;

// Remove the duplicate UpdateAsync method that throws NotImplementedException
// Remove the duplicate AddAsync method (keep only the async version)
// Remove the duplicate GetAllAsync and GetByIdAsync methods that throw NotImplementedException

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        // Validate the product before adding
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        // Add the product to the context
        await _context.Products.AddAsync(product);

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the added product
        return product;
    }

    public Task<bool> DeleteAsync(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return Task.FromResult(false);
        }
        else
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = _context.Products.ToList();
        return Task.FromResult<IEnumerable<Product>>(products);
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        var product = _context.Products.Find(id);
        return Task.FromResult(product);
    }

    public Task<bool> UpdateAsync(Product product)
    {
        var existingProduct = _context.Products.Find(product.Id);

        if (existingProduct == null)
        {
            return Task.FromResult(false);
        }
        else
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}