namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of comma-separated value (.csv) files.
/// </summary>
public class CsvFileReader : BaseFileReader
{
    public override string SupportedFormat => "CSV";
    /// I changed the SupportedFormat to "CSV"

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV stream...");
        /// I also changed the output message

        string[] lines = File.ReadAllLines(filePath);

        int rows = lines.Length;
        int columns = 0;

        if (lines.Length > 0)
        {
            columns = lines[0].Split(',').Length;
        }

        Console.WriteLine($"\nNumber of rows detected: {rows}");
        Console.WriteLine($"Number of columns detected: {columns}");

        /// This counts rows and columns instead of lines of text

        string rawContent = File.ReadAllText(filePath);

        string displayContent = rawContent.Length > 100
            ? rawContent.Substring(0, 100) + "..."
            : rawContent;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}