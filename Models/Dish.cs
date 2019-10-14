using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    
    [Required]
    [MinLength(2)]
    [Display(Name = "Dish Name")]
    public string Name { get; set; }
    
    [Required]    
    [Display(Name = "Calories:")]
    public int Calories { get; set; }
    
    [Required]    
    [Display(Name = "Tastiness: ")]
    public int Tastiness { get; set; }
    
    [Required]    
    [Display(Name = "Dish Description: ")]
    public string Description { get; set; }

    [Required]    
    [Display(Name = "Chef Name: ")]
    public int ChefId { get; set; }
    public Chef Creator {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}
