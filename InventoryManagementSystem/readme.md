# Inventory Management System

Small console application for managing a simple product inventory (add, update, delete, view, save/load JSON, generate a basic report).

## Requirements
- .NET 10 SDK (target framework: `net10.0`)
- (Optional) Visual Studio 2026 or any editor/IDE that supports .NET 10

## Build & run
- From a command line (in repository root):
  - Restore & build: `dotnet build`
  - Run: `dotnet run --project InventoryManagementSystem/InventoryManagementSystem.csproj`
- In Visual Studio: use __Build > Rebuild Solution__ then run the project.

## Project layout (key files)
- `Program.cs` — application entry, console menu.
- `Models/Inventory.cs` — inventory model implementing `IInventory`
-  and containing UI/interaction logic calling the model.
- `Models/Product.cs` — product model (serialized to JSON).
- `Interfaces/IInventory.cs` — inventory interface.
- `Utilities/FileHandler.cs` — JSON save/load (writes `Inventory.json` to current directory).
- `Utilities/ColoredText.cs` — console color helper.

## Persistence
- Products are saved to `Inventory.json` in the application's current directory.
- Serializer uses `System.Text.Json` and requires the `Product` type and its properties to be public for correct JSON output.
- The Report is generated as a text file if user chooses to save it, named `InventoryReport.txt` in the current directory.
## Usage
- Start the app and follow the numeric menu:
  - 1 Add, 2 Update, 3 Delete, 4 View All, 5 Generate Report, 6 Load, 7 Save, 0 Quit.

## Notes
- Target framework is `net10.0` (see `InventoryManagementSystem.csproj`).
- The app uses a simple in-memory list and JSON file for persistence; suitable for small demos and learning.

## Contributing
- Open a PR on the repository. Keep changes small and focused.

## License
- No license file included; assume repository owner determines licensing.

## UML class diagram
```mermaid 
classDiagram
Program --> Inventory
Inventory ..|> IInventory
Product ..|> IProduct
FileHandlerJSON --> ColoredText
Inventory --> FileHandlerTxt
Inventory --> FileHandlerJSON
Inventory --> ColoredText
Inventory --> Product
Program --> ColoredText

class Program {
  +Main(): void
  +MainMenu(): void
}
class IInventory <<interface>> {
  +Products: List~Product~
  +AddProduct(Product): void
  +DeleteProduct(int): void
  +GetAllProducts(): List~Product~
  +GetProduct(int): Product?
  +UpdateProduct(int, Product): void
  +GetProducts(): List~Product~
}
class Inventory {
  +Products: List~Product~
  +AddProduct(Product): void
  +DeleteProduct(int): void
  +GetProduct(int): Product?
  +UpdateProduct(int, Product): void
  +GetProducts(): List~Product~
  +GenerateReport(): void
  +ViewProducts(): void
}
class IProduct <<interface>> {
  +Name: string
  +Price: decimal
  +ProductId: int
  +Quantity: int
  +DisplayProductInfo(): void
}
class Product {
  -_NextProductId: int
  +ProductId: int
  +Name: string
  +Quantity: int
  +Price: decimal
  +Product(): void
  +Product(name: string, qty: int, price: decimal): void
  +DisplayProductInfo(): void
}
class FileHandlerJSON {
  -fileNameJSON: string
  +Save(List~Product~): void
  +OpenJSON(): List~Product~
  +LoadJSON(): List~Product~
  +CreateFirstTimeList(): List~Product~
}
class FileHandlerTxt {
  -filePath: string
  +SaveToFileTxt(List~string~): void
}
class ColoredText <<utility>> {
  +WriteLine(string, ConsoleColor): void
  +WriteLine(string): void
  +Write(string, ConsoleColor): void
  +Write(string): void
}
```
# UML flowchart for main menu
```mermaid
flowchart TD
  A["Start"] --> B["Program.Main() / MainMenu()"]
  B --> C["Read user input"]
  
  C -->|1 - Add| D["Inventory.AddProduct()"]
  C -->|2 - Update| E["Inventory.UpdateProduct()"]
  C -->|3 - Delete| F["Inventory.DeleteProduct()"]
  C -->|4 - View All| G["Inventory.ViewProducts()"]
  C -->|5 - Report| H["Inventory.GenerateReport()"]
  C -->|6 - Load| I["Inventory.OpenProducts()"]
  C -->|7 - Save| J["Inventory.SaveProducts()"]
  C -->|0 - Quit| L["Exit"]

  D --> M["Inventory.AddProduct(Product)"]
  E --> N["Inventory.GetProduct(id) -> update -> Inventory.UpdateProduct(id, product)"]
  F --> O["Inventory.DeleteProduct(id)"]
  G --> P["Inventory.GetProducts() -> Product.DisplayProductInfo()"]
  H --> Q["Inventory.GenerateReport()"]
  I --> R["FileHandlerJSON.OpenJSON() -> returns List<Product>"]
  J --> S["Inventory.AddProduct(...) (for each)"]
  J --> T["FileHandlerJSON.Save(List<Product>)"]

  Q --> U["Prompt: Save report?"]
  U -->|y| V["FilehandlerTxt.SaveToFileTxt(reportLines)"]
  U -->|n| W["Return to Menu"]

  L --> Z["End"]
  S --> B
  M --> B
  N --> B
  O --> B
  P --> B
  T --> B
  V --> B
  W --> B
```
