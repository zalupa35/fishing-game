Game.MainGame mainGame = new();
bool exit = false;

while (true)
{
    if (exit)
    {
        Console.CursorVisible = true;
        Console.Clear();
        Console.ResetColor();
        break;
    };

    if (Console.KeyAvailable)
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Spacebar:
                mainGame.PressSpacebar();
                break;
            case ConsoleKey.Q:
                exit = true;
                break;
        }

    try
    {
        mainGame.Draw();
    }
    catch { }

    Thread.Sleep(100);
}
