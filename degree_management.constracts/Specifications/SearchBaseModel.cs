namespace degree_management.constracts.Specifications;

public class SearchBaseModel
{
    public string? KeySearch { get; set; } = default!;
    public string? SortBy { get; set; } = default!;
    public bool? IsOrder { get; set; } = default!;
}