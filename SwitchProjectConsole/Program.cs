using System;
using System.Globalization;
using System.Threading;

namespace SwitchProjectConsole
{
    class Program
    {
        static string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя" };
        static string[] months = { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
        enum Operations
        {
            _OperationPlus,
            _OperationMinus,
            _OperationMultiply,
            _OperationDivide
        }
        static void Main(string[] args)
        {
            CultureInfo ci = (CultureInfo.InvariantCulture.Clone() as CultureInfo);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
            int selectJob;
            while (true)
            {// навряд-чи тут є сенс робити do-while
                Console.WriteLine("Оберіть варіант роботи\n 1-Розшивровка дня тижня\n 2-Розшифровка місяця\n 3-Операції над числами\n 0-Вихід");
                if (int.TryParse(Console.ReadLine(), out selectJob))
                {
                    switch (selectJob)
                    {
                        case 0:
                            Console.WriteLine("Вихід з програми");
                            return;
                        case 1:
                            SelectNumber(ref days, "дня тижня");
                            break;
                        case 2:
                            SelectNumber(ref months, "місяця");
                            break;
                        case 3:
                            Console.WriteLine("Напишіть операцію:\n 1 - '+'\n 2 - '-'\n 3 - '*'\n 4 - '/'");
                            int operation;
                            decimal a, b;
                            if (int.TryParse(Console.ReadLine(),out operation) && operation > 0 && operation < 5)
                            {
                                Console.WriteLine("Прекрасно! Тепер введіть два числа через ентер");
                                if (decimal.TryParse(Console.ReadLine(), out a) && decimal.TryParse(Console.ReadLine(), out b))
                                {
                                    Console.WriteLine($"Результат: {OperationNumbers(operation, a, b)}");
                                } else
                                {
                                    ErrorNumberFormat();
                                }
                            } else
                            {
                                Console.WriteLine("Число не відповідає умові.");
                            }
                            break;
                        default:
                            Console.WriteLine("Число не відповідає умові....");
                            break;
                    }
                } else
                {
                    ErrorNumberFormat();
                }
            }
        }
        /// <summary>
        /// інформація в родовому відмінку
        /// </summary>
        /// <param name="massive"></param>
        /// <param name="information"></param>
        static void SelectNumber(ref string[] massive, string information)
        {
            int massiveLenght = massive.Length;
            int number;
            Console.WriteLine($"Ви обрали розшифровку {information}, для правильної роботи програми пишіть числа від 0 до {massiveLenght} включно, де 0 - вихід");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))//7
                {
                    if (number == 0)
                    {
                        return;
                    } else if (number > 0 && number <= massiveLenght)
                    {
                        Console.WriteLine($"{number} - {massive[number - 1]}");
                    } else
                    {
                        Console.WriteLine("Число не відповідає умові!");
                    }
                } else
                {
                    ErrorNumberFormat();
                }
            }
        }
        static decimal OperationNumbers (int operation, decimal a, decimal b) {
            switch (operation) {
                case 1:
                    return a + b;
                case 2:
                    return a - b;
                case 3:
                    return a * b;
                case 4:
                    if (b == 0)
                    {
                        Console.WriteLine("НЕ діліть на нуль!!!!!");
                        // можна й просто return 0;, але так веселіше
                        throw new Exception("Роботу програми припинено, оскільки подальша її робота може призвести до небажаних наслідків!");
                    }
                    return a / b;
                default:
                    Console.WriteLine("Число не відповідає умові.");
                    return 0;
            }
        }
        static void ErrorNumberFormat ()
        {
            Console.WriteLine("Невірний формат введеного числа.");
        }
    }
}
