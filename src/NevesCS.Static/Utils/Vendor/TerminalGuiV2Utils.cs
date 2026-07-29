using System.Data;
using Terminal.Gui.Views;

namespace NevesCS.Static.Utils.Vendor;

public static class TerminalGuiV2Utils
{
    public static DataTableSource BuildDataTableSource(
        IReadOnlyCollection<(string name, Type dataType, string? expr)> columnDefinitions,
        object[][] rowData
    )
    {
        var dataTable = new DataTable();

        IEnumerableUtils.ForEach(
            columnDefinitions,
            def => dataTable.Columns.Add(new DataColumn(def.name, def.dataType, def.expr))
        );

        IEnumerableUtils.ForEach(
            rowData,
            row => dataTable.Rows.Add(row)
        );

        return new DataTableSource(dataTable);
    }

    public static DataTableSource AddRowToTableView(TableView tableView, object[] rowData)
    {
        var dataTableSource = (DataTableSource)tableView.Table!;
        dataTableSource.DataTable.Rows.Add(rowData);

        return dataTableSource;
    }
}
