using degree_management.application.Dtos.Responses.StockInInvSuggestDetail;
using degree_management.domain.Enums;

namespace degree_management.application.Dtos.Responses.StockInInvSuggest;

public class CreateStockInInvSuggestDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public int? WarehouseId { get; set; }
    public int? RequestPersonId { get; set; }
    public List<StockInInvSuggestDetailDto>? StockInInvSuggestDetails { get; set; }
    public StockInInvSuggestStatus? Status { get; set; }
    public string? Note {get; set;}
}