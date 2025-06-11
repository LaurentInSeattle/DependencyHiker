namespace Lyt.DependencyHiker.Reflector;

public class GraphBuilderParameters
{
    public GraphBuilderParameters() { /* required for serialisatiion */}

    public string RootAssemblyPath { get; set; } = string.Empty;

    public List<string> ExcludedNamespaces { get; set; } = [];
}
