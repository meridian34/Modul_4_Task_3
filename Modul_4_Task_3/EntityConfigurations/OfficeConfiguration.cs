using Modul_4_Task_3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modul_4_Task_3.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).HasColumnName("OfficeId").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasColumnName("Title").HasMaxLength(100).IsRequired();
            builder.Property(o => o.Location).HasColumnName("Location").HasMaxLength(100).IsRequired();
        }
    }
}
