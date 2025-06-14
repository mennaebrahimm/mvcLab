using lab2.Models;
using lab2.Repository;
using lab2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lab2.Controllers
{
	public class CourseController : Controller
	{
		//Context con = new Context();

		ICouseRepository couseRepository;
        public CourseController(ICouseRepository couseRepository)
        {
            this.couseRepository = couseRepository;
        }


        public IActionResult Index()
		{
			var courses =couseRepository.GetCoursesWhitDeptName();

			
			return View("Index", courses);
		}
		//add
		public IActionResult Add()
		{
			var departments = couseRepository.departments();
							
			CoursDeptcs cd= new CoursDeptcs();
			cd.Departments = departments;

           // ViewBag.DeptList = con.departments.ToList();


            return View("add",cd);
		}
		//saveadd
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveadd(CoursDeptcs cd )
		{

		//	if (cd.Name!=null && cd.Dept_id != null && cd.Hours != 0)
				if(ModelState.IsValid)
               
            {
				try
				{
					Course course = new Course();
					course.Name = cd.Name;
					course.Dept_id = cd.Dept_id;
					course.Degree = cd.Degree;
					course.MinDegree = cd.MinDegree;
					course.Hours = cd.Hours;

                    couseRepository.Add(course);
					couseRepository.Save();
					return RedirectToAction("Index");
				}
				catch (Exception ex) {
					//ModelState.AddModelError("Dept_id", "please select department");
					ModelState.AddModelError("anykey", ex.InnerException.Message);
				
				}
			}

			
				var departments = couseRepository.departments();
				cd.Departments = departments;


				return View("add",cd);
			
		}
        //ValidateMinDegree

        public JsonResult ValidateMinDegree(int MinDegree, int Degree)
		{
			if (MinDegree > Degree)
			{
				return Json("MinDegree must be less than Degree");
			}
			else
				return Json(true); 
		}
    }
}
