using System;

namespace Module1
{
    internal class Program
    {
        static void Main()
        {
            //Expr1();
            Expr2();
            Expr3();
            Expr4();
            Expr5();

            Console.WriteLine("Конец!");
            Console.ReadLine();
        }

        static void Expr1()
        {
            Console.WriteLine("\n1. Как поменять местами значения двух переменных?\n" +
                "Можно ли это сделать без ещё одной временной переменной. Стоит ли так делать?");

            Expressions.Expr1_Operation(1, 5);
        }

        static void Expr2()
        {
            Console.WriteLine("\n2. Задается натуральное трехзначное число (гарантируется, что трехзначное).\n" +
                "Развернуть его, т.е. получить трехзначное число, записанное теми же цифрами в обратном порядке.");

            while (true)
            {
                if (!InputChecker.GetInputString("трехзначное число", out string input))
                    return;

                Expressions.Expr2_Operation(input);
            }
        }

        static void Expr3()
        {
            Console.WriteLine("\n3. Задано время Н часов (ровно). Вычислить угол в градусах между часовой и минутной стрелками\n" +
                "Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. Не использовать циклы.");

            while (true)
            {
                if (!InputChecker.GetInput<int>("час", out Output<int> output))
                {
                    if (output.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output.ErrorText);
                    continue;
                }

                Expressions.Expr3_Operation(output.Variable);
            }
        }

        static void Expr4()
        {
            Console.WriteLine("\n4. Найти количество чисел меньших N, которые имеют простые делители X или Y.");

            while (true)
            {
                if (!InputChecker.GetInput<int>("N", out Output<int> output_n))
                {
                    if (output_n.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output_n.ErrorText);
                    continue;
                }
                int n = output_n.Variable;

                if (!InputChecker.GetInput<int>("X", out Output<int> output_x))
                {
                    if (output_x.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output_x.ErrorText);
                    continue;
                }
                int x = output_x.Variable;

                if (!InputChecker.GetInput<int>("Y", out Output<int> output_y))
                {
                    if (output_y.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output_y.ErrorText);
                    continue;
                }
                int y = output_y.Variable;

                Expressions.Expr4_Operation(n, x, y);
            }
        }

        static void Expr5()
        {
            Console.WriteLine("\n5. Найти количество високосных лет на отрезке [A, B] не используя циклы.");

            while (true)
            {

                if (!InputChecker.GetInput<int>("A", out Output<int> output_a))
                {
                    if (output_a.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output_a.ErrorText);
                    continue;
                }
                int a = output_a.Variable;

                if (!InputChecker.GetInput<int>("B", out Output<int> output_b))
                {
                    if (output_b.ErrorText == string.Empty)
                        return;
                    Console.WriteLine(output_b.ErrorText);
                    continue;
                }
                int b = output_b.Variable;

                Expressions.Expr5_Operation(a, b);
            }
        }
    }
}