using System.Text.Json;
/// added this to use System.Text.Json.JsonDocument


namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of JSON (.json) files.
/// </summary>
public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";
    /// I changed the SupportedFormat to "JSON"

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON data stream...");
        /// I also changed the output message here

        string jsonDisplay = File.ReadAllText(filePath);

        JsonDocument document = JsonDocument.Parse(jsonDisplay);

        int count = 0;

        ///enum object counts properties if .json file containts objects
        ///enum array counts elements if .json file contains array

        try
        {
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                count++;
            }

            Console.WriteLine($" -> Successfully parsed with {count} properties detected.");

        }
        catch
        {
            count = 0;

            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                count++;
            }

            Console.WriteLine($" -> Successfully parsed with {count} elements detected.");
        }

        string displayContent = jsonDisplay;

        if (displayContent.Length > 100)
        {
            displayContent = displayContent.Substring(0, 100) + "...";
        }

        Console.WriteLine();
        Console.WriteLine("--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------");
    }
}