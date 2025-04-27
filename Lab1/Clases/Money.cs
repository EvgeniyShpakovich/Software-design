public class Money : IMoney
{
    public int Whole { get; private set; }
    public int Cents { get; private set; }
    public string Currency { get; private set; }

    public Money(int whole, int cents, string currency)
    {
        if (whole < 0 || cents < 0)
            throw new ArgumentException("Гроші не можуть бути від’ємними!");

        Whole = whole;
        Cents = cents;
        Currency = currency;
    }

    public Money Add(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Валюти не збігаються!");

        int totalCents = (Whole * 100 + Cents) + (other.Whole * 100 + other.Cents);
        return new Money(totalCents / 100, totalCents % 100, Currency);
    }

    public Money Subtract(Money other)
    {
        int totalCents = (Whole * 100 + Cents) - (other.Whole * 100 + other.Cents);
        if (totalCents < 0) totalCents = 0;
        return new Money(totalCents / 100, totalCents % 100, Currency);
    }

    public override string ToString() => $"{Whole}.{Cents:D2} {Currency}";
}