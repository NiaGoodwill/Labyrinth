using Raylib_cs;
using System.Numerics;

class TreasureRoom: Room
{
    Treasure treasure;
    public TreasureRoom(Vector2 Position, Color Color): base(Position, Color)
    {

    }

    public Treasure GetTreasure()
    {
        return treasure;
    }

    public void CreateTreasure()
    {
        treasure = new Treasure(GetPosition());
    }
}