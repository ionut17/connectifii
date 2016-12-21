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
            ICollection<TeacherCourse> empty3 = new List<TeacherCourse>();
            ICollection<StudentCourse> empty1 = new List<StudentCourse>();
            var course = new Course("Java", 2, empty3, empty1);

            var studentRepository = new StudentRepository();
            studentRepository.DeleteAll();
            ICollection<StudentCourse> empty = new List<StudentCourse>();
            var student = new Student("001", "Ionut", "Iacob", 3, new Group("A5"), DateTime.Now, null);
            var stc = new StudentCourse
            {
                CourseId = course.Id,
                StudentId = student.Id,
                Course = course,
                Student = student
            };
            student.StudentCourses = new List<StudentCourse> {stc};
            studentRepository.Create(student);
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
            ICollection<StudentCourse> empty1 = new List<StudentCourse>();
            courseRepository.Create(new Course("Introduction to .NET", 3, empty, empty1));
            courseRepository.Create(new Course("Proiectarea Algoritmilor", 1, empty, empty1));
            courseRepository.Create(new Course("Baze de Date", 2, empty, empty1));
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
            groupRepository.Create(new Group("A5"));
            groupRepository.Create(new Group("A1"));
            groupRepository.Create(new Group("A4"));
        }
    }
}