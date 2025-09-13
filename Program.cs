using System;

class Program
{
    // Безпечне введення числа з перевіркою
    static int SafeInput(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            else
                Console.WriteLine("Помилка! Введiть цiле число.");
        }
    }

    // Введення масиву з клавіатури
    static int[] InputArray(int n)
    {
        int[] arr = new int[n];
        Console.WriteLine("Введiть елементи масиву:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = SafeInput($"a[{i}] = ");
        }
        return arr;
    }

    // Заповнення масиву випадковими числами
    static int[] RandomArray(int n)
    {
        int[] arr = new int[n];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            arr[i] = rnd.Next(-100, 101); // діапазон [-100; 100]
        }
        return arr;
    }

    // Пошук максимального за модулем елемента
    static int MaxAbsElement(int[] arr)
    {
        int maxAbs = arr[0];
        foreach (int x in arr)
            if (Math.Abs(x) > Math.Abs(maxAbs))
                maxAbs = x;
        return maxAbs;
    }

    // Сума після останнього нульового елемента
    static int SumAfterLastZero(int[] arr)
    {
        int lastZeroIndex = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == 0)
                lastZeroIndex = i;

        int sum = 0;
        if (lastZeroIndex != -1) // якщо є хоча б один нуль
        {
            for (int i = lastZeroIndex + 1; i < arr.Length; i++)
                sum += arr[i];
        }
        return sum;
    }

    // Друк масиву
    static void PrintArray(int[] arr)
    {
        Console.WriteLine("Масив:");
        foreach (int x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    static void Main()
    {
        int n = SafeInput("Введiть розмiр масиву n: ");

        Console.WriteLine("Оберiть спосiб заповнення масиву:");
        Console.WriteLine("1 – з клавiатури");
        Console.WriteLine("2 – випадковими числами");

        int choice;
        while (true)
        {
            choice = SafeInput("Ваш вибiр (1 або 2): ");
            if (choice == 1 || choice == 2) break;
            Console.WriteLine("Помилка! Введiть 1 або 2.");
        }

        int[] arr = (choice == 1) ? InputArray(n) : RandomArray(n);

        PrintArray(arr);

        int maxAbs = MaxAbsElement(arr);
        int sumAfterZero = SumAfterLastZero(arr);

        Console.WriteLine($"Максимальний за модулем елемент: {maxAbs}");
        Console.WriteLine($"Сума елементiв пiсля останнього нуля: {sumAfterZero}");

        Console.WriteLine("Натиснiть будь-яку клавiшу для завершення...");
        Console.ReadKey();
    }
}
