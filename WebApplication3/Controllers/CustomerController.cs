using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3;
using WebApplication3.Models;

[ApiController]
[Route("[Controller]")]
public class CustomerController : ControllerBase
{
    public databaseContext context;

    public CustomerController(databaseContext contextCopy)
    {
        context = contextCopy;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomers()
    {
        var CustomersFromDatabase = await context.Customers
            .Include(customer => customer.Products)
            .ToListAsync();
        return Ok(CustomersFromDatabase);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> AddNewCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        var addedCustomer = await context.Customers
            .Include(customer => customer.Products)
            .FirstOrDefaultAsync(_customer => _customer.username == customer.username);
        return Ok(addedCustomer);
    }

    [HttpPut("{CustomerId}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(
        int CustomerId,
        [FromBody] Product[] newProduct)
    {
        var FoundCustomer = await context.Customers
            .FindAsync(CustomerId);

        if (FoundCustomer == null)
        {
            return NotFound("Existential Crisis ");
        }

        FoundCustomer.Products = newProduct;
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<Customer>> SignUp(string username, string password)
    {
        var FoundCustomer = await context.Customers
            .Include(customer => customer.Products)
            .FirstOrDefaultAsync(
            customer => (customer.username == username && customer.password == password)
        );
        if (FoundCustomer == null)
        {
            return NotFound("Existential Crisis");
        }
        
        return Ok(FoundCustomer);
    }
}