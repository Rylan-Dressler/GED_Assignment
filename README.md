# GED_Assignment
 
Rylan Dressler 100789399 Contribution 100%

A basic enemy spawning system was created in a 2D Unity scene, along with a player controller and an overarching CharacterScript and GameManager scripts in order to maintain the controllers. Both the player and enemies can move around, using the same logic. The enemies track the player's location. This scene uses, among other things, pooling. Every time an enemy were to die (shooting still needs to be implemented) then instead of the object being destroyed, it would be instead be disabled. When a "new" item is needed to be spawned, the program will instead spawn a pre-disabled enemy.