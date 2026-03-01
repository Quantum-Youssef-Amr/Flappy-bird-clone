# Flappy Bird Clone

A Unity-based Flappy Bird clone built to strengthen game development fundamentals and create a portfolio piece. This project demonstrates core game mechanics, scene management, and physics-based gameplay using C#.

## About the Game

Flappy Bird Clone is a simple but challenging game where the player controls a bird that must navigate through pipes by tapping to make it fly. Each successful passage through a pipe gap adds to the score. One collision with a pipe ends the game. It's an engaging exercise in learning game loop mechanics, collision detection, and difficulty curves.

## Project Structure

```
Assets/
├── Scripts/               # Core C# game logic and controllers
├── Sprites/              # 2D graphics and textures for bird, pipes, background
├── Audio/                # Sound effects and background music
├── Animation/            # Animation clips and animator controllers
├── Scenes/               # Game scenes (main menu, gameplay, game over)
├── Settings/             # Game configuration and settings
├── Shaders/              # Custom shaders for visual effects
├── prefabs/              # Reusable game object prefabs (pipes, bird, etc)
├── Font/                 # Custom fonts for UI
├── libraries/            # Third-party libraries and extensions
└── TextMesh Pro/         # TextMesh Pro assets for UI text

Packages/
├── manifest.json         # Project dependencies and package versions
└── packages-lock.json    # Locked versions of dependencies

ProjectSettings/
└── [Various Unity configuration files for build settings, input, quality, graphics, etc]
```

## Getting Started

### Prerequisites
- Unity 2022.3 or later
- Basic knowledge of C# and game development concepts

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/Quantum-Youssef-Amr/Flappy-bird-clone.git
   ```

2. Open the project in Unity:
   - Launch Unity Hub
   - Click "Open" and select the cloned folder
   - Wait for the project to load and compile

3. Play the game:
   - Open the main gameplay scene from `Assets/Scenes/`
   - Press Play in the Unity editor
   - Use space or click to make the bird flap

## Learning Objectives

This project was created to strengthen and demonstrate:

- Unity game engine fundamentals
- C# scripting and object-oriented design patterns
- Physics and collision detection systems
- Scene management and UI workflows
- Game state management (playing, paused, game over)
- Score tracking and data persistence
- Input handling and responsive controls

## Technical Details

- Written in C# using Unity's scripting API
- Uses 2D physics for collision detection and gravity
- Implements coroutines for timing and animations
- Features a simple scoring system with game state management

## Features

- Smooth bird physics and responsive controls
- Procedurally generated or predefined pipe obstacles
- Score tracking system
- Game over and restart functionality
- Sound effects and ambient audio
- Clean, readable codebase suitable for learning
  
---

Made as a learning project for game development. Feel free to explore, modify, and learn from the code!
