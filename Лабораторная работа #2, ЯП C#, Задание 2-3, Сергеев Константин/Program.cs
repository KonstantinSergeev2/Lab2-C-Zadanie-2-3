using System;

namespace TimeOrig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите часы и минуты для первого времени: ");
            byte hours1 = GetInput("Часы (от 0 до 23): ", 23);
            byte minutes1 = GetInput("Минуты (от 0 до 59):", 59);
            Time time1 = new Time(hours1, minutes1);

            Console.WriteLine("Введите часы и минуты для второго времени: ");
            byte hours2 = GetInput("Часы (от 0 до 23): ", 23);
            byte minutes2 = GetInput("Минуты (от 0 до 59):", 59);
            Time time2 = new Time(hours2, minutes2);

            // выполнение вычитания времени (из задания 2)
            Time result = time1.Subtract(time2);
            Console.WriteLine($"Результат вычитания: {result}");

            // унарная операция "--" (из задания 3)
            Console.WriteLine("\nУнарное вычитание минуты из результата: ");
            result--;
            Console.WriteLine($"После уменьшения результата на минуту: {result}");

            // Операции приведения типа (из задания 3)
            byte hours = (byte)result; // явное приведение
            Console.WriteLine($"Количество часов результата (без минут): {hours}");

            bool isNonResultNull = result; // неявное приведение 
            Console.WriteLine($"Является ли результат ненулевым? {isNonResultNull}");

            // бинарная операция сложение двух объектов времени (из задания 3)
            Console.WriteLine("\nВыполним бинарную операцию сложения двух времён: ");
            Time sumResult = time1 + time2;
            Console.WriteLine($"Результат сложения: {sumResult}");
            
            // бинарная операция добавления минут к результату (из задания 3)
            Console.WriteLine("\nДобавляем минуты к результату: ");
            byte minutesToAdd = GetInput("Сколько минут добавить? ", byte.MaxValue);
            Time addeadMinutesResult = result + minutesToAdd;
            Console.WriteLine($"Результат после добавления минут: {addeadMinutesResult}");
        }
        static byte GetInput(string message, byte maxValue)
        {
            while (true)
            {
                Console.WriteLine(message);
                if (byte.TryParse(Console.ReadLine(), out byte value) && value <= maxValue)
                {
                    return value; // если ввод корректный, возвращаем значение
                }
                Console.WriteLine($"Пожалуйста, введите корректное значение от 0 до {maxValue}" );
            }
        }
    }
}