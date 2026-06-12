# Detached
 
A 2D top-down arena shooter built in **Unity 6** with C# and the 2D Universal Render Pipeline. Fight through waves of enemies room by room and take down a two-phase boss.
 
 
<p align="left">
  <img src="https://img.shields.io/badge/Unity-6000.0-000000?style=flat&logo=unity&logoColor=white" alt="Unity 6"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/Render-2D%20URP-264de4?style=flat" alt="2D URP"/>
</p>
## About
 
Detached is a fast-paced top-down shooter where you clear arena rooms full of enemies, survive escalating waves, and face a boss encounter that shifts into a more aggressive second phase. It was developed as a university project at **SRH Berlin University of Applied Sciences**, covering Unity gameplay programming — combat, enemy AI, wave management, and game-state flow — alongside original pixel art created by the team.
 
## Features
 
- 🎮 **Twin-stick-style combat** — WASD movement (Unity Input System) with independent mouse aiming via an orbiting weapon
- 🌊 **Escalating wave system** — enemies spawn in growing waves from randomized points; clearing a room opens a gate to the next
- 🤖 **Enemy AI** — enemies pursue the player and return fire
- 👾 **Two-phase boss fight** — the boss switches to a faster, more aggressive attack pattern once its health drops below half
- 🚪 **Room-based progression** — move between distinct rooms, including a dedicated boss arena
- ❤️ **Health & UI** — slider-based health bars for the player and boss
- 🔊 **Audio system** — centralized `AudioManager` for sound effects
## Controls
 
| Action | Input |
| --- | --- |
| Move | `W` `A` `S` `D` |
| Aim | Mouse |
| Shoot | Left Mouse Button |
 
## Built With
 
- **Unity 6** (`6000.0.59f2`)
- **C#**
- **2D Universal Render Pipeline (URP 17)**
- **Unity Input System**
- **TextMesh Pro**
- **Aseprite** — all sprites and pixel art created by the team
## Getting Started
 
1. Clone the repository:
```bash
   git clone https://github.com/arturbui/Detached.git
```
2. Open **Unity Hub** and add the cloned folder as a project.
3. Open it with **Unity 6 (6000.0.59f2 or compatible)** — Unity Hub will prompt to install the matching editor if needed.
4. Open a scene from `Assets/Scenes/` (e.g. `SampleScene` to start, or `BossRoom` to test the boss) and press **Play**.
## Project Structure
 
```
Assets/
├── Scenes/        # SampleScene (main), BossRoom
├── Scripts/       # Gameplay code
│   ├── PlayerController, Shooting, PointerRotation, PlayerHealth
│   ├── Enemy, Bullet, BulletMove
│   ├── WaveManager, RoomManager, RoomTransition
│   ├── BossController, BossHealth
│   └── AudioManager
└── Settings/      # URP 2D render pipeline settings
```
 
## Roadmap
 
<!-- Optional — delete if you don't want it. Shows reviewers you think about iteration. -->
- [ ] Add a main menu and game-over / victory screens
- [ ] More enemy types and attack patterns
- [ ] Pickups (health, weapon upgrades)
- [ ] Build & host a playable WebGL demo
## Authors
 
A university project for **SRH Berlin University of Applied Sciences**, created by:
 
- **Artur Buivydis**
- **Mantas Grušauskas**

All sprites and pixel art were created by the team using **Aseprite**.
