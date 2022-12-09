using Raylib_cs;
using System.Numerics;

class Video
{
    private bool debug = false;

    int MAX_X = 690;
    int MAX_Y = 510;
    string CAPTION = "Labyrinth";
    int FRAME_RATE = 15;
    int CELL_SIZE = 30;

    Color black = Color.BLACK;

    /// <summary>
    /// Constructs a new instance of KeyboardService using the given cell size.
    /// </summary>
    /// <param name="cellSize">The cell size (in pixels.</param>
    public Video(bool debug)
    {
        this.debug = debug;
    }
    /// <summary>
    /// Closes the window and releases all resources.
    /// </summary>
    public void CloseWindow()
    {
        Raylib.CloseWindow();
    }
    /// <summary>
    /// Clears the buffer in preparation for the next rendering. This method should be called at
    /// the beginning of the game's output phase.
    /// </summary>
    public void ClearBuffer()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(black);
        if (debug)
        {
            DrawGrid();
        }
    }
    /// <summary>
    /// Draws the given actor's text on the screen.
    /// </summary>
    /// <param name="actor">The actor to draw.</param>
    public void DrawHeart(Heart theObject)
    {
        Texture2D texture = theObject.GetTexture();
        int Y = theObject.GetY();
        int X = theObject.GetX();
        Raylib.DrawTexture(texture, X, Y, Color.RED);
    }

    public void DrawWeapon(Weapon theObject)
    {
        Texture2D texture = theObject.GetTexture();
        int Y = theObject.GetY();
        int X = theObject.GetX();
        Raylib.DrawCircle(X + 15, Y + 15, 13, Color.LIGHTGRAY);
        Raylib.DrawTexture(texture, X + 2, Y + 2, Color.BLACK);
    }

    public void DrawTreasure(Treasure theObject)
    {
        Texture2D texture = theObject.GetTexture();
        int Y = theObject.GetY();
        int X = theObject.GetX();
        Raylib.DrawTexture(texture, X, Y, Color.LIGHTGRAY);
    }


    public void DrawTile(TileOutline theObject)
    {
        int X = theObject.GetX();
        int Y = theObject.GetY();
        int size = CELL_SIZE - 2;
        Color color = theObject.GetColor();
        Raylib.DrawRectangleLines(X, Y, size, size, color);
    }

    public void DrawTextObject(TextObject theObject)
    {
        string text = theObject.GetText();
        int X = theObject.GetX();
        int Y = theObject.GetY() - 3;
        int FontSize = theObject.GetFontSize();
        Color color = theObject.GetColor();
        Raylib.DrawText(text, X, Y, FontSize, color);
    }

    public void DrawLine(Vector2 startpos, Vector2 endpos, Color color)
    {
        Raylib.DrawLineV(startpos, endpos, color);
    }
    /// <summary>
    /// Draws the given list of actors on the screen.
    /// </summary>
    /// <param name="actors">The list of actors to draw</param>
    public void DrawTextObjects(List<TextObject> objects)
    {
        foreach (TextObject theObject in objects)
        {
            DrawTextObject(theObject);
        }
    }
    
    /// <summary>
    /// Copies the buffer contents to the screen. This method should be called at the end of
    /// the game's output phase.
    /// </summary>
    public void FlushBuffer()
    {
        Raylib.EndDrawing();
    }
    /// <summary>
    /// Whether or not the window is still open.
    /// </summary>
    /// <returns>True if the window is open; false if otherwise.</returns>
    public bool IsWindowOpen()
    {
        return !Raylib.WindowShouldClose();
    }

    /// <summary>
    /// Opens a new window with the provided title.
    /// </summary>
    public void OpenWindow()
    {
        Raylib.InitWindow(MAX_X, MAX_Y, CAPTION);
        Raylib.SetTargetFPS(FRAME_RATE);
    }
    /// <summary>
    /// Draws a grid on the screen.
    /// </summary>
    private void DrawGrid()
    {
        for (int x = 0; x < MAX_X; x +=CELL_SIZE)
        {
            Raylib.DrawLine(x, 0, x, MAX_Y,Raylib_cs.Color.GRAY);
        }
        for (int y = 0; y < MAX_Y; y +=CELL_SIZE)
        {
            Raylib.DrawLine(0, y, MAX_X, y,Raylib_cs.Color.GRAY);
        }
    }

}

