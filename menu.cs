using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testashota
{
    class menu
    {
        static private int SelectedIndex;
        static private string Label = "Тест от Ашота, смотри не ашибис";
        static private string[] Options = { "Перейти к тесту", "Таблица лидеров", "Долой эту шайтан машину" };

        static public void MainMenu()
        {
            Console.CursorVisible = false;
            Console.Title = Label;
            Console.Clear();

            int selectedIndex = Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();
                    new nabor().Test();
                    break;
                case 1:
                    Console.Clear();
                    new record().Table();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }

        static private void DisplayOptions()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Label);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];

                if (i == SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else if (i == Options.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.SetCursorPosition(0, 2 + i);
                Console.WriteLine($"{currentOption}");
            }
            Console.ResetColor();
        }

        static private int Run()
        {
            ConsoleKey keyPressed;

            do
            {
                new Thread(DisplayOptions).Start();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
