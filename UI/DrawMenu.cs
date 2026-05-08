using System;

namespace DrawMenu
{
    public static class MenuUI
    {
        public static int DrawMenu(string title, string[] options, int startingIndex = 0)
        {
            Int16 currentIndex = Convert.ToInt16(startingIndex);
            ConsoleKey key;
            Console.CursorVisible = false;

            do
            {
                Display(title, options, currentIndex);
                key = Console.ReadKey(true).Key;
                currentIndex = Convert.ToInt16(UpdateSelection(key, currentIndex, options.Length));
            } while (key != ConsoleKey.Enter);

            return currentIndex;
        }

        public static int DrawPlayerCreationMenu(string title, string[] options, int startingIndex = 0)
        {
            Int16 currentIndex = Convert.ToInt16(startingIndex);
            ConsoleKey key;
            Console.CursorVisible = false;

            while (true)
            {
                Display(title, options, currentIndex);
                key = Console.ReadKey(true).Key;

                // Return immediately on Enter so the Program can update the value
                if (key == ConsoleKey.Enter) return currentIndex;

                currentIndex = Convert.ToInt16(UpdateSelection(key, currentIndex, options.Length));
            }
        }

        private static int UpdateSelection(ConsoleKey key, int current, int total)
        {
            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                return (current == 0) ? total - 1 : current - 1;
            if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                return (current == total - 1) ? 0 : current + 1;
            return current;
        }

        private static void Display(string title, string[] options, int currentIndex)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"=== {title} ===");

            for (int i = 0; i < options.Length; i++)
            {
                bool isSelected = (i == currentIndex);
                string selector = isSelected ? "> " : "  ";

                if (isSelected) Console.ForegroundColor = ConsoleColor.White;
                
                // We just print the string exactly as the Program sends it
                // We add trailing spaces to "wipe" the line if numbers get smaller
                Console.WriteLine($"        {selector}{options[i]}           ");
                
                if (isSelected) Console.ResetColor();
            }
        }
    }
}