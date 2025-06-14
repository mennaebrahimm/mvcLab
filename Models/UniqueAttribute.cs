using lab2.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
	public class UniqueAttribute:ValidationAttribute
	{
		protected override ValidationResult? IsValid
		   (object? value, ValidationContext validationContext)
		{
            CoursDeptcs corFromReq = (CoursDeptcs)validationContext.ObjectInstance;
			string name = value.ToString();
			Context con = new Context();

			Course corFromDb = con.courses
				.FirstOrDefault(e => e.Name == name && e.Dept_id == corFromReq.Dept_id);
			if (corFromDb == null)
				return ValidationResult.Success;

			else
				return new ValidationResult("course already excited at department");
		}
		}
}
