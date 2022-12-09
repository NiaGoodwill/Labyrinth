using Raylib_cs;
using System.Numerics;

class Gun: Weapon
{
    Texture2D gunImage;
    public Gun(Vector2 Position)
    {
        gunImage = Raylib.LoadTexture("GameObjects/gun.png");
        SetPosition(Position.X, Position.Y);
    }  

    public override Texture2D GetTexture()
    {
        return gunImage;
    }
}