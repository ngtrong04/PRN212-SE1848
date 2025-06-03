class Program
{
    public delegate int MyDelegate(int x, int y);
    public delegate int[] YourDelegate(int n);
    static int Cong(int a, int b)
    {
        return a + b;
    }
    static int Tru(int a, int b)
    {
        return a - b;
    }
    static int[] DanhSachSoChan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i = i +2)
        {
            if (i % 2 == 0)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    static int[] DanhSachSoNguyenTo(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            bool isPrime = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void Main(string[] args)
    {
        MyDelegate m = new MyDelegate(Cong);
        Console.WriteLine("5 + 8 = "+ m(5, 8));
        m = new MyDelegate(Tru);
        Console.WriteLine("5 - 8 = " + m(5, 8));

        YourDelegate y = new YourDelegate(DanhSachSoChan);
        int[] arr = y(10);
        Console.WriteLine("Các số chẵn: ");
        foreach (var item in arr)
        {
            Console.Write(item + "\t");
        }

        YourDelegate y2 = new YourDelegate(DanhSachSoNguyenTo);
        int[] arr2 = y2(20);
        Console.WriteLine("\nCác số nguyên tố: ");
        foreach (var item in arr2)
        {
            Console.Write(item + "\t");
        }
    }
}