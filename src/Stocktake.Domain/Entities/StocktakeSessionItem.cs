using Stocktake.Domain.ValueObjects;

namespace Stocktake.Domain.Entities;

public class StocktakeSessionItem : BaseEntity
{
    private StocktakeSessionItem()
    {
        
    }
    
    public Guid StocktakeSessionId { get; private set; }
    public Guid? ProductId { get; private set; }
    public BarCode BarCode { get; private set; } 
    public Quantity ProductActualQuantitySnapshot { get; private set; }
    public Quantity CountedQuantity { get; private set; } 
    public bool IsUnexpected { get; private set; }

    public static StocktakeSessionItem Create(Guid stocktakeSessionId, Guid? productId, Quantity snapshot, BarCode barCode, bool isUnexpected = false)
    {
        return new StocktakeSessionItem()
        {
            StocktakeSessionId = stocktakeSessionId,
            ProductId = productId,
            ProductActualQuantitySnapshot = snapshot,
            CountedQuantity = new Quantity(0),
            BarCode = barCode,
            IsUnexpected = isUnexpected
        };
    }
}