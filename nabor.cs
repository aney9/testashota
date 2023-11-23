using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testashota
{
    internal class nabor
    {
        private int schetchikbuv = 0;
        private int Oshibki = 0;
        bool konec;
        string Name;

        public void Test()
        {

            konec = false;

            Console.Write("Введите имя: ");
            Name = Console.ReadLine();
            if (Name == "") Name = "Ashot Korotkiy";
            Console.Clear();

            char[] textToWrite = TextToWrite();
            foreach (char xz in textToWrite) 
            {
                Console.Write(xz);
            }                          
            Console.ResetColor();
            ConsoleKeyInfo Key;
            do
            {
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Enter);
            new Thread(Timer).Start();

            int i = 0;
            int j = 0;
            foreach (char letter in textToWrite)
            {
                if (konec) break;

                Console.CursorVisible = true;

                char userKey = Console.ReadKey(true).KeyChar;

                try
                {
                    Console.SetCursorPosition(i, j);
                }
                catch (ArgumentOutOfRangeException)
                {
                    j++;
                    i = 0;
                    Console.SetCursorPosition(i, j);
                }

                if (userKey == letter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(letter);
                    Console.ResetColor();
                    schetchikbuv++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(letter);
                    Console.ResetColor();
                    Oshibki++;
                }
                i++;
            }
            Console.CursorVisible = false;
            Score();
        }

        private void Timer()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            do
            {
                Console.CursorVisible = false;

                Console.SetCursorPosition(0, 15);
                Console.WriteLine($"Time Left: 0:{60 - stopwatch.ElapsedMilliseconds / 1000}");
                Thread.Sleep(1000);
            }
            while (60 - stopwatch.ElapsedMilliseconds / 1000 >= 0);

            stopwatch.Stop();
            stopwatch.Reset();

            konec = true;
        }

        private void AddToScoreTable()
        {
            List<chelik> cheliki;
            if (!File.Exists("record.json"))
            {
                FileStream fileStream = File.Create("record.json");
                cheliki = new List<chelik>();
                fileStream.Dispose();
            }
            else
            {
                string usersInfo = File.ReadAllText("record.json");
                cheliki = JsonConvert.DeserializeObject<List<chelik>>(usersInfo);
            }

            cheliki.Add(new chelik(Name, schetchikbuv, Math.Round(Convert.ToDouble(schetchikbuv) / 60, 3), Oshibki));

            cheliki.Sort((x, y) => x.BukvyVminutu.CompareTo(y.BukvyVminutu));
            cheliki.Reverse();
            string json = JsonConvert.SerializeObject(cheliki);
            File.WriteAllText("record.json", json);
        }

        private void Score()
        {
            Console.SetCursorPosition(0, 16);
            Console.WriteLine($"Ваш результат: {schetchikbuv} буквы в минуту | {Math.Round(Convert.ToDouble(schetchikbuv) / 60, 3)} Буквы в секунду \nОшибки: {Oshibki}\nНажмите ENTER чтобы начать заново\nНажмите ESC чтобы выйти");

            AddToScoreTable();

            schetchikbuv = 0;
            Oshibki = 0;

            ConsoleKeyInfo Key;
            do
            {
                Key = Console.ReadKey(true);
                if (Key.Key == ConsoleKey.Escape)
                {
                    menu.MainMenu();
                }
            } while (Key.Key != ConsoleKey.Enter);

            Console.Clear();
            Test();
        }

        private char[] TextToWrite()
        {
            string[] text = { "Осенний вечер. Листья шуршат под ногами. Звезды ярко сверкают на небе, словно невидимые руки раскидали бриллианты по чистому синему полотну. Холодный ветер поглаживает щеки, напоминая о приближающейся зиме. Кажется, что в этот момент можно почувствовать каждый вздох осени, каждый шорох листьев, словно они шепчут об изменениях.",
                              "В такие моменты природа окружает нас своим тайным величием, заставляя задуматься о бесконечном потоке времени и о том,   как мгновение могут оставить след в наших сердцах. Осень - время переходов, время грусти и теплых воспоминаний, время для новых начинаний.",
                              "В этой невероятной атмосфере хочется замедлить темп, вдохнуть глубоко осенний воздух и насладиться этими мгновениями, проникнутыми смыслом и гармонией."};

            Random random = new Random();
            char[] result = text[random.Next(0, text.Length)].ToCharArray();

            return result;
        }
    }
}
