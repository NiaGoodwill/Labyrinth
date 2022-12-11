using Raylib_cs;
using System.Numerics;

class Room: VisibleObject
{
    TileOutline self;
    Color color;

    public Room(Vector2 Position, Color Color)
    {
        SetPosition(Position.X, Position.Y);
        color = Color;
        self = new TileOutline(GetPosition(), color);
    }

    public TileOutline GetSelf()
    {
        return self;
    }

    public Color GetColor()
    {
        return color;
    }
}