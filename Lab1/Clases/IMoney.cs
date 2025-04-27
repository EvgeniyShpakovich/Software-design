interface IMoney
{
    int Whole { get; }
    int Cents { get; }
    string Currency { get; }
    Money Add(Money other);
    Money Subtract(Money other);
}