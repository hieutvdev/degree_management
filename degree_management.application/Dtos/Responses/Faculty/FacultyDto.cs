﻿using degree_management.constracts.Abstractions;
using degree_management.domain.Entities;

namespace degree_management.application.Dtos.Responses.Faculty;

public class FacultyDto : Entity<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public string? Description { get; set; } = String.Empty;
}