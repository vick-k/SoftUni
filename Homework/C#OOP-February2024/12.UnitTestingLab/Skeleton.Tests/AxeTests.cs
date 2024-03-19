using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy target;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(5, 3);
            target = new Dummy(10, 5);
        }

        [Test]
        public void AttackPointsIsSetCorrectly()
        {
            Assert.AreEqual(axe.AttackPoints, 5);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(target);

            Assert.AreEqual(axe.DurabilityPoints, 2);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void AttackWithBrokenAxe(int durability)
        {
            axe = new(5, durability);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(target);
            });
        }
    }
}