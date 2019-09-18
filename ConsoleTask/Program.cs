using System;
using System.Globalization;
using System.Threading;
using static System.Math;

namespace ConsoleTask
{
    class Program
    {
        static bool _exit;
        static void OnStart()
        {
            CultureInfo ci = (CultureInfo.InvariantCulture.Clone() as CultureInfo);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.WriteLine("Під час роботи програми дотримуйтесь інструкцій. В будь-який момент часу ви можете вийти з програми, якщо в консоль буде написано 'exit'");
        }
        static void Main(string[] args)
        {
            OnStart();
            double x = 0, y = 0, z = 0, r;
            while(true)
            {
                Console.WriteLine("Напишіть число X, Y та Z через ентер");
                if (ConvertNumber(ref x, Console.ReadLine()) && ConvertNumber(ref y, Console.ReadLine()) && ConvertNumber(ref z, Console.ReadLine()))
                {
                    r = (2 * Cos(Pow(x, 2)) - 0.5) / (0.5 + Sin(Pow(y, 2 - z)))
                               + (Pow(z, 2)) / (7 - z / 3.0); // використовуємо статичні функції класа Math
                    if (CheckNumberErrors(r))
                    {
                        Console.WriteLine("Щось пішло не так, оберіть інші числа!");
                        continue;
                    }
                    Console.WriteLine($"Відповідь {r}");
                } else
                {
                    if (_exit == true)
                    {
                        break;
                    }else
                    {
                        Console.WriteLine("Цикл здійснює нову ітерацію!");
                        continue;
                    }
                }

            }
            Console.WriteLine("Вихід... Для продовження натисніть будь-яку клавішу!");
            Console.ReadKey();
        }

        static bool ConvertNumber(ref double number, string information)
        {
            if (!double.TryParse(information, out number))
            {
                if (information.ToLower() == "exit")
                {
                    _exit = true;
                    return false;
                }
                goto Error;
            }
            return true;
        Error:
            Console.WriteLine("Не вдалося перетворити число");
            return false;
        }

        static bool CheckNumberErrors (double number)
        {
            if (double.IsNaN(number) || double.IsInfinity(number))
            {
                return true;
            }
            return false;
        }
    }
}
