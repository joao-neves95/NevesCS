using CsvHelper;

using System.Globalization;

namespace NevesCS.Static.Utils.Vendor
{
    public static class CsvHelperUtils
    {
        public static async Task WriteCsvFileAsync<T>(string filePath, IEnumerable<T> records, bool append, CancellationToken cancellationToken = default)
        {
            await using var streamWriter = new StreamWriter(filePath, append);
            await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            await csvWriter.WriteRecordsAsync(records, cancellationToken);

            await csvWriter.FlushAsync();
            await streamWriter.FlushAsync();
        }

        public static async Task<IAsyncEnumerable<T>> ReadCsvFileAsync<T>(string filePath, CancellationToken cancellationToken = default)
        {
            using var streamReader = new StreamReader(filePath);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

            return csvReader.GetRecordsAsync<T>(cancellationToken);
        }
    }
}
