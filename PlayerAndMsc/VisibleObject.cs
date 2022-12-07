using Raylib_cs;
using System.Numerics;

class VisibleObject
{
    Vector2 position = new Vector2();
    public VisibleObject()
    {

    }

    public void SetPosition(float X, float Y)
    {
        position.Y = Y;
        position.X = X;
    }

    public int GetX()
    {
        return (int)position.X;
    }

    public int GetY()
    {
        return (int)position.Y;
    }

    virtual public void Draw()
    {
        
    }
}
