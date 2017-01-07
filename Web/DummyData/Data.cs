using System;
using Core;
using Infrastructure;

namespace Web.DummyData
{
    public class Data
    {
        public static void AddStudents()
        {
            var studentRepository = new StudentRepository();
            studentRepository.DeleteAll();
            var student = new Student("001", "Ionut", "Iacob", new Group("A5", 3), DateTime.Now);
            studentRepository.Create(new Student("002", "Anca", "Adascalitei", new Group("A5",6), DateTime.Now));
            studentRepository.Create(new Student("003", "Stefan", "Gordin", new Group("A5",2), DateTime.Now));
            studentRepository.Create(new Student("004", "Eveline", "Giosanu", new Group("A5", 5), DateTime.Now));
            studentRepository.Create(new Student("005", "Alexandra", "Gadioi", new Group("A2", 1), DateTime.Now));
        }

        public static void AddCourses()
        {
            var courseRepository = new CourseRepository();
            courseRepository.DeleteAll();
            courseRepository.Create(new Course("Introduction to .NET", 3));
            courseRepository.Create(new Course("Proiectarea Algoritmilor", 1));
            courseRepository.Create(new Course("Baze de Date", 2));
        }

        public static void AddTeachers()
        {
            var teacherRepository = new TeacherRepository();
            teacherRepository.DeleteAll();
            teacherRepository.Create(new Teacher("Florin", "Olariu", DateTime.Now));
            teacherRepository.Create(new Teacher("Dorel", "Lucanu", DateTime.Now));
            teacherRepository.Create(new Teacher("Cosmin", "Varlan", DateTime.Now));
        }

        public static void AddGroups()
        {
            var groupRepository = new GroupRepository();
            groupRepository.DeleteAll();
            groupRepository.Create(new Group("A5", 3));
            groupRepository.Create(new Group("A1", 3));
            groupRepository.Create(new Group("A4", 3));
        }
    }
}