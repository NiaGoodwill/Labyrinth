using Raylib_cs;
using System.Numerics;

class Player: VisibleObject
{
    int CELL_SIZE = 30;
    Video video;
    Keyboard keyboard;
    Knife startKnife;
    Knife secondKnife;
    Gun gun;
    Heart heart1;
    Heart heart2;
    Heart heart3;
    Maze maze;
    int health = 3;
    Color color;
    int turnCounter = 0;
    int playerNumber;
    List<Wall> visibleWalls = new List<Wall>();
    public Player(Maze Maze, Keyboard Keyboard, Video Video, int X, int Y, Color Color, int PlayerNumber)
    {
        keyboard = Keyboard;
        color = Color;
        maze = Maze;
        video = Video;
        SetPosition(X * CELL_SIZE + 5, Y * CELL_SIZE + 4);
        playerNumber = PlayerNumber;
        Console.WriteLine(GetPosition());
    }

    public void Update(int updateCounter, Player otherPlayer1, Player otherPlayer2, Player otherPlayer3)
    {
        if (health != 0)
        {
            if (updateCounter == turnCounter)
            {
                // move
                if (keyboard.IsKeyPressed("w"))
                {
                    Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
                    Wall collisionWall = maze.IsThereAWall(GetPosition(), 1);
                    if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
                    {
                        SetPosition(GetX(), GetY() - CELL_SIZE);
                        turnCounter += 1;
                    }
                    else
                    {
                        visibleWalls.Add(collisionWall);
                    }
                }
                else if (keyboard.IsKeyPressed("a"))
                {
                    Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
                    Wall collisionWall = maze.IsThereAWall(GetPosition(), 2);
                    if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
                    {
                        SetPosition(GetX() - CELL_SIZE, GetY());
                        turnCounter += 1;
                    }
                    else
                    {
                        visibleWalls.Add(collisionWall);
                    }
                }
                else if (keyboard.IsKeyPressed("s"))
                {
                    Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
                    Wall collisionWall = maze.IsThereAWall(GetPosition(), 3);
                    if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
                    {
                        SetPosition(GetX(), GetY() + CELL_SIZE);
                        turnCounter += 1;
                    }
                    else
                    {
                        visibleWalls.Add(collisionWall);
                    }
                }
                else if (keyboard.IsKeyPressed("d"))
                {
                    Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
                    Wall collisionWall = maze.IsThereAWall(GetPosition(), 4);
                    if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
                    {
                        SetPosition(GetX() + CELL_SIZE, GetY());
                        turnCounter += 1;
                    }
                    else
                    {
                        visibleWalls.Add(collisionWall);
                    }
                }
            
                // stab
                if (keyboard.IsKeyPressed("f"))
                {
                    Console.WriteLine("stab");
                    if (!startKnife.IsUsed())
                    {
                        if (IsObjectNear(otherPlayer1))
                        {
                            startKnife.Use(otherPlayer1);
                            turnCounter += 1;
                        }
                        else if (IsObjectNear(otherPlayer2))
                        {
                            startKnife.Use(otherPlayer2);
                            turnCounter += 1;
                        }
                        else if (IsObjectNear(otherPlayer3))
                        {
                            startKnife.Use(otherPlayer3);
                            turnCounter += 1;
                        }
                    }
                    else if (!secondKnife.IsUsed())
                    {
                        if (IsObjectNear(otherPlayer1))
                        {
                            secondKnife.Use(otherPlayer1);
                            turnCounter += 1;
                        }
                        else if (IsObjectNear(otherPlayer2))
                        {
                            secondKnife.Use(otherPlayer2);
                            turnCounter += 1;
                        }
                        else if (IsObjectNear(otherPlayer3))
                        {
                            secondKnife.Use(otherPlayer3);
                            turnCounter += 1;
                        }
                    }
                }

                // shoot
                if (keyboard.IsKeyPressed("space") && !gun.IsUsed())
                {

                }
            }
        }
    }

    public override void Draw()
    {
        if (health > 0)
        {
            video.DrawHeart(heart1);
        }
        if (health > 1)
        {
            video.DrawHeart(heart2);
        }
        if (health == 3)
        {
            video.DrawHeart(heart3);
        }

        if (!startKnife.IsUsed())
        {
            video.DrawWeapon(startKnife);         
        }
        if (!secondKnife.IsUsed())
        {
            video.DrawWeapon(secondKnife);
        }
        if (!gun.IsUsed())
        {
            video.DrawWeapon(gun);
        }

        Vector2 Position = new Vector2(GetX(), GetY());
        TextObject playerText = new TextObject(Position, "O", 30, color);
        video.DrawTextObject(playerText);

        if (health == 0)
        {
            video.DrawTextObject(new TextObject(new Vector2(690/2 - 145, 4 * CELL_SIZE), "You Lose", 60, Color.RED));
        }

        if (visibleWalls.Count() > 0)
        {
            foreach (Wall wall in visibleWalls)
            {
                Corner corner1 = wall.GetStartPos();
                Corner corner2 = wall.GetEndPos();
                video.DrawLine(corner1.GetVector(), corner2.GetVector(), Color.WHITE);
            }
        }
    }

    public void Damage()
    {
        health -= 1;
    }

    public void Heal()
    {
        health += 1;
    }

    public int GetTurnCounter()
    {
        return turnCounter;
    }

    public void AdjustTurnCounter()
    {
        turnCounter += 1;
    }

    public bool IsObjectNear(VisibleObject theObject)
    {
        bool returnValue = false;
        Vector2 ourPosition = GetPosition();
        Vector2 itsPosition = theObject.GetPosition();
        if (ourPosition.X + CELL_SIZE == itsPosition.X && ourPosition.Y == itsPosition.Y)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 4);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
            returnValue = true;
            }
        }
        else if (ourPosition.X - CELL_SIZE == itsPosition.X && ourPosition.Y == itsPosition.Y)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 2);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                returnValue = true;
            }
        }
        else if (ourPosition.X == itsPosition.X && ourPosition.Y + CELL_SIZE == itsPosition.Y)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 3);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                returnValue = true;
            }
        }
        else if (ourPosition.X == itsPosition.X&& ourPosition.Y - CELL_SIZE == itsPosition.Y)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 1);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                returnValue = true;
            }
        }
        return returnValue;
    }

    public Gun GetGun()
    {
        return gun;
    }

    public Knife GetSecondKnife()
    {
        return secondKnife;
    }

    public void CreateTexturedObjects()
    {
        heart1 = new Heart(new Vector2 (21 * CELL_SIZE, CELL_SIZE));
        heart2 = new Heart(new Vector2 (19 * CELL_SIZE, CELL_SIZE));
        heart3 = new Heart(new Vector2 (17 * CELL_SIZE, CELL_SIZE));

        startKnife = new Knife(new Vector2 (21 * CELL_SIZE, 3 * CELL_SIZE));
        secondKnife = new Knife(new Vector2 (19 * CELL_SIZE, 3 * CELL_SIZE));
        gun = new Gun(new Vector2 (17 * CELL_SIZE, 3 * CELL_SIZE));

        startKnife.AdjustUse(false);
    }
}