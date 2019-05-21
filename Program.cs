using forkRepo;
using System;
using System.Collections.Generic;
using FindImagesTest;


class Program
{

    static int Factorial(int x)
    {
        if (x == 0)
            return 1;
        return x * Factorial(x - 1);
    }

    private static dynamic FactorialPy(string pyFile, string arg)
    {
        int x = int.Parse(arg);

        ScriptEngine engine = Python.CreateEngine();
        ScriptScope scope = engine.CreateScope();

        engine.ExecuteFile(pyFile, scope);
        dynamic function = scope.GetVariable("factorial");
        dynamic result = function(x);
        return result;
    }
    public static void Main(string [] args)
    {
        string path = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Shaqi_jrvej.jpg/1200px-Shaqi_jrvej.jpg";
        DownloadImageAsync(path);
    }

    private static async void DownloadImageAsync(string filePath)
    {
        await _downloader.DownloadAsync(new Uri(filePath));
        Console.WriteLine($"{_downloader.Filename}");
    }

    public static void Main(string[] args)
    {

        Process();
        Console.ReadKey();
    }

    static async void Process()
    {
        IImagePathFinder finder = new ImagePathFinder("/Users/leonid/Downloads");
        await finder.FindAsync();
        foreach (var item in finder.Result)
        {
            Console.WriteLine(item);
        }

        System.Console.WriteLine("Hello world");
        System.Console.WriteLine("Mish commit");
        System.Console.WriteLine(Factorial(5));
        Console.WriteLine(FactorialPy("1.py", "5"));
    }
}