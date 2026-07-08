namespace Stocktake.Domain.ValueObjects;

public readonly record struct Quantity
{
    public int Value { get; }

    public Quantity(int value)
    {
        if (value < 0)
            throw new ArgumentException("Quantidade não pode ser negativa.");
        Value = value;
    }
}