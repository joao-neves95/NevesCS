namespace NevesCS.Static.Utils;

public static class CancellationTokenSourceUtils
{
    public static CancellationToken GetTokenSafe(CancellationTokenSource cancellationTokenSource)
    {
        if (cancellationTokenSource is null)
        {
            return CancellationTokenUtils.CreateNewCanceledCancellationToken();
        }

        try
        {
            return cancellationTokenSource.Token;
        }
        catch (OperationCanceledException)
        {
            return CancellationTokenUtils.CreateNewCanceledCancellationToken();
        }
        catch (ObjectDisposedException)
        {
            return CancellationTokenUtils.CreateNewCanceledCancellationToken();
        }
    }
}
