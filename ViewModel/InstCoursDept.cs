using lab2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.ViewModel
{
    public class InstCoursDept
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Imag { get; set; }

        public decimal Salary { get; set; }
        public string Address { get; set; }
         
        public int Department { get; set; }
        public int course { get; set; }

        public List<Department> Departments { get; set; }
        public List<Course> courses { get; set; }

        
        }
    }



