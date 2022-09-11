using Microsoft.EntityFrameworkCore;
using WebApplication3.Migrations;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    public databaseContext context;

    public ProductController(databaseContext contextCopy)
    {
        context = contextCopy;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var ProductsFromDatabase = await context.Products.ToListAsync();
        return ProductsFromDatabase;
    }

    // [HttpGet("GetSpecificProduct")]
    // {

    // }
    [HttpPost]
    public async Task<ActionResult<Product>> creatNewProduct(Product NewProduct)
    {
        context.Products.Add(NewProduct);
        await context.SaveChangesAsync();
        return Ok(NewProduct);
    }

    [HttpGet("{ProductId}")]
    public async Task<ActionResult<Product>> GetSpecificProduct(int ProductId)
    {
        // var ProductsFromDatabase = await context.Products.ToListAsync();
        // foreach (var product in ProductsFromDatabase)
        // {
        // if (product.id == ProductId)
        // {
        // return Ok(product);
        // }
        var FoundProduct = await context.Products.FindAsync(ProductId);
        if (FoundProduct == null)
        {
            return NotFound();
        }
        return Ok(FoundProduct);
    }

    [HttpDelete("{ProductId}")]
    public async Task<ActionResult> DeleteProduct(int ProductId)
    {
        var FoundProduct = await context.Products.FindAsync(ProductId);
        if (FoundProduct == null)
        {
            return NotFound("Existential crisis");
        }

        context.Products.Remove(FoundProduct);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{ProductId}")]
    public async Task<ActionResult<Product>> UpdateProduct(int ProductId, Product newProduct)
    {
        var FoundProduct = await context.Products.FindAsync(ProductId);
        if (FoundProduct == null)
        {
            return NotFound("Existential Crisis ");
        }

        FoundProduct.name = newProduct.name;
        FoundProduct.price = newProduct.price;
        FoundProduct.description = newProduct.description;
        FoundProduct.imageUrl = newProduct.imageUrl;
        await context.SaveChangesAsync();
        return Ok();
       
    }

}