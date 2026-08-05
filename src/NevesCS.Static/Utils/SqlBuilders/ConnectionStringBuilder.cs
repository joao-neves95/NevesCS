namespace NevesCS.Static.Utils.SqlBuilders
{
    public static class ConnectionStringBuilder
    {
        /// <summary>
        /// E.g.: "Data Source=c:\mydb.db;Password=myPassword;Mode=ReadWriteCreate" <br/>
        /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/compare#connection-strings"/>
        ///
        /// </summary>
        /// <param name="dataSource">The location.</param>
        /// <param name="readOnly">Read only connection.</param>
        /// <param name="failIfMissing">If the database file doesn't exist, the default behaviour is to create a new file.</param>
        /// <param name="defaultTimeout">Default command timeout, in seconds, before a busy/locked error is raised.</param>
        /// <param name="password">Pass 'null' to use no password.</param>
        /// <remarks>
        /// WAL mode isn't a connection-string concept in Microsoft.Data.Sqlite; enable it by executing
        /// <c>PRAGMA journal_mode=WAL;</c> as a command against the open connection.
        /// </remarks>
        public static string BuildSQLiteAdoNet(
            string dataSource,
            bool failIfMissing,
            bool readOnly,
            int? defaultTimeout,
            string? password)
        {
            return $"Data Source={dataSource};"
                   + (password == null ? "" : $"Password={password};")
                   + (readOnly ? "Mode=ReadOnly;" : failIfMissing ? "Mode=ReadWrite;" : "Mode=ReadWriteCreate;")
                   + ((defaultTimeout ?? -1) > 0 ? $"Default Timeout={defaultTimeout}" : string.Empty);
        }

        public static string AppendToSQLiteAdoNetDataSource(string connectionString, string appender)
        {
            var part1 = connectionString.Split("Data Source=");
            var part2 = part1[1].Split(";");
            part2[0] += appender;

            return $"Data Source={part2[0]}" + ";" + string.Join(";", part2[1..]);
        }
    }
}
