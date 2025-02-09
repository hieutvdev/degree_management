﻿namespace degree_management.application.Dtos.Requests.Degree;

public record UpdateDegreeRequest(
    int Id,
    int StundentId,
    int DegreeTypeId,
    string Code,
    string RegNo,
    DateTime IssueDate,
    int Status,
    string? Description);