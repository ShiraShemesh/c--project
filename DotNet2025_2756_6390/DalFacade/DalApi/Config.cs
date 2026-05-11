namespace DalApi;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        // קבל את ה-assembly location ל-DalFacade
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;
        string assemblyDir = Path.GetDirectoryName(assemblyLocation) ?? AppContext.BaseDirectory;

        string configPath = Path.Combine(assemblyDir, "dal-config.xml");

        Console.WriteLine($"Assembly Location: {assemblyLocation}");
        Console.WriteLine($"Assembly Dir: {assemblyDir}");
        Console.WriteLine($"Checking: {configPath} - Exists: {File.Exists(configPath)}");

        if (!File.Exists(configPath))
        {
            throw new DalConfigException($"dal-config.xml file not found at: {configPath}");
        }

        XElement dalConfig = XElement.Load(configPath) ??
            throw new DalConfigException("dal-config.xml file is not found");
        s_dalName = dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");
        var packages = dalConfig.Element("dal-packages")?.Elements() ??
             throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
