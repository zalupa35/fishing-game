namespace Game
{
    class MainGame
    {
        int fishPos, caughtFishesCount, lastWidth, lastHeight;
        bool directionForward = true, isGame = true, fishGlowState = false, fishCatched = false, updateMiddleText = false;

        public void Draw()
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"You caught {caughtFishesCount} fish\nPress Q to exit");

            int width = Console.WindowWidth, height = Console.WindowHeight, fishermanHeight = height / 2, fishHeight = fishermanHeight + 5;
            if (fishPos > width) fishPos = width - 2;

            if (lastWidth != width || lastHeight != height || updateMiddleText)
            {
                updateMiddleText = false;
                string middleText = isGame ? "?" : (fishCatched ? "You caught the fish!!" : "You didn't catch the fish.") + " Start again? (Spacebar)";
                Console.Clear();
                Console.SetCursorPosition(width / 2 - middleText.Length / 2, fishermanHeight);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(middleText);
            }

            DrawFish(width, fishHeight);

            lastWidth = width;
            lastHeight = height;
        }

        void DrawFish(int width, int fishHeight)
        {
            int lastFishPos = fishPos;
            bool nearBorder = fishPos < width - 2;

            if (directionForward && nearBorder) fishPos++;
            else if (!directionForward && fishPos > 0)
            {
                lastFishPos = fishPos + 1;
                fishPos--;
            }
            else directionForward = nearBorder;

            Console.SetCursorPosition(lastFishPos, fishHeight);
            Console.Write(" ");

            Console.SetCursorPosition(fishPos, fishHeight);
            if (isGame)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
            {
                fishGlowState = !fishGlowState;
                Console.ForegroundColor = fishGlowState ? ConsoleColor.Cyan : ConsoleColor.Blue;
            }
            Console.Write(directionForward ? "0>" : "<0");
        }

        public void PressSpacebar()
        {
            if (isGame)
            {
                fishCatched = fishPos == Console.WindowWidth / 2;
                if (fishCatched) caughtFishesCount++;
                isGame = false;
                updateMiddleText = true;
            }
            else
            {
                isGame = true;
                updateMiddleText = true;
                fishPos = 0;
            }
        }
    }
}