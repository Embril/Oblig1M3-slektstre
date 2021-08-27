using NUnit.Framework;
using Oblig1M3;

namespace Oblig1Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                ID = 1,
                FirstName = "Joakim",
                LastName = "Sjursen",
                BirthYear = 1996,
                Pappa = new Person() { ID = 5, FirstName = "Atle" },
                Mamma = new Person() { ID = 4, FirstName = "Diana" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Joakim Sjursen (Id=1) Født: 1996 Far: Atle (Id=5) Mor: Diana (Id=4)\n";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                ID = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                ID = 4,
                FirstName = "Diana",
                LastName = "Sjursen",
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Diana Sjursen (Id=4)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeOtherFields()
        {
            var p = new Person
            {
                ID = 8,
                BirthYear = 1927,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=8) Født: 1927 ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}