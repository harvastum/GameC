using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters.MonsterFactories
{
    public class ElephantFactory : Engine.Monsters.MonsterFactories.MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (Index.RNG(0, 100) < 20) return null; // Elephants have spawn rate of 20%

            Monster monster;
            if (encounterNumber % 5 == 0) // return evolved elephant every third encounter
            {
                monster = new ElephantEvolved(playerLevel);
            }
            else
            {
                monster = new Elephant(playerLevel);
            }
            encounterNumber++;
            return monster;
        }
        // GetImage should be static.
        public override System.Windows.Controls.Image Hint()
        {
            return (encounterNumber % 5 == 0) ?
                new ElephantEvolved(0).GetImage() : new Elephant(0).GetImage();
        }
    }
}
