//one();
//two();
//three();
four();
static double f(double x)
{
    Random rnd = new Random();
    int a = rnd.Next(-50, 50);
    if (x < 0)
    {
        return x + Math.Pow(Math.Sin((1 / (x - a)) + 4), 2);
    }
    else
    {
        return (a * x) / (Math.Sqrt(a * a - x * x));
    }
}

void one()
{
    Console.Write("Введите x = ");
    try
    {
        double x = double.Parse(Console.ReadLine());
        double res = f(x);
        if (Double.IsNaN(res) || Double.IsInfinity(res)) throw new Exception("Не числовое значение");
        else Console.WriteLine(res);
    }
    catch
    {
        Console.WriteLine("Не числовое значение");
    }
}

static void Input(double[] arr, int k1, int k2)
{
    for (int i = k1; i <= k2; i++)
    {
        Console.Write($"Введите {i + 1}-й элемент массива: ");
        try
        {
            arr[i] = double.Parse(Console.ReadLine());
        }
        catch
        {
            throw new TwoException("Второе искл");
        }
    }
}

static void Fill(double[] arr, int k1, int k2)
{
    Random rnd = new Random();
    for (int i = k1; i <= k2; i++)
    {
        arr[i] = rnd.Next(-50, 50);
    }
}

void two()
{
    double[] arr = new double[10];
    try
    {
        Input(arr, 3, 8);
        foreach (double num in arr) Console.Write($"{num} ");
        Console.WriteLine();
    }
    catch (FormatException)
    {
        Console.WriteLine("Неправильное значение!");
    }
    Fill(arr, 3, 8);
    foreach (double num in arr) Console.Write($"{num} ");
    Console.WriteLine();
}

int CatchNum()
{
    int res;
    while (true)
    {
        try
        {
            res = int.Parse(Console.ReadLine());
            break;
        }
        catch
        {
            Console.Write("Неправильное значение!\n" +
                "Давай еще раз = ");
        }
    }
    return res;
}

bool shtrih(double x, double y)
{
    if (x >= -4 && x <= 0 && y >= -4 && y <= 4) return true;
    else if (Math.Sqrt(x * x + y * y) <= 4 && x >= 0 && x <= 4 && y >= 0 && y <= 4) return true;
    else return false;
}

void three()
{
    Console.Write("Введите k1 = ");
    int k1 = CatchNum();
    Console.Write("Введите k2 = ");
    int k2 = CatchNum();
    Console.Write("Введите размер массива n = ");
    int n = CatchNum();
    double[] x = new double[n];
    try
    {
        Input(x, k1, k2);
    }
    catch (IndexOutOfRangeException)
    {
        Console.Write("Одно из чисел не может быть индексом т.к оно за пределом размера массива");
    }
    catch (FormatException)
    {
        Console.WriteLine("Неправильное значение!");
    }
    try
    {
        Fill(x, 0, k1 - 1);
        Fill(x, k2 + 1, n - 1);
    }
    catch (IndexOutOfRangeException)
    {
        Console.Write("Одно из чисел не может быть индексом т.к оно за пределом размера массива");
    }
    foreach (double num in x) Console.Write($"{num} ");
    Console.WriteLine();
    double[] y = new double[n];
    for (int i = 0; i < n; i++)
    {
        double xs = f(x[i]);
        try
        {
            if (double.IsNaN(xs) || double.IsInfinity(xs)) throw new Exception();
            else
            {
                Console.WriteLine($"{i + 1}) Есть!");
                y[i] = xs;
            }
        }
        catch when (double.IsNaN(xs))
        {
            Console.WriteLine($"{i + 1}) NaN");
        }
        catch when (double.IsInfinity(xs))
        {
            Console.WriteLine($"{i + 1}) Infinity");
        }
    }
    foreach (double num in y) Console.Write($"{num} ");
    Console.WriteLine();
    int count = 0;
    for (int i = 0; i < n; i++)
    {
        if (y[i] != null)
        {
            if (shtrih(x[i], y[i]))
            {
                Console.WriteLine($"Попала ({x[i]}, {y[i]})");
                count++;
            }
        }
    }
    Console.WriteLine($"Всего попало {count} точек");
    double start = 0;
    for (int i = 1; i < n; i++)
    {
        try
        {
            if (y[i] != null)
            {
                double s1 = Math.Pow(Math.Abs(x[i] - x[i - 1]), 2) + Math.Pow(Math.Abs(y[i] - y[i - 1]), 2);
                start += Math.Sqrt(s1);
            }
            else
            {
                throw new Exception("Расчёт окончен");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    Console.WriteLine($"Длина ломанной линии {start}");
}

void four()
{
    Console.Write("Введите x = ");
    try
    {
        double x = double.Parse(Console.ReadLine());
        double res = f(x);
        if (Double.IsNaN(res)) throw new NaNOfException("Не числовое значение NaN");
        else if (Double.IsInfinity(res)) throw new InfinityOfException("Бесконечное значение");
        else Console.WriteLine(res);
    }
    catch (NaNOfException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InfinityOfException ex)
    {
        Console.WriteLine(ex.Message);
    }
    double[] arr = new double[10];
    try
    {
        Input(arr, 3, 8);
        foreach (double num in arr) Console.Write($"{num} ");
        Console.WriteLine();
    }
    catch (TwoException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

class NaNOfException : Exception
{
    public NaNOfException(string message)
        : base(message)
    { }
}

class InfinityOfException : Exception
{
    public InfinityOfException(string message)
        : base(message)
    { }
}

class TwoException : FormatException
{
    public TwoException(string message) : base(message) { }
}