using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Engine;

namespace Game
{
    public class SnakeEvolved : Engine.Monsters.Monster
    {
        public SnakeEvolved(int level)
        {
            Health = 80 + 8 * level;
            Strength = 20 + level + level/2;
            Armor = 5 * level;
            Precision = 85;
            MagicPower = 30 + level * 20;
            Stamina = 150;
            XPValue = 150 + level + level / 2;
            Name = "monster0004";
            BattleGreetings = "Get ready to lose your breath and body!"; 
        }

        public override List<StatPackage> BattleMove()
        {
            List<StatPackage> attack = new List<StatPackage>();
            attack.Add(new StatPackage("stab", 10 + strength, $"Anaconda bit you! (+{10 + strength} stab damage!"));
            if (Stamina > 5)
            {
                Stamina -= 5;
                attack.Add(new StatPackage("poison", MagicPower / 5, $"It's a venomous bite! (+{MagicPower / 4} poison damage)"));
            }

            //This if could be nested inside the above if, if performance becomes an issue.
            if (Stamina > 50)
            {
                Stamina -= 50;
                attack.Add(new StatPackage("choke", Strength * 2 / 5, $"Anaconda wrapped around your neck! You're being choked! (+{Strength*2} choke damage)"));
            }
            return attack;
        }
    }
}