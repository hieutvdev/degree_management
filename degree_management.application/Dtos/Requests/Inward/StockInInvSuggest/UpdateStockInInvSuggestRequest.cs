using degree_management.application.Dtos.Responses.StockInInvSuggestDetail;
using degree_management.domain.Enums;

namespace degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;

public record UpdateStockInInvSuggestRequest(
    int Id,
    int WarehouseId,
    int RequestPersonId,
    IEnumerable<StockInInvSuggestDetailDto> StockInInvSuggestDetails,
    StockInInvSuggestStatus Status,
    string? Note
);