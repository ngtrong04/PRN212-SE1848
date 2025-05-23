void swap(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void sort_array(int []arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(ref arr[i], ref arr[j]);
            }
        }
    }
}

int[] values = new int[10];
void create_array(int[] values)
{
    Random rd = new Random();
    for (int i = 0; i < values.Length; i++)
    {
        values[i] = rd.Next(100);
    }
}

void print_array(int[] values)
{
    foreach (int value in values)
    {
        Console.Write($"{value}\t");
    }

}

create_array(values);
print_array(values);
sort_array(values);
Console.WriteLine("\nMang sau khi sap xep: ");
print_array(values);

Console.WriteLine("----");

void sort_array_by_while (int []values)
{
    int i = 0;
    while(i < values.Length)
    {
        int j = i + 1;
        while(j < values.Length)
        {
            if (values[i] > values[j])
            {
                swap(ref values[i], ref values[j]);
            }
            j++;
        }
        i++;
    }
}

void sort_array_by_dowhile(int[] values)
{
    int i = 0;
    do
    {
        int j = i + 1;
        do
        {
            if (values[i] > values[j])
            {
                swap(ref values[i], ref values[j]);
            }
            j++;
        } while (j < values.Length);
        i++;
    } while (i < values.Length);
}

sort_array_by_while(values);
sort_array_by_dowhile(values);

