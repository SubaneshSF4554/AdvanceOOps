using System;
namespace OnlineGrocery;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
       // Operations.DefaultValues();
        //Operations.Display();
        FileHandling.Readcsv();
        Operations.MainMenu();
        FileHandling.Writecsv();
        
    }
}
