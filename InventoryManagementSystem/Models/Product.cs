using InventoryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace InventoryManagementSystem.Models
{
    public class Product : IProduct
    {
        private static int _NextProductId = 1; // starts at 1
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public Product()
        {
            ProductId = _NextProductId++;
        }

        public Product(string name, int quantity, decimal price) : this()
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public void DisplayProductInfo()
        {
            Console.WriteLine($"{("Product ID: " + ProductId),-15} {("Name "+ Name),-15} {("Quantity: " + Quantity),-15} {("Price: " + Price),-15}");
        }
    }
}

