using System.Diagnostics;

int[] data = new int[1_000_000];
var random = new Random();
for (int i = 0; i < data.Length; i++)
{
    data[i] = random.Next(1, 100);
}

var stopwatch = new Stopwatch();

// Without Span<T>
stopwatch.Start();
ProcessWithoutSpan(data);
stopwatch.Stop();
Console.WriteLine($"Without Span<T>: {stopwatch.ElapsedMilliseconds} ms");

// With Span<T>
stopwatch.Restart();
ProcessWithSpan(data);
stopwatch.Stop();
Console.WriteLine($"With Span<T>: {stopwatch.ElapsedMilliseconds} ms");

void ProcessWithoutSpan(int[] data)
{
    for (int i = 0; i < 100; i++)
    {
        int[] slice = new int[100];
        Array.Copy(data, i * 100, slice, 0, 100);
        ValidateWithoutSpan(slice);
    }
}

static void ProcessWithSpan(int[] data)
{
    Span<int> span = data;
    for (int i = 0; i < 100; i++)
    {
        Span<int> slice = span.Slice(i * 100, 100);
        ValidateWithSpan(slice);
    }
}

static bool ValidateWithoutSpan(int[] dataSlice)
{
    foreach (int value in dataSlice)
    {
        if (value > 90)
        {
            return false;
        }
    }
    return true;
}

static bool ValidateWithSpan(Span<int> dataSlice)
{
    foreach (int value in dataSlice)
    {
        if (value > 90)
        {
            return false; 
        }
    }
    return true;
}