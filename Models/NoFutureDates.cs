using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class NoFutureDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)             
        {                 
            if (((DateTime)value) > DateTime.Now)
            {
                return new ValidationResult("Must be born in the past");                

            }                     
            return ValidationResult.Success;
        }
    }
}