using System;
using System.Collections.Generic;
using Game.Engine.Skills.AdvancedSpells;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicSkills;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedSpellFactory : SkillFactory
    {
        // this factory produces skills from BasicSpells directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); 
            if (known == null) 
            {
                FireBolt s1 = new FireBolt();
                EarthBolt s2 = new EarthBolt();
                ElephantBolt s3 = new ElephantBolt();
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null) 
            {
                BoltDecorator s1 = new BoltDecorator(known);
                BoltDecorator s2 = new BoltDecorator(known);
                BoltDecorator s3 = new BoltDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }

            return null;
        }
        private Skill CheckContent(List<Skill> skills)
        {
            foreach (Skill skill in skills)
            {
                if (skill is ElephantBolt||
                    skill is EarthBolt||
                    skill is FireBolt||
                    skill is BoltDecorator) return skill;
            }
            return null;
        }

    }
}
