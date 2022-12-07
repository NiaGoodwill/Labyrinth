using Raylib_cs;
using System.Numerics;

class TextObject: VisibleObject
{
    string text;
    int fontSize;
    Color color;
    public TextObject(Vector2 Position, string Text, int FontSize, Color Color)
    {
        SetPosition(Position.X, Position.Y);
        text = Text;
        fontSize = FontSize;
        color = Color;
    }

    public string GetText()
    {
        return text;
    }

    public int GetFontSize()
    {
        return fontSize;
    }

    public Color GetColor()
    {
        return color;
    }
}