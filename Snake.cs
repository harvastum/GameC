using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using Game.Engine;

namespace Game
{
    public class Snake : Engine.Monsters.Monster
    {
        public Snake(int level)
        {
            Health = 20 + 8 * level;
            Strength = 10 + level;
            Armor = 2* level;
            Precision = 80;
            MagicPower = 10+level*10;
            Stamina = 70;
            XPValue = 40 + level + level/2   ;
            Name = "monster0003";
            BattleGreetings = "Don't come too close, I bite!"; // rat doesn't say anything
        }

        public override List<StatPackage> BattleMove()
        {
            List < StatPackage > attack = new List<StatPackage>();
            attack.Add(new StatPackage("stab",10 + strength, $"Snake bit you! (+{10 + strength} stab damage!"));
            if (Stamina > 5)
            {
                 attack.Add(new StatPackage("poison", MagicPower/5, $"It's a venomous bite! (+{MagicPower / 5} poison damage)"));
            }
            return attack;
        }
    }
}