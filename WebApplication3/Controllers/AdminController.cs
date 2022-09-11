namespace WebApplication3.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AdminController: ControllerBase
{
    [HttpGet]
    public ActionResult login(string Username , string Password)
    {
        if(Username == "Mehdi2000" && Password == "1234")
        {
            return  Ok(true);
        }

        return NotFound(false);
    }
}