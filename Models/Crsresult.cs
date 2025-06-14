using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Crsresult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }
        public Trainee Trainee { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }
        public Course Course { get; set; }  


    }
}
