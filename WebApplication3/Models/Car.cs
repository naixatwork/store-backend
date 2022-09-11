
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models;

public class Car
{
    [Key]
    public int id { get; set; }
    public string model { get; set; }
}

