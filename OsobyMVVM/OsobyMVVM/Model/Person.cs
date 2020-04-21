using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyMVVM.Model
{
    public class Person
    {
        string name, surname;
        int age, weight;

        public Person(string surname, string name, int age, int weight)
        {
            name = this.name;
            surname = this.surname;
            age = this.age;
            weight = this.weight;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }

    }
}
