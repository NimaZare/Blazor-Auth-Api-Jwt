using Microsoft.EntityFrameworkCore;
using MyBlazorApp.DataAccess.Data;
using MyBlazorApp.Model.Entities;

namespace MyBlazorApp.Application.Repositories;

public interface IProductRepository
{
    Task<List<ProductModel>> GetAllAsync();
    Task<ProductModel?> GetByIdAsync(long id);
    Task<ProductModel> CreateAsync(ProductModel model);
    Task UpdateAsync(ProductModel model);
    Task DeleteAsync(long id);
}

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<List<ProductModel>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<ProductModel?> GetByIdAsync(long id)
    {
        return await dbContext.Products.FirstOrDefaultAsync(n => n.ID == id);
    }

    public async Task<ProductModel> CreateAsync(ProductModel model)
    {
        await dbContext.Products.AddAsync(model);
        await dbContext.SaveChangesAsync();
        return model;
    }

    public async Task UpdateAsync(ProductModel model)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(n => n.ID == model.ID);
        if (product != null)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.CreateAt = model.CreateAt;
            product.Quantity = model.Quantity;
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(long id)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(n => n.ID == id);
        dbContext.Products.Remove(product!);
        await dbContext.SaveChangesAsync();
    }
}
