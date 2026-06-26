using System.Xml.Linq;
/// added this to use System.Xml.Linq.XDocument

namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of XML (.xml) files.
/// </summary>
public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML document stream...");

        XDocument docu = XDocument.Load(filePath);

        string root = docu.Root.Name.ToString();

        int count = 0;

        foreach (var node in docu.Descendants())
        {
            count++;
        }

        Console.WriteLine("\nRoot element name: " + root);
        Console.WriteLine("Total descendant nodes count: " + count);

        string xmlDisplay = docu.ToString();

        string displayContent = xmlDisplay;

        if (displayContent.Length > 100)
        {
            displayContent = displayContent.Substring(0, 100) + "...";
        }

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}