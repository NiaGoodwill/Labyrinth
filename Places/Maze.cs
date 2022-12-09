using Raylib_cs;
using System.Numerics;

class Maze: VisibleObject
{
    int CELL_SIZE = 30;
    Video video;
    Color black = Color.BLACK;
    Color white = Color.WHITE;
    Dictionary<int, Corner> CornerDict = new Dictionary<int, Corner>();
    List<Wall> theMaze = new List<Wall>();
    Random random = new Random();

    public Maze(Video Video)
    {
        video = Video;
        CreateDict();
        int XorY = random.Next(2);
        int TopBotLeftRight = random.Next(2);
        if (XorY == 1)
        {
            int ExitX = random.Next(7, 16);
            ExitStart.X = ExitX;
            ExitEnd.X = ExitX +1;

            if (TopBotLeftRight == 1)
            {
                ExitStart.Y = 4;
                ExitEnd.Y = 4;
            }
            else
            {
                ExitStart.Y = 13;
                ExitEnd.Y = 13;
            }
        }
        else
        {
            int ExitY = random.Next(4, 13);
            ExitStart.Y = ExitY;
            ExitEnd.Y = ExitY + 1;

            if (TopBotLeftRight == 1)
            {
                ExitStart.X = 7;
                ExitEnd.X = 7;
            }
            else
            {
                ExitStart.X = 16;
                ExitEnd.X = 16;
            }
        }
        ExitStart = ExitStart * CELL_SIZE;
        ExitEnd = ExitEnd * CELL_SIZE;

        CreateMaze();
    }

    public override void Draw()
    {
        video.DrawLine(TOPLEFT, TOPRIGHT, white);
        video.DrawLine(TOPRIGHT, BOTRIGHT, white);
        video.DrawLine(BOTRIGHT, BOTLEFT, white);
        video.DrawLine(BOTLEFT, TOPLEFT, white);
        video.DrawLine(ExitStart, ExitEnd, black);

        // draw the corners
        // foreach (var lol in CornerDict)
        // {
            // Corner corner = lol.Value;
            // Vector2 vector = corner.GetVector();
            // if (corner.IsCornerUsed())
            // {
                // Raylib.DrawPixelV(vector, Color.RED);
            // }
            // else
            // {
                // Raylib.DrawPixelV(vector, white);
            // }
        // }

        // draw a pixel
        // Raylib.DrawPixelV(CornerDict[100].GetVector(), Color.GREEN);

        foreach (Wall wall in theMaze)
        {
            Corner corner1 = wall.GetStartPos();
            Corner corner2 = wall.GetEndPos();
            video.DrawLine(corner1.GetVector(), corner2.GetVector(), white);
        }
    }

    private void CreateDict()
    {
        int counter = 1;
        while (counter <= 10)
        {
            int name = counter;
            Corner theCorner = new Corner(new Vector2((6 + counter) * CELL_SIZE, 4 * CELL_SIZE), true);
            CornerDict.Add(name, theCorner);
            counter += 1;
        }

        while (counter > 10 && counter <= 90)
        {
            int name = counter;
            bool used;
            if ((counter % 10) == 1 || (counter % 10) == 0)
            {
                used = true;
            }
            else
            {
                used = false;
            }
            Corner theCorner = new Corner(new Vector2((7 + ((counter - 1) % 10)) * CELL_SIZE, (((counter - 1) / 10) + 4) * CELL_SIZE), used);
            CornerDict.Add(name, theCorner);
            counter += 1;
        }

        while (counter > 90 && counter <= 100)
        {
            int name = counter;
            Corner theCorner = new Corner(new Vector2((7 + ((counter - 1) % 10)) * CELL_SIZE, 13 * CELL_SIZE), true);
            CornerDict.Add(name, theCorner);
            counter += 1;
        }
    }

    private void CreateMaze()
    {
        while (theMaze.Count() < 30)
        {
            int randomCorner = random.Next(1, 101);
            int randomDirection = random.Next(4);
            int otherCorner;
            if (randomDirection == 0)
            {
                otherCorner = randomCorner + 1;
            }
            else if (randomDirection == 1)
            {
                otherCorner = randomCorner - 1;
            }
            else if (randomDirection == 2)
            {
                otherCorner = randomCorner + 10;
            }
            else
            {
                otherCorner = randomCorner - 10;
            }

            if (CornerDict.ContainsKey(otherCorner))
            {
                Corner corner1 = CornerDict[randomCorner];
                Corner corner2 = CornerDict[otherCorner];
                bool used1 = corner1.IsCornerUsed();
                bool used2 = corner2.IsCornerUsed();
                if (!used1 || !used2)
                {
                    theMaze.Add(new Wall(corner1, corner2));
                    corner1.Use();
                    corner2.Use();
                }
            }
        }
    }

