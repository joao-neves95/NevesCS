using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions;

public static class CancellationTokenSourceExtensions
{
    public static CancellationToken GetTokenSafe(this CancellationTokenSource cancellationTokenSource)
    {
        return CancellationTokenSourceUtils.GetTokenSafe(cancellationTokenSource);
    }
}
