public class Product : IProduct
{
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public string Category { get; private set; }

    public Product(string name, Money price, string category = "General")
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва не може бути порожньою!");

        Name = name;
        Price = price;
        Category = category;
    }

    public override string ToString() => $"Product: {Name}, Price: {Price}, Category: {Category}";
}