using System.Text;

Console.OutputEncoding = Encoding.UTF8;
void ham1(int n)
{
    n = 8;
    Console.WriteLine($"n trong ham 1: {n} ");

}

int n = 5;
Console.WriteLine($"n truoc khi vao ham: {n} ");
ham1(n);
Console.WriteLine($"n sau khi vào hàm: {n}");

void ham2(ref int n)
{
    n = 8;
    Console.WriteLine($"n trong ham 2: {n} ");
}

Console.WriteLine("=====================================");
n = 5;
Console.WriteLine($"n truoc khi vao ham: {n} ");
ham2(ref n);        // ref yêu cầu biến đó phải có giá trị
Console.WriteLine($"n sau khi vào hàm: {n}");

void ham3(out int n)       // out bắt buộc trong hàm phải có giá trị n
{
    n = 9;
}

n = 113;
ham3(out n);        // out không yêu cầu biến đó phải có giá trị