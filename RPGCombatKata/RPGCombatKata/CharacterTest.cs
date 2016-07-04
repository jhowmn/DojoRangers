using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPGCombatKata
{
    [TestClass]
    public class CharacterTest
    {
        private Character CreateOneFoe()
        {
            return new Character();
        }

        [TestMethod]
        public void CreateDefaultCharacter()
        {
            Character c = CreateOneFoe();
            Assert.AreEqual(1, c.Level);
            Assert.AreEqual(1000, c.Health);
            Assert.AreEqual(true, c.IsAlive);
        }

        [TestMethod]
        public void IfDamageIsHigherThanHealth_CharacterIsDead()
        {
            Character foe1 = CreateOneFoe();
            Character foe2 = CreateOneFoe();

            foe1.Attack(foe2, 2000);

            Assert.AreEqual(0, foe2.Health);
            Assert.IsFalse(foe2.IsAlive);
        }

        [TestMethod]
        public void IfCharacterIsHealedWithFullHealth_HealingHasNoEffect()
        {
            Character foe1 = CreateOneFoe();
            Character foe2 = CreateOneFoe();

            foe1.Heal(foe2, 100);

            Assert.AreEqual(1000, foe2.Health);
        }
    }
}
