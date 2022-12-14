# Fps Chess
 
FPS Chess ReadMe

HOW TO PLAY:
P1 must use keyboard, p2 must use Xbox controller. Press G on keyboard and Y on controller to swtich weapons
Right click and L2 are used for zoom, movement is standard WASD and joystick
The gun does not have a dedicated reload button, the gun auto reloads after out of ammo
Sudden death starts after 30 seconds and will always start countdown 30 secs after a piece has been moved

After one player wins, the winner controls the chess pieces with PLAYER ONE'S MOUSE. No matter the winner
The person who won will always move the chess piece facing toward them, the board rotates per user
No pause menu has been implemented, and there are no handicaps. The worse player should be on keyboard and mouse since its easier (Reccomended)

POWERUPS:
TO gain a powerup, a user must shoot THEIR OWN chess pieces. The powerups are corresponded to the particles

SCRIPTS:
Scripts can be found under Fps-Chess/Software Development/Assets/Scripts/

ChessLogic - Logic for the chess, checks for win conditions and literal chess logis
Cube - Was created for testing, is not used in game, used for debug
MouseDrag - Used to control the movement of chess pieces, how the user interacts with the pieces
ParticleDestroy - Script is used to destroy particles, any object with the script auto destroys 1 second after creation
ResetAll - After a round is played, this script resets the health and shield and sudden death, calls once per round
SuddenDeath - Script used to control the wall of sudden death and the sudden death features

Scripts > P1
Bullet - Used to control p1 bullets and logic and collisions as well as power ups
Menu - Used to control which weapon the user is holding, will be used more once upgrades are implemented
MouseLook - Used to control the main camera for p1, used with mouse
PlayerMovement - Controls all movement of player 1, as well as collision methods and damage / shield / health
Shoot - Used to instantiate bullet prefab as well as reload and canshoot delays
Swing - Logic for the lightsaber and collisions
UpgradeMenu - Not implemented yet, will be where future upgrades will be held. Not created for p2 use yet

Scripts > P2
Bullet - Used to control P2 bullets and logic and collisions as well as power ups
Menu - Used to control which weapon the user is holding, will be used more once upgrades are implemented
MouseLook - Used to control the main camera for P2 used with mouse
PlayerMovement - Controls all movement of player 2, as well as collision methods and damage / shield / health
Shoot - Used to instantiate bullet prefab as well as reload and shoot delays
Swing - Logic for the lightsaber and collisions

DEBUG - 
If a user presses r on the keyboard, ALL PLAYER'S health and shield will reset, this is used at both user's agreement
