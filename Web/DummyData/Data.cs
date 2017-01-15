using System;
using System.Collections.Generic;
using Core;
using Infrastructure;

namespace Web.DummyData
{
    public class Data
    {
        public static void AddToDatabase()
        {
            var studentRepository = new StudentRepository();
            studentRepository.DeleteAll();


            var teacherRepository = new TeacherRepository();
            teacherRepository.DeleteAll();

            var courseRepository = new CourseRepository();
            courseRepository.DeleteAll();

            var groupRepository = new GroupRepository();
            groupRepository.DeleteAll();

            var a5 = new Group("A5", 3);
            var a2 = new Group("A2", 2);

            var ionut = new Student("001", "Ionut", "Iacob", a5, DateTime.Now);
            var anca = new Student("002", "Anca", "Adascalitei", a5, DateTime.Now);
            var stefan = new Student("003", "Stefan", "Gordin", a5, DateTime.Now);
            var eve = new Student("004", "Eveline", "Giosanu", a5, DateTime.Now);
            var alexandra = new Student("005", "Alexandra", "Gadioi", a2, DateTime.Now);

            var florin = new Teacher("Florin", "Olariu", DateTime.Now);
            var dorel = new Teacher("Dorel", "Lucanu", DateTime.Now);
            var cosmin = new Teacher("Cosmin", "Varlan", DateTime.Now);

            studentRepository.Create(alexandra);

            courseRepository.Create(new Course("Introduction to .NET", 3, new List<Student> {ionut, anca},
                new List<Teacher> {florin}));
            courseRepository.Create(new Course("Proiectarea Algoritmilor", 1, new List<Student> {eve},
                new List<Teacher> {dorel}));
            courseRepository.Create(new Course("Baze de Date", 2, new List<Student> {stefan, ionut, eve},
                new List<Teacher> {cosmin}));
        }
    }
}