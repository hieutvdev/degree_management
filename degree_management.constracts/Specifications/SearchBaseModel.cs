namespace degree_management.constracts.Specifications;

public class SearchBaseModel
{
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
    public string? KeySearch { get; set; } = default!;
    public string? SortBy { get; set; } = default!;
    public bool? IsOrder { get; set; } = default!;
}