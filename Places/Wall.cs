using Raylib_cs;
using System.Numerics;

class Wall: VisibleObject
{
    Corner startPos;
    Corner endPos;
    public Wall(Corner start, Corner end)
    {
        startPos = start;
        endPos = end;
    }

    public Corner GetStartPos()
    {
        return startPos;
    }

    public Corner GetEndPos()
    {
        return endPos;
    }

    public override void Draw()
    {

    }
}