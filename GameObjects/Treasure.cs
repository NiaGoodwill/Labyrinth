using Raylib_cs;
using System.Numerics;

class Treasure: GameObject
{
    int owner = 0;

    public Treasure(Vector2 Position)
    {
        SetPosition(Position.X, Position.Y);
    }
    public int GetOwner()
    {
        return owner;
    }

    public void ChangeOwner(int newOwner)
    {
        owner = newOwner;
    }
}