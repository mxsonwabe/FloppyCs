# FloppyCs

A **Flappy Bird**–style game written in C# using the [Raylib-cs](https://github.com/raysan5/raylib-cs) binding.

Guide the red "floppy" through gaps in scrolling green tubes. Flap to stay aloft, dodge the tubes, and rack up the high score.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- `Raylib-cs` 8.0.0 (pulled in automatically via NuGet)
- A desktop environment with an OpenGL-capable display (Raylib opens its own window)

## Build & Run

```bash
dotnet run
```

Or to build a standalone executable:

```bash
dotnet build -c Release
```

Raylib's native libraries are resolved by the `Raylib-cs` package, so no separate install is required on supported platforms.

## Controls

| Key       | Action                          |
| --------- | ------------------------------- |
| `Space`   | Flap up (hold to rise)          |
| `P`       | Pause / resume the game         |
| `Enter`   | Restart after a game over       |

If the floppy hits a tube, the game ends and shows a "PRESS [ENTER] TO PLAY AGAIN" prompt.

## Gameplay

- The floppy constantly drifts downward; holding `Space` lifts it.
- Tubes scroll from right to left. Passing a tube awards **+100** points and flashes the screen.
- Your **High Score** is tracked across rounds in the current session.
- Press `P` any time (while alive) to pause; a "GAME PAUSED" overlay appears.

## Project Structure

| File               | Purpose                                                       |
| ------------------ | ------------------------------------------------------------- |
| `Program.cs`       | Application entry point, window init, and the main game loop  |
| `GameState.cs`     | Game state, update logic, rendering, and tube management      |
| `FloppyCs.csproj`  | Project file (targets `net10.0`, references `Raylib-cs`)      |

### Key Constants (`GameState.cs`)

| Constant          | Value | Description                    |
| ----------------- | ----- | ------------------------------ |
| `SCREEN_WIDTH`    | 800   | Window width in pixels         |
| `SCREEN_HEIGHT`   | 450   | Window height in pixels        |
| `FLOPPY_RADIUS`   | 16    | Radius of the floppy           |
| `TUBE_WIDTH`      | 80    | Width of each tube             |
| `MAX_TUBES`       | 100   | Number of tube pairs           |
| `TubeSpeedX`      | 2     | Horizontal scroll speed        |

## How It Works

The program follows the classic Raylib pattern:

1. `InitWindow()` — open an 800×450 window titled "Floppy Bird".
2. Main loop (`while (!WindowShouldClose())`) — each frame calls `UpdateDrawFrame()`, which updates game state and renders.
3. `CloseWindow()` — clean up on exit.

Collision is detected with `CheckCollisionCircleRec` between the floppy (a circle) and each tube rectangle.

## Known Issues

None currently. A previous git merge conflict in `GameState.cs` (around the `DrawGame` bird-drawing block) has been resolved.
