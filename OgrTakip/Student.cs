using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrTakip
{
    public class Student
    {
        public Student(int id,string name,string surname,int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public Student()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

    }
}
