using lab2.Controllers;
using lab2.Models;
using lab2.ViewModel;

namespace lab2.Repository
{
    public class CourseRepository : ICouseRepository
    {
        Context con;
        public CourseRepository(Context con)
        {
           // con = new Context();
           this.con = con;
        }
        public void Add(Course entity)
        {

           con.Add(entity);
        }

        public void Delete(int id)
        {
            Course course = GetById( id);
            if (GetById( id) != null)
                con.courses.Remove(course);
        }

        public List<Department> departments()
        {
          return  con.departments.ToList();
        }

        public List<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            Course course = con.courses.Find(id);
            return course;
        }

        public List<CoursDeptcs> GetCoursesWhitDeptName()
        {
            var courses = con.courses.Select(c => new CoursDeptcs
            {

                Id = c.Id,
                Name = c.Name,
                Hours = c.Hours,
                Degree = c.Degree,
                MinDegree = c.MinDegree,
                Dept_id = c.Dept_id,
                DepartmentName = c.Department.Name,
            }).ToList();
            return courses;
        }

        public void Save()
        {
            con.SaveChanges();  
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
