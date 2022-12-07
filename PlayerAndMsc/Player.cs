using Raylib_cs;
using System.Numerics;

class Player: VisibleObject
{
    int CELL_SIZE = 30;
    Video video;
    Heart heart1;
    Heart heart2;
    Heart heart3;
    int health = 3;
    public Player(Video Video)
    {
        heart1 = new Heart(new Vector2 (17 * CELL_SIZE, CELL_SIZE));
        heart2 = new Heart(new Vector2 (19 * CELL_SIZE, CELL_SIZE));
        heart3 = new Heart(new Vector2 (21 * CELL_SIZE, CELL_SIZE));
        video = Video;
    }

    public void Update()
    {
        
    }

    public override void Draw()
    {
        video.DrawHeart(heart1);
        if (health > 1)
        {
        video.DrawHeart(heart2);
        }
        if (health == 3)
        {
        video.DrawHeart(heart3);
        }
    }
}