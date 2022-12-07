using Raylib_cs;
using System.Numerics;

Video video = new Video(false);
Maze maze = new Maze();
Turn turn = new Turn(video, maze);

video.OpenWindow();
while (video.IsWindowOpen())
{
   
    video.ClearBuffer();
    turn.DrawScreen();
    video.FlushBuffer();
    
}
video.CloseWindow();
