class Game
{
    public int[] create_matrix(int width)
    {
        Random rand = new Random();
        int[] array = new int[width];
        for (int i = 0; i < width; i++)
        {
            array[i] = rand.Next(-1000, 1000);
        }
        return array;
    }

    public int[,] create_double_matrix(int height, int width)
    {
        Random rand = new Random();
        int[,] array = new int[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                array[i, j] = rand.Next(-1000, 1000);
            }
        }
        return array;
    }

    public void average(int[] array)
    {
        Console.WriteLine($"Среднее арифметическое матрицы = {array.Sum() / array.Length}");
    }

    public void geometric(int[] array)
    {
        double mul = 1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                mul *= Math.Pow(array[i], 0.01);
            }
        }
        Console.WriteLine($"Среднее геометрическое матрицы = {mul}");
    }

    public void quadratic(int[] array)
    {
        double res = 0;
        for (int i = 0; i < array.Length; i++)
            res += Math.Pow(array[i], 2);

        Console.WriteLine($"Среднее квадратическое матрицы = {res / array.Length}");
    }

    public void sum_arrays(int[,] array1, int[,] array2)
    {
        for (int i = 0; i < array1.GetLength(0); i++)
        {
            for (int j = 0; j < array1.GetLength(1); j++)
                Console.Write($"{String.Format("{0,5}", array1[i, j] + array2[i, j])} ");
            Console.WriteLine();
        }
    }

    public void sub_arrays(int[,] array1, int[,] array2)
    {
        for (int i = 0; i < array1.GetLength(0); i++)
        {
            for (int j = 0; j < array1.GetLength(1); j++)
                Console.Write($"{String.Format("{0,5}", array1[i, j] - array2[i, j])} ");
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {

        Game game = new Game();

        try
        {
            Console.WriteLine("""
            Добро пожаловать в игру! Чтобы начать выберите один из вариантов:
            Чтобы посчитать среднее арифметическое массива длиной 100 с различными числами введите 'среднее арифметическое'
            Чтобы посчитать среднее геометрическое массива длиной 100 с различными числами введите 'среднее геометрическое'
            Чтобы посчитать среднее квадратическое массива длиной 100 с различными числами введите 'среднее квадратическое'
            Чтобы посчитать сумму двух матриц любой размерности введите 'сумма матриц'
            Чтобы посчитать разность двух матриц любой размерности введите 'разность матриц'
            """);

            switch (Console.ReadLine().ToLower().Trim())
            {
                case "среднее арифметическое":
                    game.average(game.create_matrix(100));
                    break;

                case "среднее геометрическое":
                    game.geometric(game.create_matrix(100));
                    break;

                case "среднее квадратическое":
                    game.quadratic(game.create_matrix(100));
                    break;

                case "сумма матриц":
                    Console.WriteLine("""
                    Введите размерность матриц.
                    Пример:
                    3
                    3
                    Где первое число - длина матрицы
                    Второе число - ширина матрицы
                    """);
                    int width_sm = int.Parse(Console.ReadLine());
                    int height_sm = int.Parse(Console.ReadLine());
                    int[,] array_sm1 = game.create_double_matrix(width_sm, height_sm);
                    int[,] array_sm2 = game.create_double_matrix(width_sm, height_sm);

                    game.sum_arrays(array_sm1, array_sm2);
                    break;

                case "разность матриц":
                    Console.WriteLine("""
                    Введите размерность матриц.
                    Пример:
                    3
                    3
                    Где первое число - длина матрицы
                    Второе число - ширина матрицы
                    """);
                    int width_sub = int.Parse(Console.ReadLine());
                    int height_sub = int.Parse(Console.ReadLine());
                    int[,] array_sub1 = game.create_double_matrix(width_sub, height_sub);
                    int[,] array_sub2 = game.create_double_matrix(width_sub, height_sub);

                    game.sub_arrays(array_sub1, array_sub2);
                    break;

                default:
                    Console.WriteLine("Некорректное имя игры, пожалуйста, вводите только то, что предлагается в меню игры");
                    break;
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.WriteLine("Введен некорректный аргумент для вычисления!\nПожалуйста, вводите только числа");
        }
    }
}
