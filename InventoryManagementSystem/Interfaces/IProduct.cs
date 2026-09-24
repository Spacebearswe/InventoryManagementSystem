namespace InventoryManagementSystem.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }

        void DisplayProductInfo();
    }
}