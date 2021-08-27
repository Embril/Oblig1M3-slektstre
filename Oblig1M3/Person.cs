using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Oblig1M3
{
    public class Person
    {


        public int ID;  
        public string FirstName;
        public string LastName;
        public int? BirthYear; // int? gjør at int'en er nullable
        public int? DeathYear; // int? gjør at int'en er nullable
        public Person Pappa;
        public Person Mamma;
        public List<Person> myChildren = new List<Person>();


        private string getContent(string pre, object value, string after = null)
        {
            return value == null ? "" : $"{pre}{value}{after ?? ""}";
        }

        public string GetDescription()
        {
            return getContent("", FirstName, " ") +
                   getContent("", LastName, " ") +
                   getContent("(Id=", ID, ")") +
                   getContent(" Født: ", BirthYear, " ") +
                   getContent("Død: ", DeathYear, " " + "\n") +
                   getContent("Far: ", Pappa, "") +
                   getContent(" Mor: ", Mamma, "" + "\n");
        }

        public override string ToString()
        {
            if (ID != null)
            {
                return $"{FirstName ?? ""} {LastName ?? ""}(Id={ID})".Trim();
            }
            else return $"{FirstName ?? ""} {LastName ?? ""}".Trim();
        }
    }
}
