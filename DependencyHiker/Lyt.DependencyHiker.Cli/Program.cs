#define LYT_ONLY_DEBUG

namespace Lyt.DependencyHiker.Cli;

internal class Program
{
    // If main is made async, it must return a Task  
    static async Task Main(string[] args)
    {
        System.Console.WriteLine("Welcome to Lyt.Translator! Loading...");
        System.Console.WriteLine("Current directory: " + Environment.CurrentDirectory);
        await Run(args);
    }

    static async Task Run(string[] args)
    {
        try
        {
            var hiker = new Hiker();
            hiker.Initialize();
#if LYT_ONLY_DEBUG

            //List<string> excludedNamespaces =["System.", "Microsoft.", "Avalonia."];
            //Assembly.GetExecutingAssembly(), excludedNamespaces
            string[] debugArgs = 
                [
                    @"C:\Users\Laurent\source\repos\Lyt.Avalonia.Translator\AstroPicLanguages.json"
                ];
            await hiker.RunAsync(debugArgs);
            System.Console.ReadLine();
#else
            await hiker.RunAsync(args);
#endif
            await Task.Delay(500);
            await hiker.Shutdown();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Exception thrown: \n\n" + ex.ToString());
            System.Console.ReadLine();
        }
    }
}
