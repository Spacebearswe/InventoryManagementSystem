using InventoryManagementSystem.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using InventoryManagementSystem.Utilities;

namespace InventoryManagementSystem.Models
{
    public class Inventory : IInventory
    {
        public Inventory() { }

        public List<Product> Products { get; set; } = new List<Product>();
        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        /// <param name="product">The product to add to the inventory.</param>
        public void AddProduct()
        {
            Product newProduct = new Product();
            Console.WriteLine("Enter Product Name:");
            while (true)
            {
                string? nameInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(nameInput))
                {
                    newProduct.Name = nameInput;
                    break;
                }
                ColoredText.WriteLine("Invalid input. Please enter a valid Name:", ConsoleColor.Red);
            }
            Console.WriteLine("Enter Product Quantity:");
            while (true)
            {
                string? qtyInput = Console.ReadLine();
                if (int.TryParse(qtyInput, out int qty))
                {
                    newProduct.Quantity = qty;
                    if (qty < 0)
                    {
                        ColoredText.WriteLine("Quantity cannot be negative. Please enter a valid Quantity:", ConsoleColor.Red);
                        continue;
                    }
                    break;
                }
                ColoredText.WriteLine("Invalid input. Please enter a numeric Quantity:", ConsoleColor.Red);
            }
            Console.WriteLine("Enter Product Price:");
            while (true)
            {
                string? priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, out decimal price))
                {
                    if (price < 0)
                    {
                        ColoredText.WriteLine("Price cannot be negative. Please enter a valid Price:", ConsoleColor.Red);
                        continue;
                    }
                    newProduct.Price = price;
                    break;
                }
                ColoredText.WriteLine("Invalid input. Please enter a numeric Price:", ConsoleColor.Red);
            }
            //inventory.AddProduct(newProduct);
            ColoredText.WriteLine("Product added successfully!", ConsoleColor.Green);


            Products.Add(newProduct);
        }

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID, or null if not found.</returns>
        public Product? GetProduct(int productId)
        {

            var product = Products.Find(p => p.ProductId == productId);
            return product;
        }

        /// <summary>
        /// Gets all products in the inventory.
        /// </summary>
        /// <returns>A list of all products in the inventory.</returns>
        public List<Product> GetAllProducts()
        {
            return Products;
        }
        /// <summary>
        /// Updates a product in the inventory based on the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated product information.</param>
        public void UpdateProduct()
        {
            //Use inventory class updateproduct
            ColoredText.WriteLine("Enter Product ID to update:", ConsoleColor.Yellow);
            int productId;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out productId))
                    break;
                ColoredText.WriteLine("Invalid input. Please enter a numeric Product ID:", ConsoleColor.Red);
            }

            var productToUpdate = Products.Find(p => p.ProductId == productId);
            if (productToUpdate != null)
            {

                Console.WriteLine("Enter new Product Name:");
                while (true)
                {
                    string? nameInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        productToUpdate.Name = nameInput;
                        break;
                    }
                    ColoredText.WriteLine("Invalid input. Please enter a valid Name:", ConsoleColor.Red);
                }

                Console.WriteLine("Enter new Product Quantity:");
                while (true)
                {
                    string? qtyInput = Console.ReadLine();
                    if (int.TryParse(qtyInput, out int qty))
                    {
                        productToUpdate.Quantity = qty;
                        break;
                    }
                    ColoredText.WriteLine("Invalid input. Please enter a numeric Quantity:", ConsoleColor.Red);
                }

                Console.WriteLine("Enter new Product Price:");
                while (true)
                {
                    string? priceInput = Console.ReadLine();
                    if (decimal.TryParse(priceInput, out decimal price))
                    {
                        if (price < 0)
                        {
                            ColoredText.WriteLine("Price cannot be negative. Please enter a valid Price:", ConsoleColor.Red);
                            continue;
                        }
                        productToUpdate.Price = price;
                        break;
                    }
                    ColoredText.WriteLine("Invalid input. Please enter a numeric Price:", ConsoleColor.Red);
                }

                ColoredText.WriteLine("Product updated successfully!", ConsoleColor.Green);

                var product = Products.Find(p => p.ProductId == productId);
                if (product != null)
                {
                    product.Name = productToUpdate.Name;
                    product.Quantity = productToUpdate.Quantity;
                    product.Price = productToUpdate.Price;
                }
            }
            else
            {
                ColoredText.WriteLine("Product not found.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Deletes a product from the inventory based on the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        public void DeleteProduct()
        {
            Console.WriteLine("Enter Product ID to delete:");
            int productId;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out productId))
                    break;
                ColoredText.WriteLine("Invalid input. Please enter a numeric Product ID:", ConsoleColor.Red);
            }

            if (productId != 0)
            {
                var product = Products.Find(p => p.ProductId == productId);
                if (product != null)
                {
                    Products.Remove(product);
                    ColoredText.WriteLine("Product removed successfully!", ConsoleColor.Green);
                }
                else
                {
                    ColoredText.WriteLine("Product not found.", ConsoleColor.Red);
                }
            }
            else
                ColoredText.WriteLine("Product not found.", ConsoleColor.Red);
        }
        /// <summary>
        /// Gets all products in the inventory.
        /// </summary>
        /// <returns>A list of all products in the inventory.</returns>
        public List<Product> GetProducts()
        {
            return Products;
        }

        /// <summary>
        /// Displays the list of products in the inventory. Each product's information is displayed using the DisplayProductInfo method.
        /// </summary>
        internal void ViewProducts()
        {
            var products = this.GetProducts();
            if (products.Count != 0)
                ColoredText.WriteLine("-------------------------------------------------------------------------", ConsoleColor.Yellow);
            foreach (var product in products)
            {
                product.DisplayProductInfo();

            }
            if (products.Count != 0)
                ColoredText.WriteLine("-------------------------------------------------------------------------", ConsoleColor.Yellow);
            else ColoredText.WriteLine("No products in list", ConsoleColor.Red);
        }


        /// <summary>
        /// Generates a report of the inventory, including total value and quantity.
        /// Ask the user if they want to save the report to a text file, and if so, saves it using the FilehandlerTxt class.
        /// </summary>
        internal void GenerateReport()
        {
            var productList = this.Products;

            List<string> reportText = new List<string>();

            reportText.Add("Inventory Report");
            reportText.Add("------------------------------------------------------");
            decimal totalValue = 0;
            int totalQty = 0;
            foreach (var product in productList)
            {
                totalValue += product.Price * product.Quantity;
                totalQty += product.Quantity;
            }
            reportText.Add($"Total Inventory Value: {totalValue:C}");
            reportText.Add($"Total Inventory Quantity: {totalQty}");
            reportText.Add("------------------------------------------------------");

            foreach (var line in reportText)
            {
                Console.WriteLine(line);
            }

            /// <summary>
            /// Asks the user if they want to save the inventory report to a text file and saves it if they confirm.
            /// </summary>  
            ColoredText.WriteLine("Save inventory report into InventoryReport.txt? (y)", ConsoleColor.Yellow);
            if (Console.ReadLine() == "y")
            {
                FilehandlerTxt fileHandler = new FilehandlerTxt("InventoryReport.txt");
                fileHandler.SaveToFileTxt(reportText);
                ColoredText.WriteLine("Inventory report saved into InventoryReport.txt", ConsoleColor.Green);
            }
        }
        /// <summary>
        /// Saves the products to a file.
        /// </summary>
        public void SaveProducts()
        {
            var productList = this.GetAllProducts();
            FileHandlerJSON handler = new FileHandlerJSON();
            handler.Save(productList);
            ColoredText.WriteLine("Inventory saved as JSON successfully!", ConsoleColor.Green);
        }

        /// <summary>
        /// Loads the products from a file.
        /// </summary>
        public void OpenProducts()
        {
            FileHandlerJSON handler = new FileHandlerJSON();
            var productList = handler.OpenJSON();
            foreach (var product in productList)
            {
                Products.Add(product);
            }
            ColoredText.WriteLine("Inventory loaded from JSON successfully!", ConsoleColor.Green);
        }

    }
}

