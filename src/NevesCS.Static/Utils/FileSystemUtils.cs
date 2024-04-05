namespace NevesCS.Static.Utils
{
    public static class FileSystemUtils
    {
        public static string GetUserProfilePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}
