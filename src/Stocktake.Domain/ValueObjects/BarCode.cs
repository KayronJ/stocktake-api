namespace Stocktake.Domain.ValueObjects;

public sealed record BarCode
{
    public string Value { get; }

    private BarCode(string value) => Value = value;

    public static BarCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Bar code não pode ser vazio.");
        
        if (!IsValidFormat(value))
            throw new ArgumentException($"Bar code inválido: {value}");

        return new BarCode(value);
    }

    private static bool IsValidFormat(string value) =>
        value.Length is 12 or 13 && value.All(char.IsDigit);
}
