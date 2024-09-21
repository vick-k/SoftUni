namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database emptyDatabase;
        private Database fullDatabase;

        [SetUp]
        public void SetUp()
        {
            emptyDatabase = new Database();

            int[] data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            fullDatabase = new Database(data);
        }

        [Test]
        public void Ctor_NoParams_InitializeDatabase()
        {
            Assert.That(emptyDatabase, Is.Not.Null);
            Assert.That(emptyDatabase.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_WithParams_InitializeDatabase()
        {
            Assert.That(fullDatabase, Is.Not.Null);
            Assert.That(fullDatabase.Count, Is.EqualTo(16));
        }

        [Test]
        public void Add_ValidOperation_ShouldAddElementToTheDatabase()
        {
            emptyDatabase.Add(5);

            Assert.That(emptyDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ArrayCapacityIsFull_ThrowException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(5));

            Assert.That(ioe.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_ValidOperation_ShouldRemoveElementFromTheDatabase()
        {
            fullDatabase.Remove();

            Assert.That(fullDatabase.Count, Is.EqualTo(15));
        }

        [Test]
        public void Remove_ArrayIsEmpty_ThrowException()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => emptyDatabase.Remove());
            Assert.That(ioe.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Fetch_WithElements_ReturnArray()
        {
            int[] data = new int[5];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            Database newDatabase = new Database(data);
            int[] fetchedData = newDatabase.Fetch();

            Assert.That(fetchedData, Is.EqualTo(data));
        }

        [Test]
        public void Fetch_EmptyArray_ReturnEmptyArray()
        {
            int[] fetchedData = emptyDatabase.Fetch();

            Assert.That(fetchedData, Is.EqualTo(new int[0]));
        }
    }
}
