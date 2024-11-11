using degree_management.constracts.Abstractions;
using degree_management.domain.Enums;

namespace degree_management.domain.Entities;

public class StockInInvSuggest : Entity<int>
{
    public string? Code { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }
    public int? RequestPersonId { get; set; }
    public List<StockInInvSuggestDetail>? StockInInvSuggestDetails { get; set; }
    public int? Status { get; set; }
    public string? Note {get; set;}
}
