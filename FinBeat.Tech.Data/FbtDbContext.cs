using FinBeat.Tech.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace FinBeat.Tech.Data;

public sealed class FbtDbContext : DbContext
{
    public FbtDbContext()
    {
    }

    public FbtDbContext(DbContextOptions<FbtDbContext> options)
        : base(options)
    {
    }

    public DbSet<DictionaryItem> DictionaryItems => Set<DictionaryItem>();
}