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
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).HasColumnName("TitleId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
        }
    }
}
