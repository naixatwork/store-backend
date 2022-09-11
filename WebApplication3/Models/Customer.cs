using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models;

public class Customer
{
    [Key]  
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phoneNumber { get; set; }
    public ICollection<Product> Products { get; set; }
}