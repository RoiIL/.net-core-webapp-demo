using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int _grade;        
        public int Grade
        {
            get
            {
                return _grade;
            }

            set
            {
                if (value > 100)
                {
                    throw new Exception("Grade can be 100 or below.");
                }
                else
                {
                    _grade = value;
                }
            }
        }
    }
}
