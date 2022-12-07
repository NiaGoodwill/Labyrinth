using Raylib_cs;
using System.Numerics;

class TileOutline: VisibleObject
{
    Color color;
    public TileOutline(Vector2 cellPosition, Color Color)
    {
        SetPosition(cellPosition.X + 1, cellPosition.Y + 1);
        color = Color;
    }

    public Color GetColor()
    {
        return color;
    }
}