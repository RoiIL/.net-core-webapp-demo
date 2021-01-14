using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly Student[] _studentsArray = new[]
        {
            new Student()
            {
                Id = 1,
                Name = "Havakuk",
                Grade = 94
            },
            new Student()
            {
                Id = 2,
                Name = "Meidan",
                Grade = 100
            },
            new Student()
            {
                Id = 3,
                Name = "Efi",
                Grade = 87
            },
            new Student()
            {
                Id = 4,
                Name = "Yariv",
                Grade = 42
            }
        };

        private List<Student> _studentsList;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
            _studentsList = new List<Student>();
            _studentsList.Add(new Student() {Id = 1, Name = "Havakuk", Grade = 94});
        }

        // GET: /students
        [HttpGet]
        public Student Get()
        {
            var rng = new Random();
            return new Student()
            {
                Id = 1234,
                Name = "Havakuk",
                Grade = 94
            };
        }

        // GET: /students/1
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _studentsArray[id];
        }

        // GET: /students/GetName/1
        [HttpGet]
        [Route("GetName/{id}")]
        public string GetName(int id)
        {
            return _studentsArray[id].Name;
        }

        // POST: students
        [HttpPost]
        public List<Student> Post(Student student)
        {
            _studentsList.Add(new Student(){Id = student.Id, Name = student.Name, Grade = student.Grade});
            return _studentsList;
        }

        [HttpPut("{id}")]
        public Student Put(Student student, int id)
        {
            if (student.Id != id)
            {
                throw new Exception("Wrong id for given student");
            }

            student.Grade += 5;
            return student;
        }
    }
}
