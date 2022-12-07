using Raylib_cs;
using System.Numerics;

class Turn
{
    Video video;
    Maze maze;
    Keyboard keyboard = new Keyboard();
    int screen;
    List<TextObject> PlayerScreenObjects = new List<TextObject>();
    int CELL_SIZE = 30;
    int MAX_X = 690;

    Color white = Color.WHITE;
    Color black = Color.BLACK;
    Color lightGrey = Color.LIGHTGRAY;
    Color grey = Color.GRAY;
    Color red = Color.RED;
    Color blue = Color.BLUE;
    Color yellow = Color.GOLD;
    Color green = Color.GREEN;
    Color purple = Color.PURPLE;

    bool gameOver = false;
    int playerNumber = 0;
    int fontSize1 = 30;
    int fontSize2 = 25;

    Player player1;
    Player player2;
    Player player3;
    Player player4;
    public Turn(Video Video, Maze Maze)
    {
        video = Video;
        maze = Maze;
        screen = 1;
        CreatePlayerList();
        player1 = new Player(video);
        player2 = new Player(video);
        player3 = new Player(video);
        player4 = new Player(video);
    }

    public void DrawScreen()
    {
        if (screen == 1)
        {
            DrawStartScreen();
        }
        else if (screen == 2)
        {
            DrawBlackout(player1, 1);
        }
        else if (screen == 3)
        {
            DrawPlayerScreen(player1);
            player1.Update();
        }
        else if (screen == 4)
        {
            DrawBlackout(player2, 2);
        }
        else if (screen == 5)
        {
            DrawPlayerScreen(player2);
            player2.Update();
        }
        else if (screen == 6)
        {
            DrawBlackout(player3, 3);
        }
        else if (screen == 7)
        {
            DrawPlayerScreen(player3);
            player3.Update();
        }
        else if (screen == 8)
        {
            DrawBlackout(player4, 4);
        }
        else if (screen == 9)
        {
            DrawPlayerScreen(player4);
            player4.Update();
        }
        else
        {
            DrawEndScreen();
        }
    }

    private void DrawStartScreen()
    {
        TextObject Labyrinth = new TextObject(new Vector2(MAX_X/2 - 145, 4 * CELL_SIZE), "Labyrinth", 60, white);
        
        TextObject typePlayerNumber = new TextObject(new Vector2(MAX_X/2 - 195, 7 * CELL_SIZE), "Type player number (2-4)", fontSize1, lightGrey);
        
        TextObject playerNumberText = new TextObject(new Vector2(MAX_X/2 - 15, 8 * CELL_SIZE), playerNumber.ToString(), 60, white);
        
        TextObject enterToStart = new TextObject(new Vector2(MAX_X/2 - 90, 11 * CELL_SIZE), "enter to start", fontSize2, lightGrey);

        List<TextObject> startScreenObjects = new List<TextObject>();
        startScreenObjects.Add(Labyrinth);
        startScreenObjects.Add(typePlayerNumber);
        startScreenObjects.Add(enterToStart);
        startScreenObjects.Add(playerNumberText);

        video.DrawTextObjects(startScreenObjects);

        if (keyboard.IsKeyPressed("2"))
        {
            playerNumber = 2;
        }
        else if (keyboard.IsKeyPressed("3"))
        {
            playerNumber = 3;
        }
        else if (keyboard.IsKeyPressed("4"))
        {
            playerNumber = 4;
        }

        if (playerNumber > 1)
        {
            if (keyboard.IsKeyPressed("enter"))
            {
                screen = 2;
            }
        }
    }

    private void DrawBlackout(Player player, int PlayerNumber)
    {
        string playerString = "Player" + PlayerNumber.ToString();
        List<TextObject> blackoutList = new List<TextObject>();
        blackoutList.Add(new TextObject(new Vector2(MAX_X/2 - 60, 7 * CELL_SIZE), playerString, fontSize1, lightGrey));
        blackoutList.Add(new TextObject(new Vector2(MAX_X/2 - 70, 10 * CELL_SIZE), "press enter", fontSize2, grey));

        video.DrawTextObjects(blackoutList);
        if (keyboard.IsKeyPressed("enter"))
        {
            screen += 1;
        }
    }

    private void DrawPlayerScreen(Player player)
    {
        video.DrawTextObjects(PlayerScreenObjects);
        video.DrawTile(new TileOutline(new Vector2 (19 * CELL_SIZE, 3 * CELL_SIZE), lightGrey));
        video.DrawTile(new TileOutline(new Vector2 (21 * CELL_SIZE, 3 * CELL_SIZE), lightGrey));
        player.Draw();
        maze.Draw();

        if (keyboard.IsKeyPressed("enter"))
        {
            if ((playerNumber == 3 && screen == 7) || (playerNumber == 2 && screen == 5) || (playerNumber == 4 && screen == 9))
            {
                if (gameOver)
                {
                    screen = 10;
                }
                else
                {
                    screen = 2;
                }
            }
            else
            {
                if (gameOver)
                {
                    screen = 10;
                }
                else
                {
                    screen += 1;
                }
            }
        }
    }

    private void DrawEndScreen()
    {

    }

    private void CreatePlayerList()
    {
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, CELL_SIZE), "MOVE", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(2 * CELL_SIZE, 2 * CELL_SIZE), "W", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 3 * CELL_SIZE), "A", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(2 * CELL_SIZE, 3 * CELL_SIZE), "S", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(3 * CELL_SIZE, 3 * CELL_SIZE), "D", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 5 * CELL_SIZE), "GRAB", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 6 * CELL_SIZE), "E", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 8 * CELL_SIZE), "DROP", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 9 * CELL_SIZE), "Q", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 11 * CELL_SIZE), "SHOOT", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 12 * CELL_SIZE), "SPACE", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 14 * CELL_SIZE), "STAB", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 15 * CELL_SIZE), "F", fontSize2, grey));

        PlayerScreenObjects.Add(new TextObject(new Vector2(20 * CELL_SIZE, 14 * CELL_SIZE), "END", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(19 * CELL_SIZE, 15 * CELL_SIZE), "ENTER", fontSize2, grey));

    }
}