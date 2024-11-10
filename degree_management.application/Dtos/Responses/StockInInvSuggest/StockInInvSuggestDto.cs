using degree_management.domain.Enums;

namespace degree_management.application.Dtos.Responses.StockInInvSuggest;

public class StockInInvSuggestDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public int? WarehouseId { get; set; }
    public string? WarehouseName { get; set; }
    public int? RequestPersonId { get; set; }
    public StockInInvSuggestStatus? Status { get; set; }
    public string? Note {get; set;}
}