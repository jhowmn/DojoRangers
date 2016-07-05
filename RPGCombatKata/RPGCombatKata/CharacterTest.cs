using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPGCombatKata
{
    [TestClass]
    public class CharacterTest
    {
        private Character CreateOneMeleeFoe()
        {
            return new CharacterMelee();
        }

        private Character CreateOneRangedFoe()
        {
            return new CharacterRanged();
        }

        [TestMethod]
        public void CreateDefaultCharacter()
        {
            Character c = CreateOneMeleeFoe();
            Assert.AreEqual(1, c.Level);
            Assert.AreEqual(1000, c.Health);
            Assert.AreEqual(true, c.IsAlive);
        }

        [TestMethod]
        public void IfCharacterTriesToAttackHimself_AttackHasNoEffect()
        {
            Character foe = CreateOneMeleeFoe();
            foe.Attack(foe, new Random().Next(0,1000), 1);
            Assert.AreEqual(1000, foe.Health);
        }

        [TestMethod]
        public void IfCharacterTriesToHealHisEnemies_HealHasNoEffect()
        {
            Character foe1 = CreateOneMeleeFoe();
            Character foe2 = CreateOneMeleeFoe();
            foe1.Attack(foe2, 500, 1);
            foe1.Heal(foe2, 200);
            Assert.AreEqual(500, foe2.Health);
        }

        [TestMethod]
        public void IfDamageIsHigherThanHealth_CharacterIsDead()
        {
            Character foe1 = CreateOneMeleeFoe();
            Character foe2 = CreateOneMeleeFoe();

            foe1.Attack(foe2, 2000, 1);

            Assert.AreEqual(0, foe2.Health);
            Assert.IsFalse(foe2.IsAlive);
        }

        [TestMethod]
        public void IfCharacterIsHealedWithFullHealth_HealingHasNoEffect()
        {
            Character foe1 = CreateOneMeleeFoe();
            Character foe2 = CreateOneMeleeFoe();

            foe1.Heal(foe2, 100);

            Assert.AreEqual(1000, foe2.Health);
        }

        [TestMethod]
        public void IfEnemiesLevelIsFiveLevelsHigherThanMine_AttackIsReducedByHalf()
        {
            Character foe1 = CreateOneMeleeFoe();
            Character foe2 = CreateOneMeleeFoe();
            foe2.Level = 6;
            foe1.Attack(foe2, 100, 1);
            Assert.AreEqual(950, foe2.Health);
        }

        [TestMethod]
        public void IfEnemiesLevelIsFiveLevelsLowerThanMine_AttackIsIncreasedByHalf()
        {
            Character foe1 = CreateOneMeleeFoe();
            foe1.Level = 6;
            Character foe2 = CreateOneMeleeFoe();
            foe1.Attack(foe2, 100, 1);
            Assert.AreEqual(850, foe2.Health);
        }

        [TestMethod]
        public void IfCharacterIsMeleeFighter_HisAttackRangeMustBe2Meters()
        {
            Character foe1 = CreateOneMeleeFoe();
            Character foe2 = CreateOneMeleeFoe();

            foe1.Attack(foe2, 100, 1);
            Assert.AreEqual(900, foe2.Health);

            foe1.Attack(foe2, 100, 3);
            Assert.AreEqual(900, foe2.Health);
        }

        [TestMethod]
        public void IfCharacterIsRangedFighter_HisAttackRangeMustBe20Meters()
        {
            Character foe1 = CreateOneRangedFoe();
            Character foe2 = CreateOneMeleeFoe();

            foe1.Attack(foe2, 100, 1);
            Assert.AreEqual(900, foe2.Health);

            foe1.Attack(foe2, 100, 30);
            Assert.AreEqual(900, foe2.Health);
        }
    }
}
