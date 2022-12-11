using Raylib_cs;
using System.Numerics;

class Bullet: VisibleObject
{
    int direction;
    Gun gun;
    List<Vector2> trail = new List<Vector2>();
    public Bullet(Vector2 Position, int Direction, Gun Gun)
    {
        SetPosition(Position.X, Position.Y);
        direction = Direction;
        gun = Gun;
        trail.Add(GetPosition());
    }

    public override void Draw()
    {
        foreach (Vector2 spot in trail)
        {
            Raylib.DrawPixelV(spot, Color.GRAY);
        }
    }

    public void Move(Maze maze)
    {
        if (direction == 1)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new  Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 1);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                SetPosition(GetX(), GetY() - 30);
                trail.Add(GetPosition());
            }
            else
            {
                bool theReturn = true;
                gun.AdjustUse(theReturn);
            }
        }
        else if (direction == 2)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new  Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 2);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                SetPosition(GetX() - 30, GetY());
                trail.Add(GetPosition());
            }
            else
            {
                bool theReturn = true;
                gun.AdjustUse(theReturn);
            }
        }
        else if (direction == 3)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new  Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 3);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                SetPosition(GetX(), GetY() + 30);
                trail.Add(GetPosition());
            }
            else
            {
                bool theReturn = true;
                gun.AdjustUse(theReturn);
            }
        }
        else if (direction == 4)
        {
            Wall newWall = new Wall(new Corner(new Vector2(1,1), true), new Corner(new  Vector2(1,1), true));
            Wall collisionWall = maze.IsThereAWall(GetPosition(), 4);
            if (newWall.GetStartPos().GetVector() == collisionWall.GetStartPos().GetVector())
            {
                SetPosition(GetX() + 30, GetY());
                trail.Add(GetPosition());
            }
            else
            {
                bool theReturn = true;
                gun.AdjustUse(theReturn);
            }
        }
    }
}