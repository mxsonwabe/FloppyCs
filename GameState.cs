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
    public Tube[] Tubes = new Tube[MAX_TUBES * 2];
    public Vector2[] TubePos = new Vector2[MAX_TUBES];

    public bool Superfx { get; set; } = false;
    public string Content { get; set; } = "Start";
    public float Target { get; set; } = 0f;

    public void InitGame()
    {
        // Initialise bird details
        Floppy = new Floppy
        {
            radius = FLOPPY_RADIUS,
            position = new Vector2(0, SCREEN_HEIGHT / 2 - FLOPPY_RADIUS),
            color = Color.Red,
        };
        TubeSpeedX = 2;

        // Initialise position for tubes
        Random rand = new Random();
        for (int i = 0; i < MAX_TUBES; i++)
        {
            TubePos[i] = new Vector2(400 + (280 * i), rand.Next(0, 120));
        }

        // Initialize tube creation
        for (int i = 0; i < MAX_TUBES * 2; i += 2)
        {
            // Initialise `top` tubes
            Tubes[i] = new Tube
            {
                color = Color.Green,
                rectangle = new Rectangle
                {
                    Height = 255,
                    Width = TUBE_WIDTH,
                    X = TubePos[i / 2].X,
                    Y = TubePos[i / 2].Y,
                },
            };

            // Initialise `bottom` tubes
            Tubes[i + 1] = new Tube
            {
                color = Color.Green,
                rectangle = new Rectangle
                {
                    Height = 255,
                    Width = TUBE_WIDTH,
                    X = TubePos[i / 2].X,
                    Y = 600 + TubePos[i / 2].Y - 255,
                },
            };

            Tubes[i / 2] = new Tube
            {
                color = Tubes[i / 2].color,
                rectangle = Tubes[i / 2].rectangle,
                isActive = true,
            };
        }
        Score = 0;
        GameOver = false;
        Superfx = false;
        Pause = false;
    }

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
