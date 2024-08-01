using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WC.Service.EmailDomains.Data.Models;

namespace WC.Service.EmailDomains.Data.PostgreSql.Context;

public sealed class EmailDomainDbContext : DbContext
{
    public EmailDomainDbContext(
        DbContextOptions<EmailDomainDbContext> options,
        IHostEnvironment environment)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<EmailDomainEntity> EmailDomains { get; set; } = null!;
}
