using System.ComponentModel.DataAnnotations;

namespace greg.Models
{
  public class Car
  {
      public int Id { get; set; }

      [Required]
      [MinLength(6)]
      public string Name { get; set; }
  }
}