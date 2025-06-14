using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public Department Department { get; set; }


    }
}
