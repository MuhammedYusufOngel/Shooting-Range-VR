# Shooting Range VR

## Overview
Shooting Range VR is a Virtual Reality target shooting application built with Unity 6 and the XR Interaction Toolkit (XRI). The application provides timed target practice rounds where target distance and spatial precision scale dynamically across levels.

The project demonstrates core XR development patterns, including custom interaction handlers, event-driven firearm mechanics, physics-based target destruction, real-time spatial UI positioning, and live performance metrics tracking.

## Demo
You can click and watch the demo.
[![Shooting Range VR Demo Placeholder](https://img.youtube.com/vi/gWEm168imdw/maxresdefault.jpg)](https://youtu.be/gWEm168imdw)

## Key Features
- **Event-Driven Firearm Mechanics**: Custom grab interaction logic triggers projectile spawning, applies linear velocity, fires muzzle flash particle effects, plays shot audio, and logs shot telemetry upon trigger input.
- **Raycast Laser Aiming**: Real-time laser pointer extending from the firearm muzzle, calculating impact endpoints dynamically up to 50 meters using layer-masked physics raycasts.
- **Physics-Based Target Destruction**: Collision-triggered mesh swapping replaces solid targets with multi-fragment rigidbodies, applying directional explosion forces calculated from the exact impact point.
- **Dynamic Difficulty Escalation**: Level progression system that automatically moves the target wall 5 units farther back upon clearing score thresholds, increasing shooting distance and aiming difficulty.
- **Gaze-Anchored Diegetic UI**: World-space UI elements (pre-round countdown, level completion overlays, and pause menu) dynamically positioned in front of player gaze using HMD transform vectors and billboard orientation.
- **Real-Time Performance Metrics**: Spatial HUD tracking player score, total bullets fired, a 30-second round timer, and calculated accuracy efficiency (`Score / Bullets`).

## Technical Implementation

### XR Interaction & Input Architecture
The interaction system relies on Unity's **XR Interaction Toolkit (v3.4.1)** and **Unity Input System (v1.19.0)**.
- **Custom Grab Interactable**: `GunGrabController` extends `XRGrabInteractable` to detect `OnSelectEntered` events when the player grips the firearm, automatically initializing pre-round countdown states if the timer is idle.
- **Event-Driven Activation**: `FireBulletOnActivate` hooks into the `activated` listener on the grab interactable. When the trigger is pulled, it instantiates bullet rigidbodies, assigns linear velocity (`firePoint.forward * bulletSpeed`), triggers particle and sound effects, and updates central telemetry without continuous frame polling.
- **Hand Controller Animation**: `AnimateHandOnInput` reads float inputs from `InputActionProperty` references (`pinchAnimationAction` and `gripAnimationAction`) to drive Animator parameters (`Trigger` and `Grip`), blending virtual hand poses with hardware inputs.

### Physics, Ballistics & Destructible Targets
- **Laser Aim Pointer**: `GunLaserPointer` uses a continuous `LineRenderer` updated per frame. It performs `Physics.Raycast` against targeted layer masks to align the laser end point with object geometry or extend to max range (50 units).
- **Impact & Mesh Fracture**: Target collision detection is handled in `TargetController`. Bullet hits retrieve impact coordinates via `Collider.ClosestPointOnBounds`. `BreakableTarget` deactivates the intact mesh, enables a multi-fragment prefab hierarchy (`Broken_pieces.fbx`), unparents the fragment root transform to isolate physics calculations, and applies radial explosion impulses via `Rigidbody.AddExplosionForce`.

### State Management & Spatial Progression
- **Central State Management**: `PlayerController` acts as a central manager for score tracking, ammo counting, level state, and timer loops. Target score requirements scale dynamically per level (`score >= maxScore * level`).
- **Procedural Level Scaling**: Upon reaching level targets, `LevelDesign()` moves the background target wall geometry 5 units farther along the Z-axis (`wall.position.z - 5f`), resets the 30-second timer, and prepares the next episode. Failing a round resets wall position coordinates to default (`-22f, 2.5f, 2f`).
- **Diegetic UI Positioning**: `CounterController`, `EpisodeController`, and `GameMenuController` compute world-space canvas positions based on headset transform data (`head.position + forward * spawnDistance`) and apply billboard orientation facing the HMD (`LookAt`).

## Technical Challenges and Solutions

- **Challenge**: Fragmented target pieces remained parented to the target root transform, inheriting parent transform shifts and producing unexpected physics collisions during explosion impulses.
- **Approach or solution**: Unparented the fragment root hierarchy (`fragmentsRoot.transform.parent = null`) prior to calling `AddExplosionForce` on child rigidbodies and implemented auto-destruction timers for debris cleanup.
- **Result or trade-off**: Achieved clean mesh fragmentation in world space, with a small trade-off of managing garbage collection via timed object destruction (`Destroy(fragmentsRoot, fragmentLifetime)`).

- **Challenge**: Static world-space UI canvases became hard to read or clipped into environment geometry when the player moved within their physical tracking space.
- **Approach or solution**: Calculated canvas placement procedurally in script `Update` loops based on headset position and forward vector offsets, orienting canvases toward player gaze.
- **Result or trade-off**: Maintained readable diegetic UI regardless of player location, requiring continuous transform updates while canvases are active.

- **Challenge**: Determining optimal target spawning bounds dynamically on a moving wall surface across levels.
- **Approach or solution**: `CreateTarget` reads wall scale dimensions (`localScale.x`, `localScale.y`) at runtime and samples random float coordinates bounded within wall surface extents before spawning targets.
- **Result or trade-off**: Ensures targets remain contained on wall surfaces regardless of wall placement, though target count is currently restricted to small simultaneous bounds.

## Technologies
- **Engine**: Unity 6 (`6000.4.5f1`)
- **XR SDK**: XR Interaction Toolkit (XRI) `v3.4.1`
- **Render Pipeline**: Universal Render Pipeline (URP) `v17.4.0`
- **Input System**: Unity Input System `v1.19.0`
- **UI Framework**: TextMesh Pro `v3.0.9`
- **Language**: C#

## Project Structure
```
Shooting-Range-VR/
├── Assets/
│   ├── Scripts/                 # Core C# scripts (XRI interaction, game state, UI, physics)
│   │   ├── AnimateHandOnInput.cs # XR controller input to hand animator blending
│   │   ├── BreakableTarget.cs    # Mesh fragmentation and impulse physics
│   │   ├── CreateTarget.cs       # Bounded target instantiation
│   │   ├── EpisodeController.cs  # Level transition overlays and gaze anchoring
│   │   ├── FireBulletOnActivate.cs# Event-driven bullet firing mechanics
│   │   ├── GunGrabController.cs  # Subclassed XRGrabInteractable for round initialization
│   │   ├── GunLaserPointer.cs    # Raycast LineRenderer sight indicator
│   │   ├── PlayerController.cs   # Singleton game manager, scoring, level progression
│   │   └── TargetController.cs   # Collision detection and score triggers
│   ├── Prefabs/                 # XR Origin rig, firearms, targets, breakable meshes
│   ├── Scenes/                  # Main VR shooting range scene (SampleScene.unity)
│   ├── InputSystem_Actions      # Unity Input System action maps for XR controllers
│   └── Oculus Hands/            # Animated VR hand assets and pose models
├── Packages/
│   └── manifest.json            # Unity package dependencies
└── ProjectSettings/             # Project configurations and XR setting definitions
```

## Setup

### Prerequisites
- **Unity Hub** with **Unity 6 (`6000.4.5f1`)** installed.
- **Unity XR Device Simulator** (included via XRI package samples) OR an **OpenXR-compatible VR Headset** (Meta Quest, Valve Index, etc.) connected to PC.

### Building & Running
1. **Clone the repository**:
   ```bash
   git clone https://github.com/MuhammedYusufOngel/Shooting-Range-VR.git
   ```
2. **Open in Unity**:
   - Open Unity Hub, click **Add**, and select the cloned project directory.
   - Launch the project in Unity 6 (`6000.4.5f1`).
3. **Open Scene**:
   - In the Project window, navigate to `Assets/Scenes/` and open `SampleScene.unity`.
4. **Run in Editor**:
   - Enable the **XR Device Simulator** in Unity Editor settings (or connect your VR headset via Link/AirLink/SteamVR).
   - Press **Play** in Unity Editor.

## Current Limitations
- **Hardware Testing Environment**: Currently tested using Unity's **XR Device Simulator**. On-device physical hardware validation (e.g. standalone Meta Quest or native PCVR link testing) is pending hardware testing.
- **Weapon Mechanics Scope**: Single firearm type with infinite ammunition capacity; manual reload sockets and magazine ejection mechanics are not yet implemented.
- **Target Wall Offsets**: Level distance scaling shifts wall coordinates by a fixed `-5f` units along the Z-axis, with hardcoded fallback coordinates upon reset.

## Future Improvements
- Validation and tuning on physical VR headsets (Meta Quest 2/3/Pro, Valve Index).
- Interactive magazine sockets and manual slide-rack / reload mechanics.
- Moving target patterns along spline paths or oscillating vectors.
- Haptic feedback profiles mapped to firearm firing events and collision impacts.

## Author
**Muhammed Yusuf Öngel**
- LinkedIn: [LinkedIn Profile](https://www.linkedin.com/in/muhammed-yusuf-öngel-505a04279/)
