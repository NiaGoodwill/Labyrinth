using Raylib_cs;
using System.Numerics;

class Treasure: GameObject
{
    int owner = 0;
    Texture2D treasure;

    public Treasure(Vector2 Position)
    {
        SetPosition(Position.X, Position.Y);
        treasure = Raylib.LoadTexture("GameObjects/gem.png");

    }
    public int GetOwner()
    {
        return owner;
    }

    public void ChangeOwner(int newOwner)
    {
        owner = newOwner;
    }

    public override Texture2D GetTexture()
    {
        return treasure;
    }
}