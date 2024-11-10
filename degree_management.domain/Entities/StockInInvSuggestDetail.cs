using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class StockInInvSuggestDetail : Entity<int>
{
    public int StockInInvSuggestId { get; set; }
    public StockInInvSuggest? StockInInvSuggest { get; set; }
    public int DegreeTypeId { get; set; }
    public DegreeType? DegreeType { get; set; }
    public int Quantity { get; set; }
}