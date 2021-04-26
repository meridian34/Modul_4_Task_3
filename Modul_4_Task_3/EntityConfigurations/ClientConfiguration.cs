using Modul_4_Task_3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Modul_4_Task_3.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).HasColumnName("ClientId");
            builder.Property(c => c.CompanyName).HasColumnName("CompanyName").HasMaxLength(50).IsRequired();
            builder.Property(c => c.ContactEmail).HasColumnName("ContactEmail").HasMaxLength(50).IsRequired();
            builder.Property(c => c.ContactPhone).HasColumnName("ContactPhone").HasMaxLength(15).IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description").HasMaxLength(100);
        }
    }
}
