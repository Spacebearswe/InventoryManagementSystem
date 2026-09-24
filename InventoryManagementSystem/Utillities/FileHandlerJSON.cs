using InventoryManagementSystem.Interfaces;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;



namespace InventoryManagementSystem.Utilities
{
    public class FileHandlerJSON
    {
        string fileNameJSON = string.Format(@"{0}\Inventory.json", Environment.CurrentDirectory);

        /// <summary>
        /// Saves the list of products to a JSON file.
        /// </summary>
        /// <param name="products">The list of products to save.</param>
        public void Save(List<Product> products)
        {
            //Tries to save the list in a JSON file
            try
            {
                string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileNameJSON, jsonString);
                ColoredText.WriteLine("Your inventory has been saved", ConsoleColor.Green);
            }
            catch (Exception)
            {
                ColoredText.WriteLine("Failed to save inventory!", ConsoleColor.Red);
            }

        }

        /// <summary>
        /// Opens the saved inventory or creates a new one.
        /// </summary>
        /// <returns></returns>
        public List<Product> OpenJSON()
        {
            //If a file exists, load it. Otherwise, create a sample list of tasks.
            if (File.Exists(fileNameJSON)) return LoadJSON();
            else return CreateFirstTimeList();
        }

        /// <summary>
        /// Loads the products from a file.
        /// </summary>
        /// <returns>Loads the products in the List<Product></returns>
        public List<Product> LoadJSON()
        {
            try
            {
                string jsonString = File.ReadAllText(fileNameJSON);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    ColoredText.WriteLine("Saved file empty. Creating sample inventory\n", ConsoleColor.Yellow);
                    return CreateFirstTimeList();
                }

                var products = JsonSerializer.Deserialize<List<Product>>(jsonString)
                               ?? new List<Product>();

                ColoredText.WriteLine("Opened your saved inventory\n", ConsoleColor.Green);
                return products;
            }
            catch (Exception)
            {
                ColoredText.WriteLine("Failed to load saved inventory\n", ConsoleColor.Red);
                return CreateFirstTimeList();
            }
        }

        public List<Product> CreateFirstTimeList()
        {
            //Create a populated list of tasks
            //Inventory inventory = new Inventory();
            //Create a populated list of tasks
            List<Product> Products = new List<Product>();
            Products.Add(new Product("Computer", 10, 2.5m));
            Products.Add(new Product("Laptop", 15, 2.5m));
            Products.Add(new Product("Smartphone", 3, 13.0m));
            Products.Add(new Product("Tablet", 0, 7.5m));
            Products.Add(new Product("Router", 5, 2.0m));

            ColoredText.WriteLine("Did not find a saved inventory to load. Created a sample inventory with some products\n", ConsoleColor.Yellow);
            return Products;
        }
    }

}

