using InventoryManagementSystem.Utilities;
using InventoryManagementSystem.Models;

internal class Program
{
    internal static void Main()
    {
        Program program = new Program();
        program.MainMenu();
    }

    public void MainMenu() 
    {
        var inventory = new Inventory();
        bool doRun = true;
        while (doRun)
        {
            Console.Clear();
            ColoredText.WriteLine("Inventory Management System", ConsoleColor.Yellow);
            Console.WriteLine("");
            Console.WriteLine("Enter a Number");
            Console.WriteLine("1-Add a Product");
            Console.WriteLine("2-Update Product");
            Console.WriteLine("3-Delete Product");
            Console.WriteLine("4-View All Products");
            Console.WriteLine("5-Generate Report");
            Console.WriteLine("6-Load Products");
            Console.WriteLine("7-Save Products");
            Console.WriteLine("0-Quit");
            string? userInput = Console.ReadLine();
            
            switch (userInput)
            {
                case "1":
                    inventory.AddProduct();
                    break;
                case "2":
                    inventory.UpdateProduct();
                    break;
                case "3":
                    inventory.DeleteProduct();
                    break;
                case "4":
                    inventory.ViewProducts();
                    break;
                case "5":
                    inventory.GenerateReport();
                    break;
                case "6":
                    inventory.OpenProducts();
                    break;
                case "7":
                    inventory.SaveProducts();
                    break;
                case "0":
                    Console.WriteLine("Thank you for using this application");
                    doRun = false;
                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

    }
}
