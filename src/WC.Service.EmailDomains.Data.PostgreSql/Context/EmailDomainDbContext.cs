using Microsoft.EntityFrameworkCore;
using WC.Service.EmailDomains.Data.Models;
using WC.Service.EmailDomains.Data.PostgreSql.Configuration;

namespace WC.Service.EmailDomains.Data.PostgreSql.Context;

public sealed class EmailDomainDbContext : DbContext
{
    public EmailDomainDbContext(
        DbContextOptions<EmailDomainDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<EmailDomainEntity> EmailDomains { get; set; } = null!;

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmailDomainEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
