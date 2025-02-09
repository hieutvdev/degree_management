﻿using degree_management.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace degree_management.infrastructure.Data.EFConfigurations;

public class StudentGraduatedConfiguration : IEntityTypeConfiguration<StudentGraduated>
{
    public void Configure(EntityTypeBuilder<StudentGraduated> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FullName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.DateOfBirth)
            .IsRequired();
        builder.Property(c => c.StudentCode).IsRequired().IsUnicode();
        builder.Property(c => c.Gender).IsRequired();
        builder.Property(c => c.GraduationYear).IsRequired();
        builder.Property(c => c.GPA10).IsRequired();
        builder.Property(c => c.Honors).IsRequired();
        builder.Property(c => c.ContactEmail).HasMaxLength(50);
        builder.Property(c => c.PhoneNumber).HasMaxLength(11);
    }
}