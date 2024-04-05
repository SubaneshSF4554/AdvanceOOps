using System;
namespace MetroCard;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Operations.Default();
        Operations.Display();
        FileHandling.Readcsv();
        Operations.MainMenu();
        FileHandling.Writecsv();
    }
}
