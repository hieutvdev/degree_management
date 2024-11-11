using degree_management.constracts.Abstractions;
using Newtonsoft.Json;

namespace degree_management.domain.Entities;

public class StockInInvSuggestDetail : Entity<int>
{
    public int StockInInvSuggestId { get; set; }
    public int DegreeTypeId { get; set; }
    public DegreeType? DegreeType { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public StockInInvSuggest? StockInInvSuggest { get; set; }
}