using lab2.Models;
using lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace lab2.Controllers
{
    public class InstrucorController : Controller
    {
        Context con = new Context();

        public IActionResult Index()
        {
            var instructors = con.instructors.ToList();
            return View("Index", instructors);

        }
        // Details

        public IActionResult Details(int id)
        {
            Instructor instructor = con.instructors.FirstOrDefault(i => i.Id == id);
            return View("Details", instructor);

        }

        //new
        public IActionResult add()
        {
            List <Department > departments =con.departments.ToList();
            InstCoursDept instCoursDept = new InstCoursDept();  
            instCoursDept.Departments = departments;

            List <Course> courses = con.courses.ToList();   
            instCoursDept.courses = courses;

            return View("add",instCoursDept);
        }

        //savenew
        [HttpPost]
        public IActionResult saveadd(InstCoursDept instCoursDept) {

            
            if (instCoursDept.Name != null && instCoursDept.Address != null
                && instCoursDept.Salary != 0)
            {
                Instructor inst = new Instructor();
                inst.Name = instCoursDept.Name;
                inst.Salary = instCoursDept.Salary;
                inst.Address = instCoursDept.Address;
                inst.Imag = instCoursDept.Imag;
                inst.Crs_id = instCoursDept.course;
                inst.Dept_id = instCoursDept.Department;

                con.instructors.Add(inst);
                con.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                List<Department> departments = con.departments.ToList();
                instCoursDept.Departments = departments;

                List<Course> courses = con.courses.ToList();
                instCoursDept.courses = courses;

                return View("add", instCoursDept);

            } }
    }
}
