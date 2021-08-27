using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1M3
{
    public class FamilyApp
    {
        public string Commands = "";

        public string WelcomeMessage =
            "Velkommen til slektstre applikasjonen - Skriv 'hjelp' for informasjon om applikasjonen";

        public List<Person> People;

        public FamilyApp(params Person[] family) // Trenger params for å kalle på 9 parametere i program
        {
            People = new List<Person>(family);
        }

        public string CommandMethod(string command) // Denne metoden kaller på metodene under ved hjelp av inputs i consollen
        {
            var input = command.ToLower();

            if (input == "hjelp")
            {
                Console.WriteLine("hjelp -- liste med komandoer");
                Console.WriteLine("liste -- lister alle personer som ligger i programmet");
                Console.WriteLine("vis <id> -- Viser en bestemt person basert på ID i input feltet");
                
            }

            if (input == "liste")
            {
                return liste(People);
            }

            if (input.Contains("vis "))
            {
                return vis(input, People);
            }

            if (input == "exit")
            {
                Environment.Exit(0);  // Denne koden avslutter consollen
            }

            return "ikke en command";
        }

        private static string vis(string input, List<Person> people) // Denne funkjsonen tar ut enkeltpersoner ved hjelp av ID input i consollen
        {
            var identitet = int.Parse(input.Substring(input.IndexOf(" ", StringComparison.Ordinal) + 1)); //gjør om id til en string (eller omvendt)
            var txt = string.Empty;
            List<string> children = new List<string>();

            foreach (var personer in people)
            {
                if (personer.ID != identitet) continue;
                txt += personer.GetDescription();

                foreach (var personer1 in people)
                {
                    if (personer1.Pappa != null)
                    {
                        if (personer1.Pappa.ID == personer.ID)
                        {
                            children.Add(personer1.FirstName +
                                         " (Id=" + personer1.ID + ")" +
                                         " " + "Født: " +
                                         personer1.BirthYear);
                        }
                    }

                    if (personer1.Mamma == null) continue;
                    if (personer1.Mamma.ID == personer1.ID)
                    {
                        children.Add(personer1.FirstName +
                                     " (Id=" + personer1.ID + ")" +
                                     " " + "Født: " +
                                     personer1.BirthYear);
                    }
                }
            }

            txt += "\n";
            if (children.Count != 0)
                txt += "  Barn:\n  ";
            {
                for (int i = 0; i < children.Count; i++)
                {
                    if (i == children.Count - 1)
                    {
                        txt += children[i] + "\n";
                    }
                    else
                    {
                        txt += children[i] + "\n    ";
                    }
                }
            }
            return txt;
        }


        private static string liste(List<Person> people)
        {
            string txt = string.Empty;
            foreach (var personer in people)
            {
                txt += personer.GetDescription() + "";
            }

            return txt;
        }
    }
}
