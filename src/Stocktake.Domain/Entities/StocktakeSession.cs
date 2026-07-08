using Stocktake.Domain.Enums;
using Stocktake.Domain.ValueObjects;

namespace Stocktake.Domain.Entities;

public class StocktakeSession : BaseEntity
{
    private StocktakeSession()
    {
        
    }
    
    public string Name { get; private set; } = string.Empty;
    public SessionStatus Status { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    private readonly List<StocktakeSessionItem> _items = new();
    public IReadOnlyCollection<StocktakeSessionItem> Items => _items.AsReadOnly();
    
    public static StocktakeSession Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome da sessão é obrigatório.", nameof(name));

        return new StocktakeSession
        {
            Name = name,
            Status = SessionStatus.NotStarted
        };
    }

    public void AddExpectedProducts(Guid sessionId, Guid productId, Quantity actualQuantitySnap, BarCode productBarCode)
    {
        if (Status != SessionStatus.NotStarted)
            throw new InvalidOperationException("Itens esperados só podem ser adicionados antes da sessão iniciar.");

        if (_items.Any(i => i.ProductId == productId))
            throw new InvalidOperationException("Produto já foi adicionado à lista esperada desta sessão.");

        _items.Add(StocktakeSessionItem.Create(sessionId, productId, actualQuantitySnap, productBarCode, isUnexpected: false));
    }

    public void Start()
    {
        if (Status != SessionStatus.NotStarted)
            throw new InvalidOperationException("Sessão já foi iniciada.");

        Status = SessionStatus.InProgress;
        StartedAt = DateTime.UtcNow;
    }

    public void Finish()
    {
        if (Status != SessionStatus.InProgress)
            throw new InvalidOperationException("Sessão precisa estar em andamento para finalizar.");

        Status = SessionStatus.Finished;
        FinishedAt = DateTime.UtcNow;
    }
}