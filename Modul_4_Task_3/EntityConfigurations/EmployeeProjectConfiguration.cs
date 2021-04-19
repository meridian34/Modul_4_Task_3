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
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(ep => ep.EmployeeProjectId);
            builder.Property(ep => ep.EmployeeProjectId).HasColumnName("EmployeeProjectId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(ep => ep.Rate).HasColumnName("Rate").HasColumnType("money").IsRequired();
            builder.Property(ep => ep.StartedDate).HasColumnName("StartedDate").HasColumnType("datetime2").HasMaxLength(7).IsRequired();

            builder.HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
