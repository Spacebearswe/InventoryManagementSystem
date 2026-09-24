using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Interfaces
{
    public interface IInventory
    {
        List<Product> Products { get; set; }

        void AddProduct();
        void DeleteProduct();
        List<Product> GetAllProducts();
        Product? GetProduct(int productId);
        List<Product> GetProducts();
        void OpenProducts();
        void SaveProducts();
        void UpdateProduct();
    }
}