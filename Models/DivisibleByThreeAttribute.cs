using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
	public class DivisibleByThreeAttribute:ValidationAttribute
	{

       
        protected override ValidationResult? IsValid
			(object? value, ValidationContext validationContext)
		{
			if ((int)value % 3 == 0)

				return ValidationResult.Success;
			
			else
				return new ValidationResult("Hourse must divisible by 3");

		}
	}
}
