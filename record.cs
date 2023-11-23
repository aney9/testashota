using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testashota
{
    internal class record
    {
        public void Table()
        {
            ConsoleKeyInfo Key;
            do
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Таблица рекордов");
                List<chelik> cheliki;
                if (!File.Exists("record.json"))
                {
                    FileStream fileStream = File.Create("record.json");
                    cheliki = new List<chelik>();
                    fileStream.Dispose();
                }
                else
                {
                    string chelikiInfo = File.ReadAllText("record.json");
                    cheliki = JsonConvert.DeserializeObject<List<chelik>>(chelikiInfo);
                }

                int i = 1;

                foreach (chelik chelik in cheliki)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(i + "Ваше имя: " + chelik.Name + chelik.BukvyVminutu + " Буквы в минуту: " + chelik.BukvyVminutu+ " Буквы в секунду:" + chelik.Oshibki + " Ошибки");
                    i++;
                }
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Escape);
            menu.MainMenu();

        }
    }
}