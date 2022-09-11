using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models;

public class Product
{
    [Key]  
    public int id { get; set; }
    public string name { get; set; }
    public int price { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
}