using System.Numerics;
using Raylib_cs;

namespace FloppyCs;

public class GameState
{
    public const int Time = 10;
    public const int TUBE_WIDTH = 80;
    public const int MAX_TUBES = 100;
    public const int FLOPPY_RADIUS = 24;
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 450;
    public bool GameOver { get; set; }
    public bool Pause { get; set; }
    public int Score { get; set; }
    public int HighScore { get; set; }

    public Floppy Floppy { get; set; }

    public int TubeSpeedX { get; set; } = 0;
    public List<Tubes> Pipes = new List<Tubes>();
    public List<Vector2> PipePos = new List<Vector2>();

    public bool Superfx { get; set; } = false;
    public string Content { get; set; } = "Start";
    public float Target { get; set; } = 0f;

    public void InitGame() { }

    public void UpdateGame()
    {
        Content = $"\t\t\t\t\t\t\t\t\t\t\tRayMans\n{Guid.CreateVersion7().ToString()}";
        Target += Raylib.GetFrameTime() / Time;
        if (Target >= 1.0f)
            Target = 0.0f;
    }

    public void DrawGame()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Lerp(Color.SkyBlue, Color.Purple, Target));
        Raylib.DrawText(Content, 125, 220, 30, Color.Black);
        Raylib.EndDrawing();
    }

    public void UpdateDrawFrame()
    {
        UpdateGame();
        DrawGame();
    }
}