    public List<Wall> GetMaze()
    {
        return theMaze;
    }

    public Wall IsThereAWall(Vector2 position, int direction)
    {
        Wall theReturn = new Wall(new Corner(new Vector2(1,1), true), new Corner(new Vector2(1,1), true));
        Vector2 theRealPosition = new Vector2((position.X - 5)/ CELL_SIZE, (position.Y - 4) / CELL_SIZE);
        if (direction == 1)
        {
            int key = (int)(((theRealPosition.Y - 4) * 10) + (theRealPosition.X - 6));
            Corner corner1 = CornerDict[key];
            Corner corner2 = CornerDict[key + 1];
            foreach (Wall wall in theMaze)
            {
                Corner wallStartPos = wall.GetStartPos();
                Corner wallEndPos = wall.GetEndPos();
                if (corner1.GetVector() == wallStartPos.GetVector() && corner2.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
                else if (corner1.GetVector() == wallEndPos.GetVector() && corner2.GetVector() == wallStartPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
            }
            if (theRealPosition.Y == 4)
            {
                theReturn = new Wall(CornerDict[1], CornerDict[10]);
                // video.DrawLine(TOPLEFT, TOPRIGHT, Color.RED);
            }
        }
        else if (direction == 2)
        {
            int key = (int)(((theRealPosition.Y - 4) * 10) + (theRealPosition.X - 6));
            Corner corner1 = CornerDict[key];
            Corner corner2 = CornerDict[key + 10];
            foreach (Wall wall in theMaze)
            {
                Corner wallStartPos = wall.GetStartPos();
                Corner wallEndPos = wall.GetEndPos();
                if (corner1.GetVector() == wallStartPos.GetVector() && corner2.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
                else if (corner2.GetVector() == wallStartPos.GetVector() && corner1.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
            }
            if (theRealPosition.X == 7)
            {
                theReturn = new Wall(CornerDict[1], CornerDict[91]);
                // video.DrawLine(TOPLEFT, BOTLEFT, Color.RED);
            }
        }
        else if (direction == 3)
        {
            int key = (int)(((theRealPosition.Y - 4) * 10) + (theRealPosition.X - 6) + 11);
            Corner corner1 = CornerDict[key];
            Corner corner2 = CornerDict[key - 1];
            foreach (Wall wall in theMaze)
            {
                Corner wallStartPos = wall.GetStartPos();
                Corner wallEndPos = wall.GetEndPos();
                if (corner1.GetVector() == wallStartPos.GetVector() && corner2.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
                else if (corner2.GetVector() == wallStartPos.GetVector() && corner1.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
            }
            if (theRealPosition.Y == 12)
            {
                theReturn = new Wall(CornerDict[91], CornerDict[100]);
                // video.DrawLine(BOTLEFT, BOTRIGHT, Color.RED);
            }
        }
        else
        {
            int key = (int)(((theRealPosition.Y - 4) * 10) + (theRealPosition.X - 6) + 11);
            Corner corner1 = CornerDict[key];
            Corner corner2 = CornerDict[key - 10];
            foreach (Wall wall in theMaze)
            {
                Corner wallStartPos = wall.GetStartPos();
                Corner wallEndPos = wall.GetEndPos();
                if (corner1.GetVector() == wallStartPos.GetVector() && corner2.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
                else if (corner2.GetVector() == wallStartPos.GetVector() && corner1.GetVector() == wallEndPos.GetVector())
                {
                    theReturn = wall;
                    // video.DrawLine(wall.GetStartPos().GetVector(), wall.GetEndPos().GetVector(), Color.RED);
                }
            }
            if (theRealPosition.X == 15)
            {
                theReturn = new Wall(CornerDict[10], CornerDict[100]);
                // video.DrawLine(BOTRIGHT, TOPRIGHT, Color.RED);
            }
        }

        return theReturn;
    }

    Vector2 TOPLEFT = new Vector2(7 * 30, 4 * 30);
    Vector2 TOPRIGHT = new Vector2(16 * 30, 4 * 30);
    Vector2 BOTLEFT = new Vector2(7 * 30, 13 * 30);
    Vector2 BOTRIGHT = new Vector2(16 * 30, 13 * 30);
    Vector2 ExitStart;
    Vector2 ExitEnd;

}