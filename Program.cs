using System;

class Program
{
    static void Main()
    {
        int[] array = null;
        Random rnd = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1 - Ввести масив з клавiатури");
            Console.WriteLine("2 - Заповнити масив випадковими числами");
            Console.WriteLine("3 - Вивести масив");
            Console.WriteLine("4 - Знайти максимальний за модулем елемент");
            Console.WriteLine("5 - Знайти суму елементiв пiсля останнього нуля");
            Console.WriteLine("0 - Вихiд");
            Console.Write("Ваш вибiр: ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    array = InputArray();
                    break;

                case "2":
                    array = RandomArray(rnd);
                    Console.WriteLine("Масив згенеровано випадковими числами:");
                    PrintArray(array);
                    break;

                case "3":
                    PrintArray(array);
                    break;

                case "4":
                    FindMaxAbs(array);
                    break;

                case "5":
                    SumAfterLastZero(array);
                    break;

                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;

                default:
                    Console.WriteLine("Невiрний вибiр! Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine("\nНатиснiть будь-яку клавiшу для повернення до меню...");
            Console.ReadKey();
        }
    }

    static int[] InputArray()
    {
        int n;
        while (true)
        {
            Console.Write("Введiть кiлькiсть елементiв (n > 0): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                break;
            Console.WriteLine("Помилка! Введiть додатне цiле число.");
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Введiть елемент [{i}]: ");
                if (int.TryParse(Console.ReadLine(), out arr[i]))
                    break;
                Console.WriteLine("Помилка! Введiть цiле число.");
            }
        }
        return arr;
    }

    static int[] RandomArray(Random rnd)
    {
        int n;
        while (true)
        {
            Console.Write("Введiть кiлькiсть елементiв (n > 0): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                break;
            Console.WriteLine("Помилка! Введiть додатне цiле число.");
        }

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = rnd.Next(-100, 101);
        return arr;
    }

    static void PrintArray(int[] arr)
    {
        if (arr == null)
        {
            Console.WriteLine("Масив ще не створено.");
            return;
        }

        Console.WriteLine("Масив: " + string.Join(" ", arr));
    }

    static void FindMaxAbs(int[] arr)
    {
        if (arr == null)
        {
            Console.WriteLine("Масив ще не створено.");
            return;
        }

        int max = arr[0];
        foreach (int x in arr)
            if (Math.Abs(x) > Math.Abs(max)) max = x;

        Console.WriteLine($"Максимальний за модулем елемент: {max} (|{max}| = {Math.Abs(max)})");
    }

    static void SumAfterLastZero(int[] arr)
    {
        if (arr == null)
        {
            Console.WriteLine("Масив ще не створено.");
            return;
        }

        int lastZero = Array.LastIndexOf(arr, 0);
        if (lastZero == -1)
        {
            Console.WriteLine("У масивi немає нулiв.");
            return;
        }

        int sum = 0;
        for (int i = lastZero + 1; i < arr.Length; i++)
            sum += arr[i];

        Console.WriteLine($"Сума елементiв пiсля останнього нуля: {sum}");
    }
}
