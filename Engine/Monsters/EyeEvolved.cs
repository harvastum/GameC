using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters
{
    public class EyeEvolved : Engine.Monsters.Monster
    {
        public EyeEvolved(int level)
        {
            Health = 300 + 10 * level;
            Strength = 30 + level / 2;
            Armor = 10 * level / 2;
            Precision = 150 + level*2;
            MagicPower = 100 + level * 30;
            Stamina = 150;
            XPValue = 250 + level * 4;
            Name = "monster0006";
            BattleGreetings = "Get lazed!";
        }

        public override List<StatPackage> BattleMove()
        {
            List<StatPackage> attack = new List<StatPackage>();
            attack.Add(new StatPackage("fire", 10 + strength,
                $"GoldenEye lazed you! (+{50 + magicPower / 10} fire damage!"));
            if (MagicPower > 20 && Index.RNG(0, 100) > 50)
            {
                MagicPower -= 20;
                attack.Add(new StatPackage("fire", MagicPower / 5,
                    $"The beam was super wide! (+{MagicPower / 4} poison damage)"));
                XPValue += 20;
            }

            if (Stamina > 20 && Index.RNG(0, 100) > 97)
            {
                Stamina -= 40;
                attack.Add(new StatPackage("none", 0, $"Eye blinked."));
            }
            return attack;
        }
    }
}