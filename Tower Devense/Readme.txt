In the demo video you can see my Tower Defense project. Everything was created from scratch.
What I have used: Unity 3D, Visual Studio 2017 and Blender.

:::PLAY PRINCIPLE:::
-The player can build defensive building and send enemy waves to another player
-On the beginning the each player has a static amount of "Gold" and "Income"
-Each player earns every [X] secs of his [income] in "Gold"
-With the sending of enemy waves, each player can increases his "Income"
-Each player gets [X] "Bounty" as "Gold" after he destroys an enemy
-With higher "Income" and "Gold" the each player unlocks better defensive structures and enemy wave types
-The first player with 0 "Lives" looses the game

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
RIGHT NOW THERE IS ONLY A TESTABLE VERSION WHERE ONE PLAYER CAN BUILD TOWERS AND SEND ENEMYS TO ONESELF
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

:::UI FEATURES:::
-On the top you can see the most important stats
-On the bottom you can see a small menue for tower building and sending enemys waves
-Building towers or sending enemys costs "Gold". If there is not enough "Gold" the button will turn red and gets disabled
-If u press an enemy sending button longer then [X] secs, the "Enemys" will be send in Burst mode as long the button keeps to be pressed

:::GAME MECHANICS:::
DEFENSE TOWERS
-With pressing on a build tower button, you can build a tower in a pre defined grid
-If a tower can not be build on a wished position, it will turn red
-While tower building, the tower indicates with a circle, how far it can shoot
-If an enemy is in range, the tower automaticly turns to the enemy and beginns shooting at it, until the enemy leaves the range or get destroyed

ENEMYS
-Each enemy is walking on the Unitys given path finding system from top to down
-Each enemy has a healthbar on top
-Enemys gets destroyed when their health drops to 0
