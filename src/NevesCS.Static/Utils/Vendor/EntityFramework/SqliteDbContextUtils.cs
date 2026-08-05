using Microsoft.EntityFrameworkCore;

namespace NevesCS.Static.Utils.Vendor.EntityFramework;

public static class SqliteDbContextUtils
{
    /// <summary>
    /// Switches the database backing <paramref name="dbContext"/> to WAL journal mode, which lets readers and a
    /// writer access the database concurrently instead of blocking each other.
    /// </summary>
    /// <param name="checkSuccess">If <c>true</c>, reads back the mode to confirm the switch took effect.</param>
    /// <returns>
    /// <c>1</c>/<c>0</c> for success/failure if <paramref name="checkSuccess"/> is <c>true</c>; otherwise the
    /// PRAGMA's raw (not reliable) row count.
    /// </returns>
    public static async Task<int> SetJournalModeWalAsync<TDbContext>(
        TDbContext dbContext,
        bool checkSuccess,
        CancellationToken cancellationToken = default)

        where TDbContext : DbContext
    {
        if (checkSuccess)
        {
            var isModeWal = (await dbContext.Database
                .SqlQueryRaw<string>("PRAGMA journal_mode=WAL;")
                .SingleAsync(cancellationToken))
                == "wal";

            return isModeWal ? 1 : 0;
        }

        return await dbContext.Database.ExecuteSqlRawAsync("PRAGMA journal_mode=WAL;", cancellationToken);
    }
}
