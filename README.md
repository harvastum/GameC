# What is this?
---
This fork was a homework for my C# class, there is probably nothing interesting to see here for anyone. If you're a recruiter and you're here to judge me, know, that I have received best possible grade and completed the assignment relatively quickly, trying to fulfill the given requirements with relatively low effort. **This code may suck in many ways, but it did what it was supposed to do.**

# Added Classes
## Monsters
 1. Snake, SnakeEvolved
 2. Eye, EyeEvolved
 3. Elephant, EvolvedElephant

## Monster Factories
1. SnakeFactory
2. EyeFactory
3. ElephantFactory

## Items
1. NullMagicHatchet
   * Sets user's and target's magic to 0.
2. ElephantsBane  
    * Halves enemy's HP on attack if it's an elephant.
3. WoodArmor
   * Doubles taken damage if attack type is fire.
4. AdvancedItemFactory


## Spells
1. EarthBolt
2. ElephantBolt
   - Elephant decimating spell (works similarly to ElephantsBane)
3. FireBolt

## Decorators
   - BoltDecorator - it can handle all the Bolt spells
