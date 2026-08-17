using Microsoft.EntityFrameworkCore;

using NevesCS.Static.Utils.Vendor.EntityFramework;

namespace NevesCS.Static.Extensions.Vendor.EntityFramework;

public static class SqliteDbContextExtensions
{
    public static async Task<int> SetJournalModeWalAsync<TDbContext>(
        this TDbContext dbContext,
        bool checkSuccess,
        CancellationToken cancellationToken = default)

        where TDbContext : DbContext
    {
        return await SqliteDbContextUtils.SetJournalModeWalAsync(dbContext, checkSuccess, cancellationToken);
    }

    /// <summary>
    /// Queries the database backing <paramref name="dbContext"/> for its current journal mode without changing it.
    /// </summary>
    /// <returns><c>true</c> if the journal mode is currently WAL.</returns>
    public static async Task<bool> CheckIsWalJournalModeAsync<TDbContext>(
        this TDbContext dbContext,
        CancellationToken cancellationToken = default)

        where TDbContext : DbContext
    {
        return await SqliteDbContextUtils.CheckIsWalJournalModeAsync(dbContext, cancellationToken);
    }
}
