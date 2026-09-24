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
- `Services/InventoryService.cs` — UI/interaction logic calling the model.
- `Models/Inventory.cs` — inventory model implementing `IInventory`.
- `Models/Product.cs` — product model (serialized to JSON).
- `Interfaces/IInventory.cs` — inventory interface.
- `Utillities/FileHandler.cs` — JSON save/load (writes `Inventory.json` to current directory).
- `Utillities/ColoredText.cs` — console color helper.

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
Program --> InventoryService
InventoryService --> Inventory
InventoryService --> ColoredText
InventoryService --> FileHandlerJSON
Inventory ..|> IInventory
Product ..|> IProduct
FileHandlerJSON --> ColoredText
Inventory --> FilehandlerTxt
Inventory --> IProduct
Program --> ColoredText

class Program {
  +Main(): void
  +MainMenu(): void
}
class InventoryService {
  -inventory: Inventory
  +AddProduct(): void
  +DeleteProduct(): void
  +ViewProducts(): void
  +UpdateProduct(): void
  +GenerateReport(): void
  +SaveProducts(): void
  +OpenProducts(): void
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
  +GetAllProducts(): List~Product~
  +GetProduct(int): Product?
  +UpdateProduct(int, Product): void
  +GetProducts(): List~Product~
  +GenerateReport(): void
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
class FilehandlerTxt {
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
  B --> C["Display Menu"]
  C --> D["Read user input"]

  D -->|1 - Add| E["InventoryService.AddProduct()"]
  D -->|2 - Update| F["InventoryService.UpdateProduct()"]
  D -->|3 - Delete| G["InventoryService.DeleteProduct()"]
  D -->|4 - View All| H["InventoryService.ViewProducts()"]
  D -->|5 - Report| I["InventoryService.GenerateReport()"]
  D -->|6 - Load| J["InventoryService.OpenProducts()"]
  D -->|7 - Save| K["InventoryService.SaveProducts()"]
  D -->|0 - Quit| L["Exit"]

  E --> M["Inventory.AddProduct(Product)"]
  F --> N["Inventory.GetProduct(id) -> update -> Inventory.UpdateProduct(id, product)"]
  G --> O["Inventory.DeleteProduct(id)"]
  H --> P["Inventory.GetProducts() -> Product.DisplayProductInfo()"]
  I --> Q["Inventory.GenerateReport()"]
  J --> R["FileHandlerJSON.OpenJSON() -> returns List<Product>"]
  R --> S["Inventory.AddProduct(...) (for each)"]
  K --> T["FileHandlerJSON.Save(List<Product>)"]

  Q --> U["Prompt: Save report?"]
  U -->|y| V["FilehandlerTxt.SaveToFileTxt(reportLines)"]
  U -->|n| W["Return to Menu"]

   L --> Z["End"]
  S --> C
  M --> C
  N --> C
  O --> C
  P --> C
  T --> C
  V --> C
  W --> C
  
```
