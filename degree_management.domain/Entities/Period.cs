﻿using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class Period : Entity<int>
{
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; } 
    public DateTime? EndDate { get; set; }
    public string? Description { get; set; }
    public int YearGraduationId { get; set; }
    public YearGraduation? YearGraduation { get; set; }
    public List<StudentGraduated> StudentGraduateds { get; set; } = new List<StudentGraduated>();
}