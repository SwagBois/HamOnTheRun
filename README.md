Swag Bois - Ham on the Run
========================

## Table of Contents

1. [Overview](#overview)
2. [Gameplay](#release-notes)
    - [Controls](#controls)
3. [Game Design Concepts](#install-guide)
    - [Objective-Driven Gameplay](#objective-driven-gameplay)
    - [3D Character Control](#3d-character-control)
    - [3D World & Physics](#3d-world-and-physics)
    - [Real-Time AI](#real-time-ai)
    - [Polish](#polish)

## Overview

Play as Chris P. Bacon and his friends Swine Flew and Elvis Pigsley to escape
the depths of the slaughterhouse! You will use stealth and platforming to avoid
enemies, solve puzzles and interact with the environment to progress through
levels, and finally, save your pig friends to unlock more powerful abilities!
But don't take our word for it — hear the pleas from Chris P. Bacon himself:

> " Hi my name is Chris P. Bacon! I unfortunately got separated from my friends,
> Swine Flew and Elvis Pigsley, and now I’m stuck in this horrible and scary
> slaughterhouse! PLEASE help me get to safety by getting through these logic
> based levels. I really want to see my friends again! I believe in you! "

## Gameplay

### Controls
- Arrow Keys - Movement
- Z/C - Rotate character/camera
- X - Switches playable character
- Space - Jump 
- ESC - Pause

## Game Design Concepts

### Objective-Driven Gameplay
While we cannot speak for what is fun for everyone, we have a strong sense of
providing players with a challenge and a clear goal to accomplish. Time contraints
work in our favor as we would not have the time to create an expansive sandbox,
with various incoherent features. Instead, we tried to stick to our initial vision
of tightly curated levels, focusing on stealth, puzzle-solving, and platforming.

### 3D Character Control
The way the player interacts with the game is through controlling a 3D pig model. This
pig obeys the laws of physics and can collide and interact with its environment.
It also comes with its own walking animation.

### 3D World and Physics
Apart from our player character (moves and jumps with force and impulse based physics),
our level design also features a 3D world and physics.
Our level design and player character all utilize force driven physics. The player
character moves and jumps with force and impulse based values. Our conveyor belts
and platforms 

### Real-Time AI
Our implementation of real-time AI can be scene in the very first stage. The pig
must use obstacles to avoid the gaze of a robot enemy. This robot patrols a small area
guarding a switch that allows the player to continue to progress. If the robot
detects the player it will attempt to catch the player.

### Polish
Our 3D modeler put a lot of time and hard work into making our game look polished. The most noticeable example of this can be seen in our controllable player character! The 3D models were meticulously crafted, with eyes, ears, limbs and all!
Our animator went a step further and in creating walking animations for
our pigs. The greatest challenge here was to create something visually sound, especially
seeing as our 3D model is not humanoid, and therefore we had to create something from
scratch.

While our controls and level design are still raw and require more playtesting,
we made sure to improve the level presentation in the meantime. The textures
for our surfaces, interactive objects, walls, UI and text throughout the game
are not merely for pleasing the eye, as they also serve as hints for the player.