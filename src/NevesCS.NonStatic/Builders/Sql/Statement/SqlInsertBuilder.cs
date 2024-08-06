using NevesCS.Static.Utils;
using NevesCS.Static.Utils.Sql;

using System.Linq.Expressions;

namespace NevesCS.NonStatic.Builders.Sql.Statement
{
    public sealed class SqlInsertBuilder
    {
        private string TableName { get; set; }

        private IEnumerable<string> ColumnNames { get; set; }

        private IEnumerable<object?> AllValues { get; set; }

        public SqlInsertBuilder Into(string tableName)
        {
            TableName = ObjectUtils.AssertNotNull(tableName, nameof(tableName));

            return this;
        }

        public SqlInsertBuilder Into<TEntity>(TEntity into)
        {
            TableName = ObjectUtils.AssertNotNull(into, nameof(into))!.GetType().Name;

            return this;
        }

        public SqlInsertBuilder Values(params object[] values)
        {
            AllValues = values;

            return this;
        }

        public SqlInsertBuilder Values(params (string, object)[] columns)
        {
            foreach (var column in columns)
            {
                ColumnNames = ColumnNames.Append(column.Item1);
                AllValues = AllValues.Append(column.Item2);
            }

            return this;
        }

        public SqlInsertBuilder Values<TEntity>(TEntity entity, params Expression<Func<TEntity, object?>>[] columnSelectors)
        {
            ColumnNames = IEnumerableUtils.OrEmpty(columnSelectors?.Select(exp => ReflectionUtils.GetPropertyName(exp) ?? string.Empty));
            AllValues = columnSelectors.Select(exp => exp.Compile()(entity));

            return this;
        }

        public string Build()
        {
            // TODO: Update the statement with the different DB vendor specifications.
            return $"""
                INSERT INTO {TableName} {(ColumnNames.Any() ? $"({string.Join(',', ColumnNames)})" : string.Empty)}
                VALUES ({string.Join(',', AllValues.Select(val => SqlUtils.IsSqlStringLikeType(val) ? $"'{val}'" : val))})
                """;
        }
    }
}
