using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobyMVVM.Model
{
    class Operating
    {
        public Person person { get; } = new Person("", "", 0,0);

        public void AddNameSurname(params string[] s)
        {
            if (s != null)
            {
                person.Surname = s[0];
                if (s[1] != null)
                    person.Name = s[1];
            }
        }
        public void AddAgeWeight(params int?[] aw)
        {
            int? a, w;
            if (aw != null)
            {
                a = aw[0];
                if (aw[1] != null)
                {
                    w = aw[1];
                    person.Age = a;
                    person.Weight = w;

                }
                else
                {
                    person.Age = a;

                }
            }
        }

        public Person AddPerson(string[] s, int[] i)
        {
            person.Surname = s[0];
            person.Name = s[1];
            person.Age = i[0];
            person.Weight = i[1];

            return person;
        }



        public string StringPerson(string surname, string name, int age, int weight)
        {
            return surname + ";" + name + ";" + age + ";" + weight;
        }

        public string ToListPerson(string surname, string name, int age, int weight)
        {  
            return surname + "     " + name + "     " + age + "     " + weight;
        }

    }
}
