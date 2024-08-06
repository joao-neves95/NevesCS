namespace NevesCS.NonStatic.Builders.Sql.Statement
{
    public static class SqlStatementBuilder
    {
        public static SqlInsertBuilder Insert()
        {
            return new SqlInsertBuilder();
        }
    }
}
