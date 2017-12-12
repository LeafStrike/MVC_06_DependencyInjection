using MVC_Dependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Dependency.Services
{
    public class StudentsSource
    {
        public List<Student> Students { get; }

        public StudentsSource()
        {
            Students = new List<Student>()
            {
                new Student
                {
                    Id = 0,
                    Name = "Nick",
                    Surname = "Valuev",
                    GroupId = 10,
                    Status = "выпускник-бакалавр"
                },
                new Student
                {
                    Id = 1,
                    Name = "Dora",
                    Surname = "TheTraveller",
                    GroupId = 12,
                    Status = "бакалавр"
                },
                new Student
                {
                    Id = 2,
                    Name = "Frodo",
                    Surname = "Baggins",
                    GroupId = 14,
                    Status = "бакалавр"
                },
                new Student
                {
                    Id = 3,
                    Name = "Bilbo",
                    Surname = "Baggins",
                    GroupId = 8,
                    Status = "магистр"
                }
            };
        }
    }
}
