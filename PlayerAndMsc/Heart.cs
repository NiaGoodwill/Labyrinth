using Raylib_cs;
using System.Numerics;

class Heart: VisibleObject
{
    Texture2D heartImage;

    public Heart(Vector2 Position)
    {
        heartImage = Raylib.LoadTexture("PlayerAndMsc/Heart.png");
        SetPosition(Position.X, Position.Y);
    }

    public Texture2D GetTexture()
    {
        return heartImage;
    }
}