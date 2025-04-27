public class Reporting
{
    private List<(string Product, int Quantity, Money TotalCost, string Type)> transactions = new();

    public void RegisterTransaction(IProduct product, int quantity, Money totalCost, string type)
    {
        if (quantity <= 0)
            throw new ArgumentException("Кількість має бути більше 0!");

        transactions.Add((product.Name, quantity, totalCost, type));
    }

    public string GenerateReport()
    {
        string report = "Transaction Report:\n";
        foreach (var transaction in transactions)
        {
            report += $"Type: {transaction.Type}, Product: {transaction.Product}, Quantity: {transaction.Quantity}, Cost: {transaction.TotalCost}\n";
        }
        return report;
    }
}
