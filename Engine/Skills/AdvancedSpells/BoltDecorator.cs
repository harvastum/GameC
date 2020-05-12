using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class BoltDecorator : SkillDecorator
    {
        // decorator for Bolt classes
        public BoltDecorator(Skill skill) : base(skill.Name, 20, 4, skill)
        {
            type = skill.type;
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = $"COMBO - {type} Bolt: a chance equal to your Precision stat to land 0.5*MP damage [{type}] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage(type);
            Random rnd = new Random();
            if (rnd.Next(0, 100) < player.Precision)
            {
                response.HealthDmg = (int)(0.5 * player.MagicPower);
                response.CustomText = "You use {type} bolt! (" + (int)(0.5 * player.MagicPower) + $" {type} damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = $"You try to use {type} Bolt but it misses!";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
