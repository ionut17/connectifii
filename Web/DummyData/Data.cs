using System;
using System.Collections.Generic;
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
            ICollection<Course> empty = new List<Course>();
            studentRepository.Create(new Student("001", "Ionut", "Iacob", 3, new Group("A5"), DateTime.Now, empty));
            studentRepository.Create(new Student("002", "Anca", "Adascalitei", 3, new Group("A5"), DateTime.Now, empty));
            studentRepository.Create(new Student("003", "Stefan", "Gordin", 7, new Group("A5"), DateTime.Now, empty));
            studentRepository.Create(new Student("004", "Eveline", "Giosanu", 3, new Group("A5"), DateTime.Now, empty));
            studentRepository.Create(new Student("005", "Alexandra", "Gadioi", 3, new Group("A2"), DateTime.Now, empty));
        }

        public static void AddCourses()
        {
            var courseRepository = new CourseRepository();
            courseRepository.DeleteAll();
            ICollection<TeacherCourse> empty = new List<TeacherCourse>();
            courseRepository.Create(new Course("Introduction to .NET", 3, empty));
            courseRepository.Create(new Course("Proiectarea Algoritmilor", 1, empty));
            courseRepository.Create(new Course("Baze de Date", 2, empty));
        }

        public static void AddTeachers()
        {
            var teacherRepository = new TeacherRepository();
            teacherRepository.DeleteAll();
            ICollection<TeacherCourse> empty = new List<TeacherCourse>();
            teacherRepository.Create(new Teacher("Florin", "Olariu", DateTime.Now, empty));
            teacherRepository.Create(new Teacher("Dorel", "Lucanu", DateTime.Now, empty));
            teacherRepository.Create(new Teacher("Cosmin", "Varlan", DateTime.Now, empty));
        }

        public static void AddGroups()
        {
            var groupRepository = new GroupRepository();
            groupRepository.DeleteAll();
            ICollection<Group> empty = new List<Group>();
            groupRepository.Create(new Group("A5"));
            groupRepository.Create(new Group("A1"));
            groupRepository.Create(new Group("A4"));
        }
    }
}