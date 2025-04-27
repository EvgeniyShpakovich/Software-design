public class Warehouse
{
    private List<(Product Product, int Quantity, string Unit, DateTime LastDelivery)> products = new();

    public void AddProduct(Product product, int quantity, string unit, DateTime lastDelivery)
    {
        products.Add((product, quantity, unit, lastDelivery));
    }

    public string InventoryReport()
    {
        string report = "Inventory Report:\n";
        foreach (var item in products)
        {
            report += $"{item.Product.Name} - {item.Quantity} {item.Unit} - Last Delivery: {item.LastDelivery:yyyy-MM-dd}\n";
        }
        return report;
    }
}