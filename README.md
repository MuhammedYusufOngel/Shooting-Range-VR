# 🎯 Shooting Range VR

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![VR](https://img.shields.io/badge/VR-Ready-blue?style=for-the-badge)

A Virtual Reality Shooting Range experience built with Unity and the XR Interaction Toolkit. Step into a virtual environment, grab your weapon, and test your accuracy!

> 🚧 **Work in Progress:** This project is currently under active development. Features and mechanics are subject to change and continuous improvement.

## ✨ Features

- **VR Hands & Interaction:** Fully animated VR hands that respond to user input (`AnimateHandOnInput`).
- **Weapon Handling:** Grab and shoot firearms seamlessly in VR.
- **Shooting Mechanics:** Fire physical bullets upon trigger activation (`FireBulletOnActivate`).
- **Laser Sights:** Precision aiming with integrated gun laser pointers (`GunLaserPointer`).
- **Dynamic Targets:** Target spawning and interaction mechanics (`CreateTarget`, `TargetController`).
- **Immersive Environment:** Built specifically for VR headsets (Oculus/Meta Quest, etc.).

## 🛠️ Built With

- **Unity Game Engine**
- **XR Interaction Toolkit** (Unity's official framework for VR/AR interactions)
- **C#** Scripting

## 🚀 Getting Started

### Prerequisites

- Unity Hub and a compatible Unity version (check ProjectSettings for the exact version).
- A VR Headset (e.g., Meta Quest 2/3, Valve Index, HTC Vive) or the XR Device Simulator.
- SteamVR or Oculus Desktop app running in the background.

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/MuhammedYusufOngel/Shooting-Range-VR.git
   ```
2. **Open the project:** Launch Unity Hub, click on "Add", and select the `Shooting-Range-VR` folder.
3. **Open the main scene:** Navigate to `Assets/Scenes` and open the primary VR scene.
4. **Play:** Press the Play button in the Unity Editor to start the experience in your connected VR headset.

## 📁 Project Structure highlights

- `Assets/Scripts/`: Contains the core logic for the VR interactions.
  - `FireBulletOnActivate.cs`: Handles weapon firing logic.
  - `GunLaserPointer.cs`: Controls the aiming laser visual and logic.
  - `CreateTarget.cs` & `TargetController.cs`: Manage the shooting targets.
  - `AnimateHandOnInput.cs`: Controls the avatar hand animations based on controller grip/trigger inputs.
- `Assets/Prefabs/`: Reusable game objects like weapons, bullets, and targets.
- `Assets/Oculus Hands/`: Assets for VR hand representation.
- `Assets/Pistol 92/`: 3D models and materials for the primary firearm.

## 🤝 Contributing

Since this is a work in progress, feedback and contributions are welcome! 
Feel free to open an issue or submit a pull request if you have ideas for new features or improvements.

---
*Developed by [Muhammed Yusuf Öngel]*
