using System.Numerics;
using Raylib_cs;
class Weapon: GameObject
{
    bool used = true;

    public bool IsUsed()
    {
        return used;
    }

    public void Use(Player player)
    {
        player.Damage();
        used = true;
    }

    public void AdjustUse(bool newUse)
    {
        used = newUse;
    }
}