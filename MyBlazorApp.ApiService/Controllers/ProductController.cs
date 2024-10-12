using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Application.Services;
using MyBlazorApp.Model.Entities;
using MyBlazorApp.Model.Models;

namespace MyBlazorApp.ApiService.Controllers;

[Authorize(Roles = "Admin,User")]
[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productService.GetProductsAsync();
        return Ok(new BaseResponseModel<List<ProductModel>> { Success = true, Data = products });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(long id)
    {
        var productModel = await productService.GetProductAsync(id);

        if (productModel is null)
        {
            return Ok(new BaseResponseModel<ProductModel> { Success = false, ErrorMessage = "Not Found" });
        }

        return Ok(new BaseResponseModel<ProductModel> { Success = true, Data = productModel });
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductModel product)
    {
        await productService.CreateProductAsync(product);
        return Ok(new BaseResponseModel<ProductModel> { Success = true });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(long id, ProductModel product)
    {
        var productModel = await productService.GetProductAsync(id);

        if (productModel is null)
        {
            return Ok(new BaseResponseModel<ProductModel> { Success = false, ErrorMessage = "Not Found" });
        }

        await productService.UpdateProductAsync(product);
        return Ok(new BaseResponseModel<ProductModel> { Success = true });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(long id)
    {
        var productModel = await productService.GetProductAsync(id);

        if (productModel is null)
        {
            return Ok(new BaseResponseModel<ProductModel> { Success = false, ErrorMessage = "Not Found" });
        }

        await productService.DeleteProductAsync(id);
        return Ok(new BaseResponseModel<ProductModel> { Success = true });
    }
}
