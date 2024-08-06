using NevesCS.Static.Constants;
using NevesCS.Static.Utils.Sql.Functions;

namespace NevesCS.Static.Utils.Sql.Triggers
{
    public static class UpdateTimestampTriggerSqlBuilder
    {
        public static string Create(
            DatabaseVendorName databaseVendor,
            string tableName,
            string columnName,
            string fkName)
        {
            return databaseVendor switch
            {
                DatabaseVendorName.Sqlite => SqlLiteCreate(tableName, columnName, fkName),
                DatabaseVendorName.MySql => MySqlCreate(tableName, columnName, fkName),
                DatabaseVendorName.PostgreSql => PostgreSqlCreate(tableName, columnName, fkName),

                _ => throw new NotImplementedException(),
            };
        }

        public static string Drop(
            DatabaseVendorName databaseVendor,
            string tableName,
            string columnName)
        {
            return databaseVendor switch
            {
                DatabaseVendorName.Sqlite => DropTriggerSqlBuilder.SqlLite(SqlLiteTriggerName(tableName, columnName)),
                DatabaseVendorName.MySql => DropTriggerSqlBuilder.MySql(MySqlTriggerName(tableName, columnName)),
                DatabaseVendorName.PostgreSql => DropTriggerSqlBuilder.PostgreSql(PostgreSqlTriggerName(tableName, columnName)),

                _ => throw new NotImplementedException(),
            };
        }

        public static string SqlLiteTriggerName(string tableName, string columnName)
        {
            return $"{tableName}_{columnName}_UPDATE";
        }

        public static string SqlLiteCreate(string tableName, string columnName, string fkName)
        {
            return $"""
                CREATE TRIGGER {SqlLiteTriggerName(tableName, columnName)}
                AFTER UPDATE ON "{tableName}"
                FOR EACH ROW
                BEGIN
                    UPDATE "{tableName}"
                    SET {columnName} = {SqlCurrentDatetimeFunction.Sqlite}
                    WHERE {fkName} = NEW.{fkName};
                END;
                """;
        }

        public static string MySqlTriggerName(string tableName, string columnName)
        {
            return $"{tableName}_{columnName}_UPDATE";
        }

        public static string MySqlCreate(string tableName, string columnName, string fkName)
        {
            return $"""
                CREATE TRIGGER {MySqlTriggerName(tableName, columnName)}
                AFTER UPDATE ON `{tableName}`
                FOR EACH ROW
                BEGIN
                    UPDATE `{tableName}`
                    SET {columnName} = {SqlCurrentDatetimeFunction.MySQL}
                    WHERE {fkName} = NEW.{fkName};
                END;
                """;
        }

        public static string PostgreSqlTriggerName(string tableName, string columnName)
        {
            return $"{tableName}_{columnName}_UPDATE";
        }

        public static string PostgreSqlCreate(string tableName, string columnName, string fkName)
        {
            return $"""
                -- Function called by the trigger.
                CREATE OR REPLACE FUNCTION update_column_with_now(column_name text, fk_name text)
                RETURNS TRIGGER AS $$
                BEGIN
                    EXECUTE 'UPDATE ' || quote_ident(TG_TABLE_NAME) ||
                            ' SET ' || quote_ident(column_name) || ' = ' || {SqlCurrentDatetimeFunction.PostgreSQL} ||
                            ' WHERE ' || quote_ident(TG_TABLE_NAME) || '.' || quote_ident(fk_name) || ' = ' || quote_literal(OLD.(quote_ident(fk_name)));
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER {PostgreSqlTriggerName(tableName, columnName)}
                AFTER UPDATE ON "{tableName}"
                FOR EACH ROW
                EXECUTE FUNCTION update_column_with_now('{columnName}', '{fkName}');
                """;
        }
    }
}
