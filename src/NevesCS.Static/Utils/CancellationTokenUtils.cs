namespace NevesCS.Static.Utils;

public static class CancellationTokenUtils
{
    public static CancellationToken CreateNewCanceledCancellationToken()
    {
        return new CancellationToken(canceled: true);
    }
}
