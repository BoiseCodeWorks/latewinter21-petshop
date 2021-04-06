using System;
using System.ComponentModel.DataAnnotations;

namespace latewin21_petshop.Models
{
  public class Cat
  {
    public Cat(string name, string color, int lives, int streetCred)
    {
      Name = name;
      Color = color;
      Lives = lives;
      StreetCred = streetCred;
    }

    public Cat()
    {

    }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public string Color { get; set; }
    [Range(0, 9)]
    public int Lives { get; set; }
    public int StreetCred { get; set; }
    public string Id { get; private set; } = Guid.NewGuid().ToString();
  }
}