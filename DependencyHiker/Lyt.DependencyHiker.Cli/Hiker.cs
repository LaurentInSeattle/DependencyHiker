namespace Lyt.DependencyHiker.Cli;

internal class Hiker() : ConsoleBase(
    Organization,
    Application,
    RootNamespace,
    typeof(ApplicationModelBase), // Top level model 
    [
        // Models 
        typeof(FileManagerModel),
    ],
    [
        // Singletons
    ],
    [
        // Services 
        new Tuple<Type, Type>(typeof(ILogger), typeof(ConsoleLogger)),
        new Tuple<Type, Type>(typeof(IDispatch), typeof(NullDispatcher)),
        new Tuple<Type, Type>(typeof(IProfiler), typeof(Profiler)),
    ])
{
    public const string Organization = "Lyt";
    public const string Application = "DependencyHiker.Cli";
    public const string RootNamespace = "Lyt.DependencyHiker.Cli";
    public const string AssemblyName = "Lyt.DependencyHiker.Cli";
    public const string AssetsFolder = "Assets";

    protected override async void OnStartupBegin()
    {
        // This needs to complete before all models are initialized.
        var fileManager = GetRequiredService<FileManagerModel>();
        await fileManager.Configure(
            new FileManagerConfiguration(
                Hiker.Organization, Hiker.Application, Hiker.RootNamespace,
                Hiker.AssemblyName, Hiker.AssetsFolder));
    }

    protected override async void OnShutdownBegin()
    {
        IApplicationModel applicationModel = GetRequiredService<IApplicationModel>();
        await applicationModel.Shutdown();
    }

    public async Task RunAsync(string[] parameters)
    {
        if (parameters is null || parameters.Length == 0)
        {
            Print("No parameters provided. (Should be a JSon path name)");
            return;
        }

        if (parameters is null || parameters.Length > 1)
        {
            Print("Too many parameters provided. (Should be only one JSon path name)");
            return;
        }

        string path = parameters[0];
        if (!File.Exists(path))
        {
            Print("Provided JSon file does not exist. Path: " + path);
            return;
        }

        try
        {
            Print("Loading: " + path);
        }
        catch (Exception ex)
        {
            Print("Exeption thrown: " + ex);
        }

        await Task.Delay(2_000); 
        return;
    }
}
