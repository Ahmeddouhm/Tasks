using Inventory_Management_System;
using ConsoleTables;

Console.WriteLine("=====================================");
Console.WriteLine("     Welcome To Inventory System     ");
Console.WriteLine("=====================================");

List<Products> products = new List<Products>();
int productId = 1;
bool isFinished = false;

// Accepting user input
while (!isFinished)
{
    Console.Write("[1] Add | [2] List | [3] Remove | [4] Update | [9] Exit >> ");
    string userChoice = Console.ReadLine() ?? "";
    while (string.IsNullOrEmpty(userChoice))
    {
        Console.Write("[ERROR] [1] Add | [2] List | [3] Remove | [9] Exit >> ");
        userChoice = Console.ReadLine() ?? "";
    }

    switch (userChoice)
    {
        case "1":
            AddProduct();
            break;
        case "2":
            ListAllProducts();
            break;
        case "3":
            RemoveProduct();
            break;
        case "4":
            UpdateProduct();
            break;
        case "9":
            isFinished = true;
            break;
        default:
            Console.WriteLine("Invalid Option !");
            break;
    }
}

// Add Product |
void AddProduct()
{
    Console.Clear();
    Console.WriteLine("[Add Product]");
    Console.WriteLine("=============");

    Console.Write("Enter Name >> ");
    string productName = Console.ReadLine() ?? "";
    while (string.IsNullOrEmpty(productName))
    {
        Console.Write("[ERROR] Enter Name >> ");
        productName = Console.ReadLine() ?? "";
    }

    double productPrice;
    Console.Write("Enter Price >> ");
    while (!double.TryParse((Console.ReadLine() ?? ""), out productPrice))
    {
        Console.Write("[ERROR] Enter Price >> ");
    }

    int productQuantity;
    Console.Write("Enter Quantity >> ");
    while (!int.TryParse((Console.ReadLine() ?? ""), out productQuantity))
    {
        Console.Write("[ERROR] Enter Quantity >> ");
    }

    products.Add(new Products { ID = productId++ , Name = productName , Price = productPrice , Quantity = productQuantity });

    Console.WriteLine("Product Added Successfully !");
    Console.WriteLine("============================");
}

// Update Product |
void UpdateProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !\n");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("[Update Product]");
        Console.WriteLine("================");
        int searchId;
        Console.Write("Enter Product ID >> ");
        while (!int.TryParse((Console.ReadLine() ?? ""), out searchId))
        {
            Console.Write("[ERROR] Enter Product ID >> ");
        }

        int index = SearchID(searchId);

        if (index == -1)
        {
            Console.WriteLine("Product Not Found !\n");
            return;
        }

        Console.Write("Update [1] Name | [2] Price | [3] Quantity >> ");
        string updateChoice = Console.ReadLine() ?? "";
        while (string.IsNullOrEmpty(updateChoice))
        {
            Console.Write("[ERROR] Update [1] Name | [2] Price | [3] Quantity >> ");
            updateChoice = Console.ReadLine() ?? "";
        }

        switch (updateChoice)
        {
            case "1":
                Console.Write("Enter New Name >> ");
                string newName = Console.ReadLine() ?? "";
                while (string.IsNullOrEmpty(newName))
                {
                    Console.Write("[ERROR] Enter New Name >> ");
                    newName = Console.ReadLine() ?? "";
                }
                products[index].Name = newName;
                Console.WriteLine("Product Name Updated !");
                Console.WriteLine("======================");
                break;
            case "2":
                Console.Write("Enter New Price >> ");
                double newPrice;
                while (!double.TryParse((Console.ReadLine() ?? ""), out newPrice))
                {
                    Console.Write("[ERROR] Enter New Price >> ");
                }
                products[index].Price = newPrice;
                Console.WriteLine("Product Price Updated !");
                Console.WriteLine("=======================");
                break;
            case "3":
                Console.Write("Enter New Quantity >> ");
                int newQuantity;
                while (!int.TryParse((Console.ReadLine() ?? ""), out newQuantity)) 
                {
                    Console.Write("[ERROR] Enter New Quantity >> ");
                }
                products[index].Quantity = newQuantity;
                Console.WriteLine("Product Quantity Updated !");
                Console.WriteLine("==========================");
                break;
            default:
                Console.WriteLine("Invalid Option !\n"); ;
                break;
        }
    }
}

// List Products |
void ListAllProducts()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !\n");
        return;
    }
    else
    {
        Console.Clear();
        var table = new ConsoleTable("ID", "Name", "Price", "Quantity");
        foreach (var product in products)
        {
            table.AddRow(product.ID,product.Name,product.Price,product.Quantity);
        }
        Console.WriteLine(table);
        Console.WriteLine();
    }

}

// Remove Product |
void RemoveProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !\n");
        return;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("[Remove Product]");
        Console.WriteLine("================");
        int searchId;
        Console.Write("Enter Product ID >> ");

        while (!int.TryParse(Console.ReadLine(), out searchId))
        {
            Console.Write("[ERROR] Enter Product ID >> ");
        }
        int index = SearchID(searchId);

        if (index == -1)
        {
            Console.WriteLine("Product Not Found !\n");
            return;
        }
        products.RemoveAt(index);
        Console.WriteLine("Product Removed !");
        Console.WriteLine("=================");
    }
}

int SearchID(int enteredId) 
{
    int index = -1;

    for (int i = 0; i < products.Count; i++)
    {
        if (products[i].ID == enteredId)
        {
            index = i;
            break;
        }
    }

    return index;
}