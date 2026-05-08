# Store Simulation-Console

A lightweight, D&D 3.5 inspired dungeon crawler built in C#. Designed for high performance and minimal memory usage through the use of 16-bit integers and optimized memory referencing.

## Getting Started

### Prerequisites

* .NET 10.0 SDK or higher.
* A terminal/console that supports ANSI colors (standard on Win10/11, Linux, and macOS).

### Installation & Run

1. Clone the repository:
```bash
git clone https://github.com/YourUsername/StoreSimulation.git

```


2. Navigate to the project folder:

```bash
   cd StoreSimulation

```

3. Run the project:

```bash
   dotnet run

```

## How to Play

| Key | Action |
| --- | --- |
| W, A, S, D | Move Character (@) |
| P | Pause Game / Access Save Menu |
| < / > | Use Stairs to change floors |
| Enter | Confirm Menu Selection |

## Technical Overview

This simulation utilizes C# namespaces to maintain a modular architecture:

* **Globals**: Manages Player and Enemy entity data and ability scores using Int16 for memory efficiency.
* **DungeonCrawler**: Handles the core game loop and state transitions between menus and gameplay.
* **PlayerInput**: Manages keyboard interactions, boundary checking, and collision detection.
* **SaveSystem**: Handles persistent data storage via JSON serialization for character stats.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
