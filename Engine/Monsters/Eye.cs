using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters
{
    [Serializable]
    public class Eye : Engine.Monsters.Monster
    {
        public Eye(int level)
        {
            Health = 150 + 8 * level;
            Strength = 10 + level / 2;
            Armor = 1 * level/5;
            Precision = 100 + level;
            MagicPower = 40 + level * 20;
            Stamina = 100;
            XPValue = 100 + level * 2;
            Name = "monster0005";
            BattleGreetings = "I see...";
        }

        public override List<StatPackage> BattleMove()
        {
            List<StatPackage> attack = new List<StatPackage>();
            attack.Add(new StatPackage("fire", 10 + strength, $"Eye lazed you! (+{50 + magicPower/10} fire damage!"));
            if (MagicPower > 20 && Index.RNG(0,100) > 70)
            {
                MagicPower -= 20;
                attack.Add(new StatPackage("fire", MagicPower / 5, $"The beam was super wide! (+{MagicPower / 4} poison damage)"));
            }

            return attack;
        }
    }
}