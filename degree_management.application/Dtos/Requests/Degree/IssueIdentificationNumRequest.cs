namespace degree_management.application.Dtos.Requests.Degree;

public record IssueIdentificationNumRequest(
    List<int> StudentIds,
    int WarehouseId,
    string DecisionNumber,
    string PrefixCode,
    int StartCodeNum,
    int CodeLength,
    string? SuffixCode,
    string PrefixRegNo,
    int StartRegNoNum,
    int RegNoLength,
    string? SuffixRegNo);