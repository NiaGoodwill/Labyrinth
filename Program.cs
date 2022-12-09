using Raylib_cs;
using System.Numerics;

Video video = new Video(false);
Maze maze = new Maze(video);
Turn turn = new Turn(video, maze);

video.OpenWindow();
turn.CreateTextureObjects();
while (video.IsWindowOpen())
{
   
    video.ClearBuffer();
    turn.DrawScreen();
    video.FlushBuffer();
    
}
video.CloseWindow();
