using MyBlazorApp.Application.Repositories;
using MyBlazorApp.Model.Entities;

namespace MyBlazorApp.Application.Services;

public interface IProductService
{
    Task<List<ProductModel>> GetProductsAsync();
    Task<ProductModel> GetProductAsync(long productId);
    Task<ProductModel> CreateProductAsync(ProductModel product);
    Task UpdateProductAsync(ProductModel product);
    Task DeleteProductAsync(long productId);
}

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<List<ProductModel>> GetProductsAsync()
    {
        return await productRepository.GetAllAsync();
    }

    public async Task<ProductModel> GetProductAsync(long id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<ProductModel> CreateProductAsync(ProductModel product)
    {
        return await productRepository.CreateAsync(product);
    }

    public Task UpdateProductAsync(ProductModel product)
    {
        return productRepository.UpdateAsync(product);
    }

    public Task DeleteProductAsync(long productId)
    {
        return productRepository.DeleteAsync(productId);
    }
}
