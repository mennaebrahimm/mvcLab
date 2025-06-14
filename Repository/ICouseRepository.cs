using lab2.Models;
using lab2.ViewModel;

namespace lab2.Repository
{
    public interface ICouseRepository:IRepository<Course>
    {
        List<CoursDeptcs> GetCoursesWhitDeptName();
        List<Department> departments(); 
    }
}
