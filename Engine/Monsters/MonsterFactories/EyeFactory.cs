using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    public class EyeFactory : Engine.Monsters.MonsterFactories.MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            Monster monster;
            if (encounterNumber % 3 == 0) // return evolved eye every third encounter
            {
                monster = new EyeEvolved(playerLevel);
            }
            else
            {
                monster = new Eye(playerLevel);
            }
            encounterNumber++;
            return monster;
        }
        // GetImage should be static.
        public override System.Windows.Controls.Image Hint()
        {
            return (encounterNumber % 3 == 0) ?
                new EyeEvolved(0).GetImage() : new Eye(0).GetImage();
        }
    }
}
