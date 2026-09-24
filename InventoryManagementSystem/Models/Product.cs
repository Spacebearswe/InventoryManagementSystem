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


        
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            ProductId = _NextProductId++;
        }

        /// <summary>
        /// Initializes a new instance of the Product class with the specified name, quantity, and price.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="price">The price of the product.</param>
        public Product(string name, int quantity, decimal price) : this()
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Displays the product information in a formatted manner.
        /// </summary>
        public void DisplayProductInfo()
        {
            Console.WriteLine($"{("Product ID: " + ProductId),-15} {("Name "+ Name),-15} {("Quantity: " + Quantity),-15} {("Price: " + Price),-15}");
        }
    }
}

