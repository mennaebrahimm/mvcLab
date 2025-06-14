using lab2.Models;
using lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class TraineeController : Controller
    {
        Context con = new Context();
        public IActionResult GetREsult(int Tra_id, int Cors_id)
        {
            var tName = con.traines.Where(t => t.Id == Tra_id).Select(t => t.Name).FirstOrDefault();

            var course = con.courses.Where(c => c.Id == Cors_id).Select(c =>new { c.Name , c.MinDegree }).FirstOrDefault();
            string cName = course.Name;
            int mindegree= course.MinDegree;
            if (tName == null || cName == null)
            {
                return NotFound("NotFound");
                    }
            else
            {


                var degree = con.crsresult.Where(c => c.crs_id == Cors_id && c.Trainee_id == Tra_id).Select(c => c.Degree).FirstOrDefault();
                var result = degree - mindegree;
                string statuse = (result >= 0) ? "Successful" : "Failed";



                TraineeCourseCrsresult TCR = new TraineeCourseCrsresult()
                {
                    Trainee_name = tName,
                    crs_name = cName,
                    Degree = degree,
                    statuse = statuse

                };
                return View("GetREsult", TCR);
            }
        }
    }
}
