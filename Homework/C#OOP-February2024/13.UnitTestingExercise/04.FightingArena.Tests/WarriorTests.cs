namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;

        Arena commonArena;
        Warrior barbarian;
        Warrior paladin;

        [SetUp]
        public void SetUp()
        {
            commonArena = new Arena();
            barbarian = new("Barbarian", 10, 100);
            paladin = new("Paladin", 8, 120);
            commonArena.Enroll(barbarian);
            commonArena.Enroll(paladin);
        }

        [Test]
        public void Ctor_ValidData_ShouldInitialize()
        {
            Warrior warrior = new("Warrior", 10, 100);

            Assert.That(warrior, Is.Not.Null);
            Assert.That(warrior.Name, Is.EqualTo("Warrior"));
            Assert.That(warrior.Damage, Is.EqualTo(10));
            Assert.That(warrior.HP, Is.EqualTo(100));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void Name_IsNullOrWhiteSpace_ThrowsException(string input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior(input, 10, 100));
            Assert.That(ae.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Damage_ZeroOrNegative_ThrowsException(int input)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior("Warrior", input, 100));
            Assert.That(ae.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HP_Negative_ThrowsException()
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(() => new Warrior("Warrior", 10, -1));
            Assert.That(ae.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Attack_SuccessfulAction_NoKill()
        {
            int hpLeftAttacker = barbarian.HP - paladin.Damage;
            int hpLeftDefender = paladin.HP - barbarian.Damage;
            barbarian.Attack(paladin);

            Assert.That(barbarian.HP, Is.EqualTo(hpLeftAttacker));
            Assert.That(paladin.HP, Is.EqualTo(hpLeftDefender));
        }

        [Test]
        public void Attack_SuccessfulAction_Kill()
        {
            Warrior giant = new("Giant", 200, 1000);
            commonArena.Enroll(giant);

            int hpLeftAttacker = giant.HP - paladin.Damage;

            giant.Attack(paladin);

            Assert.That(giant.HP, Is.EqualTo(hpLeftAttacker));
            Assert.That(paladin.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_AttackerHpIsTooLow_ThrowsException()
        {
            Warrior tiny = new("Tiny", 200, 25);
            commonArena.Enroll(tiny);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => tiny.Attack(paladin));
            Assert.That(ioe.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Attack_DefenderHpIsTooLow_ThrowsException()
        {
            Warrior tiny = new("Tiny", 200, 25);
            commonArena.Enroll(tiny);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => barbarian.Attack(tiny));
            Assert.That(ioe.Message, Is.EqualTo($"Enemy HP must be greater than {MinAttackHp} in order to attack him!"));
        }

        [Test]
        public void Attack_TooStrongDefender_ThrowsException()
        {
            Warrior boss = new("Boss", 150, 2000);
            commonArena.Enroll(boss);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() => barbarian.Attack(boss));
            Assert.That(ioe.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}