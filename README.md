# 🎯 Shooting Range VR

![Unity](https://img.shields.io/badge/Unity-2022%2B-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![VR](https://img.shields.io/badge/VR-XR%20Interaction%20Toolkit-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

An immersive Virtual Reality Shooting Range experience built with **Unity** and the **XR Interaction Toolkit**. Step into a fully interactive VR environment, wield realistic firearms with laser precision, test your speed and accuracy across dynamic episodes, and track your performance in real time!

---

## ✨ Key Features

- 🎮 **VR Hands & Physics Interaction:** Fully animated VR hands that dynamically respond to controller grip and trigger inputs (`AnimateHandOnInput`).
- 🔫 **Weapon Handling & Ballistics:** Grab and shoot firearms in VR with realistic velocity and force calculation (`FireBulletOnActivate`, `GunGrabController`).
- 🔴 **Precision Laser Sight:** Integrated laser visual feedback for accurate aiming and target acquisition (`GunLaserPointer`).
- 🎯 **Dynamic & Breakable Targets:** Responsive targets with destruction mechanics, audio cues, and dynamic spawning logic (`CreateTarget`, `TargetController`, `BreakableTarget`).
- 🏆 **Episode & Level Progression:** Multi-stage episode design where target distances and precision requirements escalate dynamically as you clear levels (`EpisodeController`).
- ⏱️ **Real-Time HUD & Analytics:** In-game spatial UI tracking **Score**, **Bullets Fired**, **Accuracy Efficiency (Score/Bullet ratio)**, and a **30-second Countdown Timer** (`PlayerController`, `CounterController`).
- 📜 **Diegetic Spatial Menus:** World-space menus dynamically positioned and oriented relative to player headset movement (`GameMenuController`).

---

## 🛠️ Built With

- **Unity Game Engine**
- **XR Interaction Toolkit** (Unity's official framework for VR/AR interactions)
- **Unity Input System**
- **TextMesh Pro** (High-quality diegetic spatial UI text)
- **C#** Scripting

---

## 🎮 Gameplay & Controls

| Action | VR Controller Input |
| :--- | :--- |
| **Grab Weapon** | Grip Trigger |
| **Fire Bullet** | Index Trigger |
| **Aim** | Pistol Sight / Laser Pointer |
| **Toggle Menu** | Menu Button (Left/Right Controller) |

---

## 🚀 Getting Started

### Prerequisites

- **Unity Hub** and Unity 2022 LTS or newer.
- A **VR Headset** (Meta Quest 2/3/Pro, Valve Index, HTC Vive) connected via Link/AirLink/Virtual Desktop **OR** the **XR Device Simulator**.
- **Oculus Desktop App** or **SteamVR** active in the background.

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/MuhammedYusufOngel/Shooting-Range-VR.git
   ```
2. **Open the project in Unity:**
   - Launch Unity Hub.
   - Click **Open** / **Add** and select the `Shooting-Range-VR` project directory.
3. **Load the Main VR Scene:**
   - Navigate to `Assets/Scenes/` in the Project Window.
   - Open the primary VR scene.
4. **Run the Experience:**
   - Connect your VR headset or enable the XR Device Simulator.
   - Press **Play** in the Unity Editor.

---

## 📁 Architecture & Script Highlights

- 🧠 `PlayerController.cs`: Central game state manager handling score calculation, bullet count tracking, accuracy metrics, level transition states, and timer logic.
- 🎬 `EpisodeController.cs`: Manages episode progression overlays, level transitions, retry logic, and dynamic UI positioning.
- 🔫 `FireBulletOnActivate.cs`: Controls trigger listening, bullet instantiation, muzzle position velocity, and audio playback.
- 🔴 `GunLaserPointer.cs`: Renders real-time laser sights from the firearm muzzle to target contact points.
- 🎯 `BreakableTarget.cs` & `TargetController.cs`: Handle target collision detection, scoring triggers, and target destruction effects.
- 🖐️ `AnimateHandOnInput.cs`: Blends grip and trigger animations smoothly for virtual hand representations.
- 📋 `GameMenuController.cs`: Controls HUD and menu visibility anchored relative to player gaze.

---

## 👤 Developer & Contact

**Developed by [Muhammed Yusuf Öngel](https://github.com/MuhammedYusufOngel)**  
*Shooting Range VR — Final Release* 🚀
