using Inventory_Management_System;
using ConsoleTables;

Console.WriteLine("=====================================");
Console.WriteLine("     Welcome To Inventory System     ");
Console.WriteLine("=====================================");

List<Products> products = new List<Products>();
int id = 1;
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
    }
}

// Update Product |
void UpdateProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("[Update Product]");
        Console.WriteLine("================");
        int id;
        Console.Write("Enter Product ID >> ");
        while (!int.TryParse((Console.ReadLine() ?? ""), out id))
        {
            Console.Write("[ERROR] Enter Product ID >> ");
        }

        int index = -1;

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ID == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Product Not Found !");
            return;
        }

        Console.Write("Update [1] Name | [2] Price | [3] Quantity >> ");
        string updateChoice = Console.ReadLine() ?? "";
        while (string.IsNullOrEmpty(updateChoice))
        {
            Console.Write("[ERROR] Update [1] Name | [2] Price | [3] Quantity >> ");
        }

        switch (updateChoice)
        {
            case "1":
                Console.Write("Enter New Name >> ");
                string newName = Console.ReadLine() ?? "";
                while (string.IsNullOrEmpty(newName))
                {
                    Console.Write("[ERROR] Enter New Name >> ");
                }
                products[index].Name = newName;
                break;
            case "2":
                Console.Write("Enter New Price >> ");
                double newPrice;
                while (!double.TryParse((Console.ReadLine() ?? ""), out newPrice))
                {
                    Console.Write("[ERROR] Enter New Price >> ");
                }
                products[index].Price = newPrice;
                break;
            case "3":
                Console.Write("Enter New Quantity >> ");
                int newQuantity;
                while (!int.TryParse((Console.ReadLine() ?? ""), out newQuantity)) 
                {
                    Console.Write("[ERROR] Enter New Quantity >> ");
                }
                products[index].Quantity = newQuantity;
                break;
            default:
                Console.WriteLine("Invalid Option !"); ;
                break;
        }
    }
}

// Remove Product |
void RemoveProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !");
        return;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("[Remove Product]");
        Console.WriteLine("================");
        int id;
        Console.Write("Enter Product ID >> ");

        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.Write("[ERROR] Enter Product ID >> ");
        }

        int index = -1;

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ID == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Product Not Found !");
            return;
        }
        
        products.RemoveAt(index);
        Console.WriteLine("Product Removed !");
    }
}

// List Products |
void ListAllProducts()
{
    if (products.Count == 0)
    {
        Console.WriteLine("Empty List !");
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

    products.Add(new Products { ID = id++ , Name = productName , Price = productPrice , Quantity = productQuantity });

    Console.WriteLine("Product Added Successfully !");
}

