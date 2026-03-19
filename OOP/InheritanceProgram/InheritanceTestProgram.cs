namespace InheritanceProgram;

class Program
{
    static void Main(string[] args)
    {
        SalesPerson s = new(1, "Max Verstappen", 45.9m);
        Console.WriteLine(s);
    }
}