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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(p => p.Budget).HasColumnName("Budget").HasColumnType("money").IsRequired();
            builder.Property(p => p.StartedDate).HasColumnName("StartedDate").HasColumnType("datetime2").HasMaxLength(7).IsRequired();
        }
    }
}
