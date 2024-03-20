namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person victor;
        private Database emptyDatabase;
        private Database fullDatabase;

        [SetUp]
        public void SetUp()
        {
            victor = new Person(230000, "vick1234");
            emptyDatabase = new Database();

            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(100000 + i, $"user000{i}");
            }

            fullDatabase = new Database(people);
        }

        [Test]
        public void Ctor_NoParams_ShouldInitializeDatabase()
        {
            Database newDatabase = new Database();
            Assert.That(newDatabase, Is.Not.Null);
            Assert.That(newDatabase.Count, Is.EqualTo(0));
        }

        [Test]
        public void CtorWithParams_ShouldInitializeDatabase()
        {
            Database newDatabase = new Database(new Person(1111, "randomName1"), new Person(1112, "randomName2"));
            Assert.That(newDatabase, Is.Not.Null);
            Assert.That(newDatabase.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddRange_FullArray_ThrowException()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(100000 + i, $"user000{i}");
            }

            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Database(people));
            Assert.That(ae.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Add_ValidOperation_PersonShouldBeAdded()
        {
            emptyDatabase.Add(victor);

            Assert.That(emptyDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_FullArray_ThrowException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(victor));
            Assert.That(ioe.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_DuplicatedUsername_ThrowsException()
        {
            emptyDatabase.Add(victor);

            Person victor2 = new(500000, "vick1234");

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => emptyDatabase.Add(victor2));
            Assert.That(ioe.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Add_DuplicatedId_ThrowsException()
        {
            emptyDatabase.Add(victor);

            Person victor2 = new(230000, "uniqueUsername123");

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => emptyDatabase.Add(victor2));
            Assert.That(ioe.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void FindByUsername_ValidOperation_ShouldReturnPerson()
        {
            Person foundPerson = fullDatabase.FindByUsername("user0000");

            Assert.That(foundPerson, Is.Not.Null);
            Assert.That(foundPerson.UserName, Is.EqualTo("user0000"));
            Assert.That(foundPerson.Id, Is.EqualTo(100000));
        }

        [Test]
        public void FindByUsername_NonExistingUser_ThrowsException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => fullDatabase.FindByUsername("non_existing_user"));
            Assert.That(ioe.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_IsNullOrEmpty_ThrowsException(string input)
        {
            ArgumentNullException ane = Assert.Throws<ArgumentNullException>(() => fullDatabase.FindByUsername(input));
            Assert.That(ane.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void FindById_ValidOperation_ShouldReturnPerson()
        {
            Person foundPerson = fullDatabase.FindById(100000);

            Assert.That(foundPerson, Is.Not.Null);
            Assert.That(foundPerson.Id, Is.EqualTo(100000));
            Assert.That(foundPerson.UserName, Is.EqualTo("user0000"));
        }

        [Test]
        public void FindById_IncorrectId_ThrowsException()
        {
            ArgumentOutOfRangeException aore = Assert.Throws<ArgumentOutOfRangeException>(() => fullDatabase.FindById(-1));
            Assert.That(aore.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindById_NotExistingId_ThrowsException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => fullDatabase.FindById(983745));
            Assert.That(ioe.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void Remove_ValidOperation_PersonShouldBeRemoved()
        {
            fullDatabase.Remove();

            Assert.That(fullDatabase.Count, Is.EqualTo(15));
        }

        [Test]
        public void Remove_EmptyArray_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => emptyDatabase.Remove());
        }
    }
}
