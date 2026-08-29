using System.Numerics;
using Raylib_cs;

namespace FloppyCs;

// using classic raylib pattern:
// 1. InitWindow()
// 2. Run main loop while window persists:
//  - Begin drawing: Setup the canvas to start drawing
//  - Clear canvas: to draw on a clean background
//  - End drawing: End canvas drawing
// 3. CloseWindow()

public struct Floppy
{
    public Vector2 position;
    public int radius;
    public Color color;
};

public struct Tube
{
    public Rectangle rectangle;
    public Color color;
    public bool isActive;
}

internal static class Program
{
    static void Main(string[] args)
    {
        // initialization
        GameState game = new();
        Raylib.InitWindow(GameState.SCREEN_WIDTH, GameState.SCREEN_HEIGHT, "Floppy Bird");
        game.InitGame();
        Raylib.SetTargetFPS(60);

        // main game-loop
        while (!Raylib.WindowShouldClose())
        {
            game.UpdateDrawFrame();
        }

        // De-Initialization
        Raylib.CloseWindow();
    }
}
