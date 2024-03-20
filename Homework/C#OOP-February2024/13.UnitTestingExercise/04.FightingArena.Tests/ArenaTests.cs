namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        Arena commonArena;
        Warrior barbarian;
        Warrior paladin;

        [SetUp]
        public void SetUp()
        {
            commonArena = new Arena();
            barbarian = new("Barbarian", 10, 100);
            paladin = new("Paladin", 8, 120);
        }

        [Test]
        public void Ctor_ShouldInitialize()
        {
            Arena arena = new();

            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Enroll_ValidData_ShouldAddWarrior()
        {
            commonArena.Enroll(barbarian);

            Assert.That(commonArena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_DuplicatedWarrior_ThrowsException()
        {
            commonArena.Enroll(barbarian);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => commonArena.Enroll(barbarian));
            Assert.That(ioe.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Fight_ValidData_WarriorsShouldFight()
        {
            commonArena.Enroll(barbarian);
            commonArena.Enroll(paladin);

            int hpAfterAttack = barbarian.HP - paladin.Damage;
            commonArena.Fight("Barbarian", "Paladin");

            Assert.That(barbarian.HP, Is.EqualTo(hpAfterAttack));
        }

        [Test]
        public void Fight_AttackerDoesNotExists_ThrowsException()
        {
            commonArena.Enroll(paladin);

            string missingName = "Barbarian";

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => commonArena.Fight(missingName, "Paladin"));
            Assert.That(ioe.Message, Is.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }

        [Test]
        public void Fight_DefenderDoesNotExists_ThrowsException()
        {
            commonArena.Enroll(barbarian);

            string missingName = "Paladin";

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => commonArena.Fight("Barbarian", missingName));
            Assert.That(ioe.Message, Is.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }
    }
}
