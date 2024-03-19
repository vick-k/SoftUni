using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy target;

        [SetUp]
        public void SetUp()
        {
            target = new Dummy(10, 5);
        }

        [Test]
        public void DummyDataIsSetCorrectly()
        {
            Assert.AreEqual(target.Health, 10);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            target.TakeAttack(5);

            Assert.AreEqual(target.Health, 5);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void DeadDummyThrowsExceptionIfAttacked(int attackPoints)
        {
            target.TakeAttack(attackPoints);

            Assert.Throws<InvalidOperationException>(() =>
            {
                target.TakeAttack(attackPoints);
            });
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            target.TakeAttack(10);

            Assert.AreEqual(target.GiveExperience(), 5);
        }

        [Test]
        public void AliveDummyCannotGiveXp()
        {
            target.TakeAttack(8);

            Assert.Throws<InvalidOperationException>(() =>
            {
                target.GiveExperience();
            });
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void TestIsDeadMethod(int attackPoints)
        {
            target.TakeAttack(attackPoints);

            Assert.IsTrue(target.IsDead());
        }
    }
}