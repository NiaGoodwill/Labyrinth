using Raylib_cs;
using System.Numerics;

class Keyboard
{
    private Dictionary<string, KeyboardKey> keys
            = new Dictionary<string, KeyboardKey>();
    /// <summary>
    /// Constructs a new instance of KeyboardServiceusing the given cell size.
    /// </summary>
    public Keyboard()
    {
        keys["w"] = KeyboardKey.KEY_W;
        keys["a"] = KeyboardKey.KEY_A;
        keys["s"] = KeyboardKey.KEY_S;
        keys["d"] = KeyboardKey.KEY_D;
        keys["e"] = KeyboardKey.KEY_E;
        keys["q"] = KeyboardKey.KEY_Q;
        keys["f"] = KeyboardKey.KEY_F;
        keys["2"] = KeyboardKey.KEY_TWO;
        keys["3"] = KeyboardKey.KEY_THREE;
        keys["4"] = KeyboardKey.KEY_FOUR;
        keys["^"] = KeyboardKey.KEY_UP;
        keys["<"] = KeyboardKey.KEY_LEFT;
        keys[">"] = KeyboardKey.KEY_RIGHT;
        keys["v"] = KeyboardKey.KEY_DOWN;
        keys["enter"] = KeyboardKey.KEY_ENTER;
        keys["space"] = KeyboardKey.KEY_SPACE;
    }
    /// <summary>
    /// Checks if the given key is currently down.
    /// </summary>
    /// <param name="key">The given key (w, a, s, d, i, j, k, or l)</param>
    /// <returns>True if the given key is down; false if otherwise.</returns>
    public bool IsKeyDown(string key)
    {
        KeyboardKey raylibKey = keys[key.ToLower()];
        return Raylib.IsKeyDown(raylibKey);
    }

    public bool IsKeyPressed(string key)
    {
        KeyboardKey raylibKey = keys[key.ToLower()];
        return Raylib.IsKeyPressed(raylibKey);
    }

    /// <summary>
    /// Checks if the given key is currently up.
    /// </summary>
    /// <param name="key">The given key (w, a, s, d, i, j, k, or l)</param>
    /// <returns>True if the given key is up; false if otherwise.</returns>
    public bool IsKeyUp(string key)
    {
        KeyboardKey raylibKey = keys[key.ToLower()];
        return Raylib.IsKeyUp(raylibKey);
    }

}

