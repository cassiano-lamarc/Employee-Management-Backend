using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrasctructure.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Number)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .HasMaxLength(100);

        builder.Property(e => e.HireDate)
            .IsRequired()
            .HasDefaultValueSql("NOW()");

        builder.Property(e => e.AvatarUrl)
            .HasMaxLength(500);

        builder.Property(e => e.DeparmentId)
            .IsRequired();

        builder.OwnsOne(e => e.Addresss)
            .ToJson();

        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DeparmentId);

        builder.HasOne(e => e.CreatedUser)
            .WithMany(u => u.CreatedEmployees)
            .HasForeignKey(e => e.CreatedUserId);

        builder.HasOne(e => e.UpdatedUser)
            .WithMany(u => u.UpdatedEmployees)
            .HasForeignKey(e => e.UpdatedUserId);
    }
}
