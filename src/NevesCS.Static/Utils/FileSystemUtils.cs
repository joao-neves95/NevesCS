namespace NevesCS.Static.Utils
{
    public static class FileSystemUtils
    {
        public static string GetUserProfilePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        public static string GetDesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        public static async Task<DirectoryInfo> CreateDirectoryAsync(string path)
        {
            return await Task.Run(() => Directory.CreateDirectory(path));
        }
    }
}
