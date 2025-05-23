/*
 * Để bài:
 * Nhập vào 1 số >=0 nếu nhập sai bắt nhập lại
 * Nếu nhập đúng ==> tính giai thừa của nó
 */

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int n = -1;
while (n < 0)
{
    Console.WriteLine("Nhập n >= 0:");
    string s = Console.ReadLine();
    if (int.TryParse(s, out n) == false)
    {
        Console.WriteLine("Bạn phải nhập số");
    }
    else
    {
        if (n < 0)
        {
            Console.WriteLine("Bạn phải nhập số >= 0:");
        }
    }  
}

int giaithua = 1;
for (int i = 1; i <= n; i++)
{
    giaithua *= i;
}
Console.WriteLine($"{n}! = {giaithua}");