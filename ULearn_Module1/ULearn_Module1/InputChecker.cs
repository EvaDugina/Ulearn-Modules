using System;
using System.Reflection;

public class Output<T> {

    public T Variable { get; set; }
    public string ErrorText { get; set; }

    public Output() { 
        ErrorText = string.Empty;
    }

}

public class InputChecker
{

    public static bool GetInputString(string input_name, out string input) {
        Console.Write($"Введите {input_name}: ");
        input = Console.ReadLine();
        if (input == "")
            return false;
        return true;
    }

    public static bool GetInput<T>(string input_name, out Output<T> output)
    {
        output = new Output<T>();
        if (!GetInputString(input_name, out string input))
            return false;

        // Получаем метод TryParse для типа T
        MethodInfo tryParseMethod = typeof(T).GetMethod(
            "TryParse",
            BindingFlags.Public | BindingFlags.Static,
            null,
            new Type[] { typeof(string), typeof(T).MakeByRefType() },
            null
        );

        if (tryParseMethod == null)
        {
            output.ErrorText = $"Тип {typeof(T).Name} не поддерживает TryParse!";
            return false;
        }

        // Параметры для вызова: input + null (для out-параметра)
        object[] parameters = new object[] { input, null };
        bool success = (bool)tryParseMethod.Invoke(null, parameters);

        if (success)
        {
            output.Variable = (T)parameters[1]; // Извлекаем результат
            return true;
        }
        else
        {
            output.ErrorText = "Неверный тип данных!";
            return false;
        }
    }
}
