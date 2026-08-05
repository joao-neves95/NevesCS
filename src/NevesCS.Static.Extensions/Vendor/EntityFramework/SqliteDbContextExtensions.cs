using Microsoft.EntityFrameworkCore;

using NevesCS.Static.Utils.Vendor.EntityFramework;

namespace NevesCS.Static.Extensions.Vendor.EntityFramework;

public static class SqliteDbContextExtensions
{
    public static async Task<int> SetJournalModeWal<TDbContext>(
        this TDbContext dbContext,
        bool checkSuccess,
        CancellationToken cancellationToken = default)

        where TDbContext : DbContext
    {
        return await SqliteDbContextUtils.SetJournalModeWal(dbContext, checkSuccess, cancellationToken);
    }
}
