﻿using degree_management.constracts.Abstractions;

namespace degree_management.domain.Entities;

public class DegreeType : Entity<int>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public float Duration { get; set; }
    public string Descripion { get; set; }
    public int Level { get; set; }
    public List<Degree> Degrees { get; set; } = new List<Degree>();
}