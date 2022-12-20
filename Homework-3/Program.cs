using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static Homework_3.NotSolutionException;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Переменные 
            string a, b, c;
            int aInt = 0, bInt = 0, cInt = 0;
            bool goo = true;
            int x1 = 0;
            int x2 = 0;
            int x = 0;

            //Получение значений от пользователя (a,b,c) ---------------------------------------//
            Console.WriteLine(" Формула\n a * x^2 + b * x + c = 0");
            //Запрос а
            do
            {
                Console.Write("Введите значение a: ");
                a = Console.ReadLine();
                userData(a,"a");
            }
            while (goo);
            //Запрос b
            do
            {
                Console.Write("Введите значение b: ");
                b = Console.ReadLine();
                userData(b,"b");
            }
            while (goo);
            //Запрос c
            do
            {
                Console.Write("Введите значение c: ");
                c = Console.ReadLine();
                userData(c,"c");
            }
            while (goo);
            //Наводим порядок после ввода значений (a,b,с)
            clearConsole();

            //Решение уравнения ----------------------------------------------------------------//
            //Считаем Дискриминант: D = b^2-4ac
            int discriminant = Convert.ToInt32((bInt * bInt) - (4 * aInt * cInt));
            Console.WriteLine($" Дискриминант = {discriminant}");
            //Для Примера
            //Console.WriteLine(String.Format(" Дискриминант = {0}", discriminant));
           

            Solution();

            //Методы ---------------------------------------------------------------------------//
            //Проверка что ввёл юзер
            int userData(string nom, string name)
            {
                goo = true;
                int nomInt = 0;
                try
                {
                    nomInt = int.Parse(nom);
                    if (nomInt == 0 && name == "a")
                    {
                        throw new Exception("Нельзя чтобы (а) была ровна 0!");
                    }
                    goo = false;
                    //Заполняем свичём переменные Int
                    switch (name)
                    { 
                        case "a":
                            aInt = nomInt;
                            break;
                        case "b":
                            bInt = nomInt;
                            break;
                        case "c":
                            cInt = nomInt;
                            break;
                    }
                }
                catch (Exception ex )
                {
                    Console.WriteLine(ex.Message + "\nЗначение должно быть целым числом, вы ввели что-то другое!");
                    Console.WriteLine();
                }
                return nomInt;
            }
            //Чистим консоль от мусора после ввода значений
            void clearConsole()
            { 
                Console.Clear();
                Console.WriteLine(" Формула\n a * x^2 + b * x + c = 0\n------------------------");
                Console.WriteLine($" Введённые значения\n а = {a}, b = {b}, c = {c}\n------------------------");
            }
            //Решение
            void Solution()
            {
                double koren = Math.Sqrt(discriminant);
                try
                {
                    if (discriminant > 0) // Корней 2
                    {
                        x1 = (-bInt + (int)koren) / (2 * aInt);
                        x2 = (-bInt - (int)koren) / (2 * aInt);
                        Console.WriteLine($" x1 = {x1}\n x2 = {x2}");
                    }
                    else if (discriminant == 0) // Корней 1
                    {
                        x = (-bInt + (int)koren) / (2 * aInt);
                        Console.WriteLine($" x = {x}");
                    }
                    else // Корней нет
                    {
                        throw new NotSolutionException("Вещественных значений не найдено");
                    }
                }
                catch (NotSolutionException ex)
                {
                    FormatData(ex.Message, Severity.Warning);
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так!");
                }
            }

            void FormatData(string message, Severity severity)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{message}:{severity}");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
