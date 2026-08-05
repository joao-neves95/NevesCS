using FluentAssertions;

using NevesCS.Static.Utils.SqlBuilders;

namespace NevesCS.Tests.Static.SqlBuilders
{
    public class ConnectionStringBuilderTests
    {
        [Fact]
        public void AppendToSQLiteAdoNetDataSource_Passes()
        {
            const string originalConnectionString = "Data Source=c:\\mydb.db;Password=myPassword;";

            ConnectionStringBuilder.AppendToSQLiteAdoNetDataSource(originalConnectionString, "_123")
                .Should()
                .Be("Data Source=c:\\mydb.db_123;Password=myPassword;");
        }

        [Fact]
        public void BuildSQLiteAdoNet_WhenReadWriteWithPasswordAndTimeout_ReturnsWellFormedConnectionString()
        {
            ConnectionStringBuilder
                .BuildSQLiteAdoNet(
                    dataSource: "c:\\mydb.db",
                    failIfMissing: true,
                    readOnly: false,
                    defaultTimeout: 30,
                    password: "myPassword")
                .Should()
                .Be("Data Source=c:\\mydb.db;Password=myPassword;Mode=ReadWrite;Default Timeout=30");
        }

        [Fact]
        public void BuildSQLiteAdoNet_WhenReadOnly_DoesNotAppendMultipleModeSegments()
        {
            var connectionString = ConnectionStringBuilder.BuildSQLiteAdoNet(
                dataSource: "c:\\mydb.db",
                failIfMissing: true,
                readOnly: true,
                defaultTimeout: null,
                password: null);

            connectionString.Should().Be("Data Source=c:\\mydb.db;Mode=ReadOnly;");
            connectionString.Should().NotContain("PRAGMA");
        }
    }
}
