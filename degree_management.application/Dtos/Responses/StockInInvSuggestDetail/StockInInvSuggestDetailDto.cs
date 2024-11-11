using degree_management.constracts.Abstractions;

namespace degree_management.application.Dtos.Responses.StockInInvSuggestDetail;

public class StockInInvSuggestDetailDto
{
    public int Id { get; set; }
    public int StockInInvSuggestId { get; set; }
    public int DegreeTypeId { get; set; }
    public int Quantity { get; set; }
}