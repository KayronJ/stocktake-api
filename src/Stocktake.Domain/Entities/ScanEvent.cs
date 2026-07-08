using System.Security.AccessControl;
using Stocktake.Domain.ValueObjects;

namespace Stocktake.Domain.Entities;

public class ScanEvent : BaseEntity
{
    private ScanEvent()
    {
        
    }
    
    public Guid StocktakeSessionId { get; private set; }
    public Guid StocktakeSessionItemId { get; private set; }
    public BarCode BarCode { get; private set; }
    public Quantity Quantity { get; private set; }
    public Guid IdempotencyKey { get; private set; }
    public DateTimeOffset ScannedAt { get; private set; }

    public static ScanEvent Create(
        Guid sessionId, Guid itemId, BarCode barCode, 
        Quantity quantity, Guid idempotencyKey, DateTimeOffset scannedAt)
    {
        if (quantity.Value <= 0)
            throw new ArgumentException("Quantidade escaneada deve ser positiva.");

        var scan = new ScanEvent
        {
            StocktakeSessionId = sessionId,
            StocktakeSessionItemId = itemId,
            BarCode = barCode,
            Quantity = quantity,
            IdempotencyKey = idempotencyKey,
            ScannedAt = scannedAt
        };

        return scan;
    }
}