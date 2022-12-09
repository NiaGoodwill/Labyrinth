using Raylib_cs;
using System.Numerics;
class Knife: Weapon
{
    Texture2D knifeImage;
    public Knife(Vector2 Position)
    {
        knifeImage = Raylib.LoadTexture("GameObjects/dagger.png");
        SetPosition(Position.X, Position.Y);
    } 

    public override Texture2D GetTexture()
    {
        return knifeImage;
    }

}