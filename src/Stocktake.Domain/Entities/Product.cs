using Stocktake.Domain.ValueObjects;

namespace Stocktake.Domain.Entities;

public class Product : BaseEntity
{
    private Product()
    {
        
    }
    
    public string Name { get; private set; } = string.Empty;
    public string SKU { get; private set; } = string.Empty;
    public BarCode BarCode { get; private set; }
    public Quantity ActualQuantity { get; private set; }
    public bool IsActive { get; private set; }

    public static Product Create(string name, string sku, BarCode barCode, Quantity actualQuantity, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome da sessão é obrigatório.", nameof(name));

        return new Product
        {
            Name = name,
            SKU = sku,
            BarCode = barCode,
            ActualQuantity = actualQuantity,
            IsActive = isActive
        };
    }
}