using NUnit.Framework;
using Oblig1M3;


namespace Oblig1Test
{
    class Class1
    {
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void FamilyAppTest()
            {
                var JoakimSjursenPerson = new Person { ID = 1, FirstName = "Joakim", BirthYear = 1996 };
                var EmilSjursenPerson = new Person { ID = 2, FirstName = "Emil", BirthYear = 1994 };
                var andreasSjursenPerson = new Person { ID = 3, FirstName = "Andreas", BirthYear = 1992 };
                var atleSjursenPerson = new Person { ID = 6, FirstName = "Atle", BirthYear = 1962 };
                var TorsteinSjursenPerson = new Person {ID = 7, FirstName = "Torstein", BirthYear = 1930};
                JoakimSjursenPerson.Pappa = atleSjursenPerson;
                EmilSjursenPerson.Pappa = atleSjursenPerson;
                andreasSjursenPerson.Pappa= atleSjursenPerson;
                atleSjursenPerson.Pappa = TorsteinSjursenPerson;

                var app = new FamilyApp(JoakimSjursenPerson, EmilSjursenPerson, andreasSjursenPerson, atleSjursenPerson, TorsteinSjursenPerson);
                var actualResponse = app.CommandMethod("vis 6");
                var expectedResponse = "Atle (Id=6) Født: 1962 Far: Torstein (Id=7)\n"
                                       + "  Barn:\n"
                                       + "  Joakim (Id=1) Født: 1996\n"
                                       + "    Emil (Id=2) Født: 1994\n"
                                       + "    Andreas (Id=3) Født: 1992\n";
                Assert.AreEqual(expectedResponse, actualResponse);
            }

            [Test]
            public void TestIfKids()
            {
                var JoakimSjursenPerson = new Person { ID = 1, FirstName = "Joakim", BirthYear = 1996 };
                var EmilSjursenPerson = new Person { ID = 2, FirstName = "Emil", BirthYear = 1994 };
                var andreasSjursenPerson = new Person { ID = 3, FirstName = "Andreas", BirthYear = 1992 };
                var atleSjursenPerson = new Person { ID = 6, FirstName = "Atle", BirthYear = 1962 };
                var TorsteinSjursenPerson = new Person { ID = 7, FirstName = "Torstein", BirthYear = 1930 };
                JoakimSjursenPerson.Pappa = atleSjursenPerson;
                EmilSjursenPerson.Pappa = atleSjursenPerson;
                andreasSjursenPerson.Pappa = atleSjursenPerson;
                atleSjursenPerson.Pappa = TorsteinSjursenPerson;

                var app = new FamilyApp(JoakimSjursenPerson, EmilSjursenPerson, andreasSjursenPerson, atleSjursenPerson, TorsteinSjursenPerson);
                var actualResponse = app.CommandMethod("vis 1");
                var expectedResponse = "Joakim (Id=1) Født: 1996 Far: Atle (Id=6)\n";

                Assert.AreEqual(expectedResponse, actualResponse);
            }
        }
    }
}
