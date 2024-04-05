using System;
namespace HotelManageMent;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Operation.DefaultValues();
        Operation.Display();
        FileHandling.Readcsv();
        Operation.MainMenu();
        FileHandling.Writecsv();
    }
}