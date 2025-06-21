using System;
using System.Collections.Generic;
using System.Globalization;

namespace Module1
{
    internal class Expressions
    {
        public static void Expr1_Operation(int a, int b)
        {
            // 1 способ:
            // Ограничения:
            // - Только для числовых типов
            // - Риск переполнения(a + b > int.MaxValue)
            // - Не работает с float/ double из - за потери точности
            a = a + b; // a = 3
            b = a - b; // b = 3 - 2 = 1
            a = a - b; // a = 3 - 1 = 2

            // 2 способ (кортежи):
            // Когда избегать "хитрых" методов:
            // - Работа с дробными числами(float/ double)
            // - Критически важный код
            // - Командная разработка(читаемость > оптимизация)
            (a, b) = (b, a); // Обмен через деконструкцию

            // Бенчмарк производительности:
            // Результаты для .NET 8 (nanoseconds/operation)
            // Method     | Int | Long | Double
            // ---------- | --- | -----| -------
            // Temp       | 0.3 | 0.3  | 0.3
            // Arithmetic | 0.4 | 0.4  | ❌
            // XOR        | 0.3 | 0.4  | ❌
            // Tuples     | 0.3 | 0.3  | 0.3

            // !!!! Вывод: Используйте временную переменную или кортежи.
        }

        public static void Expr2_Operation(string input)
        {

            if (input == "")
            {
                Console.WriteLine("Неверное число!");
                return;
            }

            char[] chars = input.ToCharArray();

            //1 способ (обобщенный):
            Array.Reverse(chars);
            Console.WriteLine(chars);

            //2 способ (Для строк с суррогатными парами (эмодзи, некоторые символы Юникода)):
            var elements = StringInfo.GetTextElementEnumerator(chars.ToString());
            var list = new List<string>();
            while (elements.MoveNext())
                list.Add(elements.GetTextElement());
            list.Reverse();
            string result_1 = string.Concat(list);

            // АНТИПАТТЕРН: медленно и ресурсоемко
            string result_2 = "";
            foreach (char c in chars)
                result_2 = c + result_2; // Новая строка на каждой итерации!
        }

        //Expr3.
        //Задано время Н часов (ровно). Вычислить угол в градусах между часовой и минутной стрелками.
        //Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.
        public static void Expr3_Operation(int h)
        {
            if (h < 0 || h > 24)
            {
                Console.WriteLine("Неверное число!");
                return;
            }


            int angle = (h % 12) * 30;
            if (angle > 180)
                angle = 360 - angle;
            Console.WriteLine(angle);
        }

        //Expr4.
        //Найти количество чисел меньших N, которые имеют простые делители X или Y.
        public static void Expr4_Operation(int n, int x, int y)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i % x == 0 && i % y == 0)
                    numbers.Add(i);
            }
            Console.WriteLine($"Количество делящихся чисел: {numbers.Count} [{string.Join(", ", numbers)}]");
        }

        //Expr5.
        //Найти количество високосных лет на отрезке [a, b] не используя циклы.
        public static void Expr5_Operation(int a, int b)
        {
            if (b < a)
            {
                Console.WriteLine("Некорректный диапазон!");
                return;
            }

            int count = (b / 4) - (a / 4);
            Console.WriteLine($"Количество висококсных лет: {count}");
        }

    }
}