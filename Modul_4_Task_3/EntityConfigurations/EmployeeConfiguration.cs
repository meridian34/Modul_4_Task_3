using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_4_Task_3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modul_4_Task_3.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(e => e.HiredDate).HasColumnName("HiredDate").HasColumnType("datetime2").HasMaxLength(7).IsRequired();
            builder.Property(e => e.BirthDate).HasColumnName("DateOfBirth").HasColumnType("date");
            
            builder.HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Title)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
