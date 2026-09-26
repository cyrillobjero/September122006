using September122006.Models.Domain;
using September122006.Models.Dto;
namespace September122006.Services;
public interface IProductService
{
    object Products { get; }

    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductDto input);
    object? CreateAsync(Product product);
}

