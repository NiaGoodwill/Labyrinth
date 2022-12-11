using Raylib_cs;
using System.Numerics;

Video video = new Video(false);
Maze maze = new Maze(video);
Turn turn = new Turn(video, maze);

video.OpenWindow();
bool arePlayersCreated = turn.ArePlayersCreated();
while (video.IsWindowOpen() && !arePlayersCreated)
{
    video.ClearBuffer();
    turn.DrawScreen();
    video.FlushBuffer();
    arePlayersCreated = turn.ArePlayersCreated();
}
turn.CreateTextureObjects();
while (video.IsWindowOpen() && arePlayersCreated)
{
    video.ClearBuffer();
    turn.DrawScreen();
    video.FlushBuffer();
}
video.CloseWindow();
