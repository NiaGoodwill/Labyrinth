using Raylib_cs;
using System.Numerics;

class Corner: VisibleObject
{
    bool used;
    public Corner(Vector2 Position, bool Used)
    {
        SetPosition(Position.X, Position.Y);
        used = Used;
    }
    
    public bool IsCornerUsed()
    {
        return used;
    }
    
    public void Use()
    {
        used = true;
    }

    public Vector2 GetVector()
    {
        Vector2 vector = new Vector2(GetX(), GetY());
        return vector;
    }
    public override void Draw()
    {

    }
}