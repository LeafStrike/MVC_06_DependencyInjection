using MVC_Dependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Dependency.Services
{
    public interface IStudentService
    {
        List<Student> GetStudentsList();
        Student GetStudent(int studentId);
        void EditStudent(Student student);
        void RemoveStudent(int studentId);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentService _studentService;
        private readonly StudentsSource _studentsSource;
        public StudentService(StudentsSource studentsSource)
        {
            _studentsSource = studentsSource;
        }
        public List<Student> GetStudentsList()
        {
            return _studentsSource.Students;
        }
        public Student GetStudent(int studentId)
        {
            return _studentsSource.Students.Find(x => x.Id == studentId);
        }
        public void EditStudent(Student student)
        {
            _studentsSource.Students.Find(x => x.Id.Equals(student.Id)).Name = student.Name;
            _studentsSource.Students.Find(x => x.Id.Equals(student.Id)).Surname = student.Surname;
            _studentsSource.Students.Find(x => x.Id.Equals(student.Id)).GroupId = student.GroupId;
            _studentsSource.Students.Find(x => x.Id.Equals(student.Id)).Status = student.Status;
        }
        public void RemoveStudent(int studentId)
        {
            _studentsSource.Students.Remove(_studentsSource.Students.Find(x => x.Id.Equals(studentId)));
        }
    }
}
