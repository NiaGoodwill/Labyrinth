using Raylib_cs;
using System.Numerics;

class GameObject: VisibleObject
{
    virtual public Texture2D GetTexture()
    {
        return new Texture2D();
    }
}