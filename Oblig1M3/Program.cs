using System;
using System.Threading.Channels;

namespace Oblig1M3
{
    class Program
    {
        static void Main(string[] args)
        {
            var joakimSjursenPerson = new Person 
                { ID = 1, FirstName = "Joakim", LastName = "Sjursen", BirthYear = 1996 };
            var emilSjursenPerson = new Person 
                { ID = 2, FirstName = "Emil", LastName = "Sjursen", BirthYear = 1994 };
            var andreasSjursenPerson = new Person 
                { ID = 3, FirstName = "Andreas", LastName = "Sjursen", BirthYear = 1992 };
            var dianaSjursenPerson = new Person 
                { ID = 4, FirstName = "Diana", LastName = "Sjursen", BirthYear = 1962 };
            var atleSjursenPerson = new Person 
                { ID = 5, FirstName = "Atle", LastName = "Sjursen", BirthYear = 1962 };
            var emmaSjursenPerson = new Person 
                { ID = 6, FirstName = "Emma", LastName = "Sjursen", BirthYear = 1930, DeathYear = 1999 };
            var torsteinSjursenPerson = new Person 
                { ID = 7, FirstName = "Torstein", LastName = "Sjursen", BirthYear = 1929, DeathYear = 1993 };
            var ingegerdKverchPerson = new Person()
                {ID = 8, FirstName = "Ingegerd", LastName = "Kverch", BirthYear = 1927, DeathYear = 2016 };
            var JosefKverchPerson = new Person()
                {ID = 9, FirstName = "Josef", LastName = "Kverch", BirthYear = 1929, DeathYear = 1990 };

            joakimSjursenPerson.Pappa = atleSjursenPerson;
            joakimSjursenPerson.Mamma = dianaSjursenPerson;
            emilSjursenPerson.Pappa = atleSjursenPerson;
            emilSjursenPerson.Mamma = dianaSjursenPerson;
            andreasSjursenPerson.Pappa = atleSjursenPerson;
            andreasSjursenPerson.Mamma = dianaSjursenPerson;
            dianaSjursenPerson.Pappa = JosefKverchPerson;
            dianaSjursenPerson.Mamma = ingegerdKverchPerson;
            atleSjursenPerson.Pappa = torsteinSjursenPerson;
            atleSjursenPerson.Mamma = emmaSjursenPerson;

            var applikasjon = new FamilyApp(
                joakimSjursenPerson,
                emilSjursenPerson,
                andreasSjursenPerson,
                dianaSjursenPerson,
                atleSjursenPerson,
                emmaSjursenPerson,
                torsteinSjursenPerson,
                ingegerdKverchPerson,
                JosefKverchPerson
            );
            Console.WriteLine(applikasjon.WelcomeMessage);
            while (true)
            {
                Console.Write(applikasjon.Commands);
                var command1 = Console.ReadLine();
                var svar = applikasjon.CommandMethod(command1);
                Console.WriteLine(svar);
            }
        }
    }
}
