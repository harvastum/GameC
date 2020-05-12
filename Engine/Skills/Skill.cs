using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    public abstract class Skill
    {
        // a class representing a generic skill
        public string type;
        public string PublicName { get; protected set; } // a name to be displayed in the game
        public int StaminaCost { get; protected set; } // how much does this spell cost
        public int MinimumLevel { get; protected set; } // what level do you need to learn it
        public string RequiredItem { get; protected set; } // possible items to require: "axe", "sword", "spear", "staff"
        public string Name { get; set; } // short name
        public Skill decoratedSkill = null; // only decorator will use this (but it has to be here)
        protected Skill(string name, int stamina, int minLevel) // for derived classes
        {
            Name = name;
            PublicName = name;
            StaminaCost = stamina;
            MinimumLevel = minLevel;
        }
        public override string ToString()
        {
            return "[" + StaminaCost + " stamina] " + PublicName;
        }
        public abstract List<StatPackage> BattleMove(Player player);

    }
}
