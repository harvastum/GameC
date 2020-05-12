using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters
{
    public class ElephantEvolved : Engine.Monsters.Monster
    {
        public ElephantEvolved(int level)
        {
            Health = 600 + 80 * level;
            Strength = 250 + level;
            Armor = 150 * level / 3;
            Precision = 70 + level;
            MagicPower = 25 + level * 20;
            Stamina = 500;
            XPValue = 300 + level * 10;
            Name = "monster0008";
            BattleGreetings = "YOU HAVE BROUGHT MY ANGER UPON YOURSELF";
        }

        public override List<StatPackage> BattleMove()
        {

            List<StatPackage> attack = new List<StatPackage>();
            attack.Add(new StatPackage("none", (Index.RNG(0, 100) > Precision)? Strength/2+magicPower/2:0));

            if (Stamina > 50)
            {
                Stamina -= 50;
                attack.Add(new StatPackage("earth", 100 + strength / 2,
                    $"Elephant used Earthquake! It's super effective! (+{50 + magicPower / 10} fire damage!"));
            }
            else
            {
                Strength -= 50;
                attack.Add(new StatPackage("none", 0,
                    $"Elephant is tired."));
            }

            if (Index.RNG(0, 100) > 60)
            {
                Stamina += 50;
                attack.Add(new StatPackage("none", 0,
                    $"Elephant ate a tree  and regained stamina!"));
            }

            return attack;
        }
    }
}