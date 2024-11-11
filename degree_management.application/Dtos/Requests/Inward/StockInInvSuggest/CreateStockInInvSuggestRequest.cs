using degree_management.application.Dtos.Responses.StockInInvSuggestDetail;
using degree_management.domain.Enums;

namespace degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;

public record CreateStockInInvSuggestRequest(
    int WarehouseId,
    int RequestPersonId,
    string Code,
    IEnumerable<StockInInvSuggestDetailDto>? StockInInvSuggestDetails,
    StockInInvSuggestStatus Status,
    string? Note
);