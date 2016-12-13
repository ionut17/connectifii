using Core;
using Infrastructure;

namespace Web.Controllers
{
    public class StudentsController : AbstractController<Student>
    {
        public StudentsController()
        {
            Repository = new StudentRepository();
//            ICollection<Course> empty = new List<Course>();
////            Repository.Create(new Student("001", "Ionut", "Iacob", 3, "A5", DateTime.Now, empty));
////            Repository.Create(new Student("002", "Anca", "Adascalitei", 3, "A5", DateTime.Now, empty));
////            Repository.Create(new Student("003", "Stefan", "Gordin", 7, "A5", DateTime.Now, empty));
////            Repository.Create(new Student("004", "Eveline", "Giosanu", 3, "A5", DateTime.Now, empty));
////            Repository.Create(new Student("005", "Alexandra", "Gadioi", 3, "A2", DateTime.Now, empty));
        }
    }
}