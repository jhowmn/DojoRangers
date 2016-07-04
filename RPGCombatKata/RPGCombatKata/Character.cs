using System;

namespace RPGCombatKata
{
    public class Character
    {
        public int Level { get; set; }
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
            if(this != foe)
            {
                if(foe.Level - this.Level >= 5)
                    foe.Health -= Convert.ToInt32(damage * 0.5);
                else if (this.Level - foe.Level >= 5)
                    foe.Health -= Convert.ToInt32(damage * 1.5);
                else
                    foe.Health -= damage;

                if (!foe.IsAlive)
                    foe.Health = 0;
            }    
        }

        public void Heal(Character foe, int healthHealed)
        {
            if(this == foe)
            {
                if (foe.Health + healthHealed > 1000)
                    foe.Health = 1000;
                else
                    foe.Health += healthHealed;
            }
        }
    }
}