using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.ViewModel
{
    public class CoursDeptcs
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Unique]
        public string Name { get; set; }

        [Range(50, 100)]
        public int Degree { get; set; }

        [Remote(action: "ValidateMinDegree", controller: "Course", AdditionalFields = nameof(Degree),
            ErrorMessage = "MinDegree must be less than Degree")]
        public int MinDegree { get; set; }

        [DivisibleByThree]
        public int Hours { get; set; }

        public int Dept_id { get; set; }

       // [NotMapped]
        [ValidateNever]
        public string DepartmentName { get; set; }

       // [NotMapped]
        [ValidateNever]
        public List<Department> Departments { get; set; }

    }
}
