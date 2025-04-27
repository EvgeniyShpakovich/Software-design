
class Program
{
    static void Main()
    {
        Money money1 = new Money(10, 50, "USD");
        Money money2 = new Money(12, 40, "USD");
        Money money3 = new Money(13, 30, "USD");
        Product product1 = new Product("Laptop", money1, "Electronics");
        Product product2 = new Product("Banana", money2, "Fruits");
        Product product3 = new Product("Phone", money3, "Electronics");
        
        Warehouse warehouse = new Warehouse();
        warehouse.AddProduct(product1, 5, "pieces", DateTime.Now);
        warehouse.AddProduct(product2, 15, "pieces", DateTime.Now);
        warehouse.AddProduct(product3, 3, "pieces", DateTime.Now);
       
        Reporting reporting = new Reporting();
        reporting.RegisterTransaction(product1, 5, new Money(52, 50, "USD"), "Income");
        reporting.RegisterTransaction(product2, 15, new Money(62, 00, "USD"), "Income");
        reporting.RegisterTransaction(product3, 3, new Money(31, 20, "USD"), "Income");

        Console.WriteLine(product1);
        Console.WriteLine(product2);
        Console.WriteLine(product3);
        Console.WriteLine(warehouse.InventoryReport());
        Console.WriteLine(reporting.GenerateReport());
    }
}