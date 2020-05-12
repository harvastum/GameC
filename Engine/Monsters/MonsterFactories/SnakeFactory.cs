using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine.Monsters.MonsterFactories
{
    public class SnakeFactory : MonsterFactory
    {        // this factory produces snakes (and evolved snakes)

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            Monster monster;
            if (encounterNumber %2== 0) // return evolved snake every other encounter
            {
                monster = new Snake(playerLevel);
            }
            else 
            {
                monster =  new SnakeEvolved(playerLevel);
            }
            encounterNumber++;
            return monster;
        }
        public override System.Windows.Controls.Image Hint()
        {
            return (encounterNumber % 2 == 0) ?
                new Snake(0).GetImage() : new SnakeEvolved(0).GetImage(); 
        }
    }
}