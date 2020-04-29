using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyMVVM.Model
{
    public class Person
    {

        public Person(string surname, string name, int? age, int? weight)
        {
            name = this.Name;//.ToUpper();
            surname = this.Surname;//.ToUpper();
            age = this.Age;
            weight = this.Weight;
        }

        public string Name { get ; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }


        public override string ToString()
        {
            return Surname + "     " + Name + "     " + Age + "     " + Weight;
        }
    }
}
