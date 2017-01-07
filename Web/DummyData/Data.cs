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
            var student = new Student("001", "Ionut", "Iacob", 3, new Group("A5"), DateTime.Now);
            studentRepository.Create(new Student("002", "Anca", "Adascalitei", 3, new Group("A5"), DateTime.Now));
            studentRepository.Create(new Student("003", "Stefan", "Gordin", 7, new Group("A5"), DateTime.Now));
            studentRepository.Create(new Student("004", "Eveline", "Giosanu", 3, new Group("A5"), DateTime.Now));
            studentRepository.Create(new Student("005", "Alexandra", "Gadioi", 3, new Group("A2"), DateTime.Now));
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
            groupRepository.Create(new Group("A5"));
            groupRepository.Create(new Group("A1"));
            groupRepository.Create(new Group("A4"));
        }
    }
}