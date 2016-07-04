using System;

namespace RPGCombatKata
{
    public class Character
    {
        public int Level { get; private set; }
        public int Health { get; private set; }
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Character()
        {
            Level = 1;
            Health = 1000;
        }

        public void Attack(Character foe, int damage)
        {
            foe.Health -= damage;
            if (!foe.IsAlive)
                foe.Health = 0;
        }

        public void Heal(Character foe2, int healthHealed)
        {
            if (foe2.Health + healthHealed > 1000)
                foe2.Health = 1000;
            else
                foe2.Health += healthHealed;
        }
    }
}