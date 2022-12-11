using Raylib_cs;
using System.Numerics;

class Turn
{
    Video video;
    Maze maze;
    Keyboard keyboard = new Keyboard();
    Random random = new Random();
    TreasureRoom treasureRoom;
    Treasure treasure;
    Armory armory;
    Hospital hospital;
    int screen;
    List<TextObject> PlayerScreenObjects = new List<TextObject>();
    int CELL_SIZE = 30;
    int MAX_X = 690;
    bool arePlayersCreated = false;

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
    int winner;
    int playerAmount = 0;
    int fontSize1 = 30;
    int fontSize2 = 25;
    int updateCounter = 0;

    Player player1;
    Player player2;
    Player player3;
    Player player4;
    Player extra;
    Player extra2;
    public Turn(Video Video, Maze Maze)
    {
        video = Video;
        maze = Maze;
        screen = 1;
        CreatePlayerList();
        extra = new Player(maze, keyboard, video, 1, 1, red, 0);
        extra2 = new Player(maze, keyboard, video, 2, 2, red, 5);
        treasureRoom = maze.GetTreasureRoom();
        armory = maze.GetArmory();
        hospital = maze.GetHospital();
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
            Vector2 tempPos = new Vector2(maze.GetExitTile().GetPosition().X + 5, maze.GetExitTile().GetPosition().Y + 3);
            if (player1.HasTreasure() && player1.GetPosition() == tempPos)
            {
                Console.WriteLine("ahhhhhhhhhhh");
                gameOver = true;
                winner = 1;
                screen = 10;
            }
            else if (playerAmount < 3)
            {
            player1.Update(updateCounter, player2, extra, extra2);
            DrawPlayerScreen(player1, 1);
            }
            else if (playerAmount == 3)
            {
            player1.Update(updateCounter, player2, player3, extra);
            DrawPlayerScreen(player1, 1);
            }
            else
            {
            player1.Update(updateCounter, player2, player3, player4);
            DrawPlayerScreen(player1, 1);             
            }
        }
        else if (screen == 4)
        {
            DrawBlackout(player2, 2);
        }
        else if (screen == 5)
        {
            Vector2 tempPos = new Vector2(maze.GetExitTile().GetPosition().X + 5, maze.GetExitTile().GetPosition().Y + 3);
            if (player2.HasTreasure() && player2.GetPosition() == tempPos)
            {
                gameOver = true;
                winner = 2;
                screen = 10;
            }
            else if (playerAmount < 3)
            {
            player2.Update(updateCounter, player1, extra, extra2);
            DrawPlayerScreen(player2, 2);
            }
            else if (playerAmount == 3)
            {
            player2.Update(updateCounter, player1, player3, extra);
            DrawPlayerScreen(player2, 2);
            }
            else
            {
            player2.Update(updateCounter, player1, player3, player4);
            DrawPlayerScreen(player2, 2);             
            }
        }
        else if (screen == 6)
        {
            DrawBlackout(player3, 3);
        }
        else if (screen == 7)
        {
            Vector2 tempPos = new Vector2(maze.GetExitTile().GetPosition().X + 5, maze.GetExitTile().GetPosition().Y + 3);
            if (player3.HasTreasure() && player3.GetPosition() == tempPos)
            {
                gameOver = true;
                winner = 3;
                screen = 10;
            }
            else if (playerAmount == 3)
            {
                player3.Update(updateCounter, player1, player2, extra);
                DrawPlayerScreen(player3, 3);
            }
            else
            {
                player3.Update(updateCounter, player4, player1, player2);
                DrawPlayerScreen(player3, 3);
            }
        }
        else if(screen == 8)
        {
            DrawBlackout(player4, 4);
        }
        else if (screen == 9)
        {
            Vector2 tempPos = new Vector2(maze.GetExitTile().GetPosition().X + 5, maze.GetExitTile().GetPosition().Y + 3);
            if (player3.HasTreasure() && player3.GetPosition() == tempPos)
            {
                gameOver = true;
                winner = 4;
                screen = 10;
            }
            else
            {
                player4.Update(updateCounter, player1, player2, player3);
                DrawPlayerScreen(player4, 4);
            }
        }
        else
        {
            DrawEndScreen();
        }
    }

    private void DrawStartScreen()
    {
        TextObject Labyrinth = new TextObject(new Vector2(MAX_X/2 - 145, 4 * CELL_SIZE), "Labyrinth", 60, white);
        
        TextObject typePlayerAmount = new TextObject(new Vector2(MAX_X/2 - 195, 7 * CELL_SIZE), "Type player number (2-4)", fontSize1, lightGrey);
        
        TextObject playerAmountText = new TextObject(new Vector2(MAX_X/2 - 15, 8 * CELL_SIZE), playerAmount.ToString(), 60, white);
        
        TextObject enterToStart = new TextObject(new Vector2(MAX_X/2 - 90, 11 * CELL_SIZE), "enter to start", fontSize2, lightGrey);

        List<TextObject> startScreenObjects = new List<TextObject>();
        startScreenObjects.Add(Labyrinth);
        startScreenObjects.Add(typePlayerAmount);
        startScreenObjects.Add(enterToStart);
        startScreenObjects.Add(playerAmountText);

        video.DrawTextObjects(startScreenObjects);

        if (keyboard.IsKeyPressed("2"))
        {
            playerAmount = 2;
        }
        else if (keyboard.IsKeyPressed("3"))
        {
            playerAmount = 3;
        }
        else if (keyboard.IsKeyPressed("4"))
        {
            playerAmount = 4;
        }

        if (playerAmount > 1)
        {
            if (keyboard.IsKeyPressed("enter"))
            {
                int X1 = random.Next(7, 11);
                int X2 = random.Next(12, 16);
                int X3 = random.Next(7, 11);
                int X4 = random.Next(12, 16);
                int Y1 = random.Next(4, 8);
                int Y2 = random.Next(4, 8);
                int Y3 = random.Next(9, 13);
                int Y4 = random.Next(9, 13);

                player1 = new Player(maze, keyboard, video, X1, Y1, blue, 1);
                Console.WriteLine("Hello!");
                player2 = new Player(maze, keyboard, video, X2, Y2, green, 2);
                Console.WriteLine("Hey!");

                if (playerAmount > 2)
                {
                    player3 = new Player(maze, keyboard, video, X3, Y3, yellow, 3);
                    Console.WriteLine("Heywo!");
                }
                if (playerAmount > 3)
                {
                    player4 = new Player(maze, keyboard, video, X4, Y4, purple, 4);
                    Console.WriteLine("Sup Nerds!");
                }

                arePlayersCreated = true;

                screen = 2;
            }
        }
    }

    private void DrawBlackout(Player player, int playerNumber)
    {
        string playerString = "Player " + playerNumber.ToString();
        List<TextObject> blackoutList = new List<TextObject>();
        blackoutList.Add(new TextObject(new Vector2(MAX_X/2 - 65, 7 * CELL_SIZE), playerString, fontSize1, lightGrey));
        blackoutList.Add(new TextObject(new Vector2(MAX_X/2 - 70, 10 * CELL_SIZE), "press enter", fontSize2, grey));

        video.DrawTextObjects(blackoutList);
        if (keyboard.IsKeyPressed("enter"))
        {
            screen += 1;
        }
    }

    private void DrawPlayerScreen(Player player, int playerNumber)
    {
        video.DrawTextObjects(PlayerScreenObjects);
        video.DrawTile(new TileOutline(new Vector2 (17 * CELL_SIZE, 3 * CELL_SIZE), lightGrey));
        video.DrawTile(new TileOutline(new Vector2 (19 * CELL_SIZE, 3 * CELL_SIZE), lightGrey));
        video.DrawTile(new TileOutline(new Vector2 (21 * CELL_SIZE, 3 * CELL_SIZE), lightGrey));
        player.Draw();
        if (player.IsObjectNear(player1) &&  player1.GetHealth() > 0)
        {
            player1.DrawPlayer();
        }
        if (player.IsObjectNear(player2) &&  player2.GetHealth() > 0)
        {
            player2.DrawPlayer();
        }
        if (playerAmount > 2)
        {
            if (player.IsObjectNear(player3) &&  player3.GetHealth() > 0)
            {
                player3.DrawPlayer();
            }
        }
        if (playerAmount > 3)
        {
            if (player.IsObjectNear(player4) &&  player4.GetHealth() > 0)
            {
                player4.DrawPlayer();
            }
        }

        // maze.Draw();
        // video.DrawTile(armory.GetSelf());
        // video.DrawTile(hospital.GetSelf());
        // video.DrawTile(treasureRoom.GetSelf());
        // player1.DrawPlayer();
        // player2.DrawPlayer();
        // player3.DrawPlayer();
        // player4.DrawPlayer();

        if (player.IsObjectNear(armory))
        {
            video.DrawTile(armory.GetSelf());
        }
        if (player.IsObjectNear(hospital))
        { 
            video.DrawTile(hospital.GetSelf());
        }
        if (player.IsObjectNear(treasure))
        {
            video.DrawTreasure(treasure);
        }

        Vector2 tempPos = new Vector2(hospital.GetPosition().X + 6, hospital.GetPosition().Y + 4);
        if (player.GetPosition() == tempPos)
        {
            if (!player.HasVisitedHospital())
            {
                player.VisitHospital();
            }
            video.DrawTile(hospital.GetSelf());
        }
        tempPos = new Vector2(armory.GetPosition().X + 6, armory.GetPosition().Y + 4);
        if (player.GetPosition() == tempPos)
        {
            if (!player.HasVisitedArmory())
            {
                player.VisitArmory();
            }
            video.DrawTile(armory.GetSelf());
        }
        tempPos = new Vector2(treasureRoom.GetPosition().X + 6, treasureRoom.GetPosition().Y + 4);
        if ((player.IsObjectNear(treasureRoom) || player.GetPosition() == tempPos))
        {
            video.DrawTile(treasureRoom.GetSelf());
        }
        tempPos = new Vector2(treasure.GetPosition().X + 6, treasure.GetPosition().Y + 4);
        if (player.GetPosition() == tempPos && treasure.GetOwner() == 0 && player.GetHealth() > 0)
        {
            player.FindTreasure();
        }

        if (player.HasTreasure())
        {
            TileOutline treasureSlot = new TileOutline(new Vector2(21 * CELL_SIZE, 5 * CELL_SIZE), Color.DARKBLUE);
            treasure.SetPosition(21 * CELL_SIZE, 5 * CELL_SIZE);
            
            video.DrawTreasure(treasure);
            video.DrawTile(treasureSlot);
        }
        if (player1.GetHealth() == 0 && player1.HasTreasure())
        {
            player1.LoseTreasure();
            treasure.ChangeOwner(0);
            treasure.SetPosition(player1.GetPosition().X - 6, player1.GetPosition().Y - 4);
        }
        if (player2.GetHealth() == 0 && player2.HasTreasure())
        {
            player2.LoseTreasure();
            treasure.ChangeOwner(0);
            treasure.SetPosition(player2.GetPosition().X - 6, player2.GetPosition().Y - 4);
        }
        if (playerAmount > 2)
        {
            if (player3.GetHealth() == 0 && player3.HasTreasure())
            {
                player3.LoseTreasure();
                treasure.ChangeOwner(0);
                treasure.SetPosition(player3.GetPosition().X - 6, player3.GetPosition().Y - 4);
            }
        }
        if (playerAmount == 4)
        {
            if (player4.GetHealth() == 0 && player4.HasTreasure())
            {
                player4.LoseTreasure();
                treasure.ChangeOwner(0);
                treasure.SetPosition(player4.GetPosition().X - 6, player4.GetPosition().Y - 4);
            }
        }

        if (keyboard.IsKeyPressed("enter"))
        {
            if (player.GetTurnCounter() != updateCounter +1)
            {
                player.AdjustTurnCounter();
            }
            if ((playerAmount == 3 && screen == 7) || (playerAmount == 2 && screen == 5) || (playerAmount == 4 && screen == 9))
            {
                screen = 2;
                if (playerNumber == playerAmount)
                {
                    updateCounter += 1;
                }
            }
            else
            {
                screen += 1;
                if (playerNumber == playerAmount)
                {
                    updateCounter += 1;
                }
            }
        }
    }

    private void DrawEndScreen()
    {
        List<TextObject> endTextList = new List<TextObject>();
        endTextList.Add(new TextObject(new Vector2(MAX_X/2 - 145, 4 * CELL_SIZE), "Labyrinth", 60, white));
        endTextList.Add(new TextObject(new Vector2(MAX_X/2 - 55, 8 * CELL_SIZE), "Winner:", fontSize1, lightGrey));
        string winnerString = "Player " + winner.ToString();
        endTextList.Add(new TextObject(new Vector2(MAX_X/2 - 65, 10 * CELL_SIZE), winnerString, fontSize1, white));

        video.DrawTextObjects(endTextList);
    }

    private void CreatePlayerList()
    {
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, CELL_SIZE), "MOVE", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(2 * CELL_SIZE, 2 * CELL_SIZE), "W", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 3 * CELL_SIZE), "A", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(2 * CELL_SIZE, 3 * CELL_SIZE), "S", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(3 * CELL_SIZE, 3 * CELL_SIZE), "D", fontSize2, grey));
        // PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 4 * CELL_SIZE), "GRAB", fontSize1, lightGrey));
        // PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 5 * CELL_SIZE), "E", fontSize2, grey));
        // PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 6 * CELL_SIZE), "DROP", fontSize1, lightGrey));
        // PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 7 * CELL_SIZE), "Q", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, 5 * CELL_SIZE), "SHOOT", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2((2 * CELL_SIZE) +1, 6 * CELL_SIZE), "^", fontSize1, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, (7 * CELL_SIZE) - 8), "<", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(2 * CELL_SIZE, (7 * CELL_SIZE) - 8), "v", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2((3 * CELL_SIZE) + 3, (7 * CELL_SIZE) - 8), ">", fontSize2, grey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, (9 * CELL_SIZE) - 8), "STAB", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(CELL_SIZE, (10 * CELL_SIZE) - 8), "F", fontSize2, grey));

        PlayerScreenObjects.Add(new TextObject(new Vector2(20 * CELL_SIZE, 14 * CELL_SIZE), "END", fontSize1, lightGrey));
        PlayerScreenObjects.Add(new TextObject(new Vector2(19 * CELL_SIZE, 15 * CELL_SIZE), "ENTER", fontSize2, grey));

    }

    public void CreateTextureObjects()
    {
        player1.CreateTexturedObjects();
        player2.CreateTexturedObjects();
        if (playerAmount > 2)
        {
            player3.CreateTexturedObjects();
        }
        if (playerAmount > 3)
        {
            player4.CreateTexturedObjects();
        }
        treasureRoom.CreateTreasure();
        treasure = treasureRoom.GetTreasure();
    }

    public bool ArePlayersCreated()
    {
        return arePlayersCreated;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}