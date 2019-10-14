using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Globalization;
public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "First Name:")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "Last Name:")]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of birth:")]
    [ValidateDOB]
    public DateTime DateOfBirth { get; set; }

    public List<Dish> CreatedDishes {get; set;}


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    public string Age
    {
        get
        {
            double age = DateTime.Today.Subtract(DateOfBirth).TotalDays;
            age= (int)age/365;
            return age.ToString();
        }
    }


    public class ValidateDOBAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dob =  (DateTime)value;  

            if (dob > DateTime.Today.AddYears(-18))
            {
                return new ValidationResult("The user must be 18 years or older to submit this form. ");
            }
        return ValidationResult.Success;
        }
    }
}





