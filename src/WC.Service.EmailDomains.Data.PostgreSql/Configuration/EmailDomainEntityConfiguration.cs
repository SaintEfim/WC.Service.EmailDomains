using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WC.Service.EmailDomains.Data.Models;

namespace WC.Service.EmailDomains.Data.PostgreSql.Configuration;

public class EmailDomainEntityConfiguration : IEntityTypeConfiguration<EmailDomainEntity>
{
    public void Configure(
        EntityTypeBuilder<EmailDomainEntity> builder)
    {
        builder.Property(x => x.DomainName)
            .IsRequired();

        builder.HasIndex(x => x.DomainName)
            .IsUnique();
    }
}
