using Microsoft.Extensions.CommandLineUtils;
using System;

namespace SimpleCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.HelpOption("-?|-h|--help");
            app.VersionOption("--version", "1.0.0");

            app.Command("greetings", command =>
            {

                command.Description = "Greet someone";
                command.HelpOption("-?|-h|--help"); 

                var nameArg = command.Argument("[name]", "The name to greet");
                var fullOption = command.Option("-f|--full", "full greeting flag", CommandOptionType.NoValue);

                command.OnExecute(() =>
                {
                    var name = nameArg.Value;
                    var fullGreeting = fullOption.HasValue();
                    Console.WriteLine($"Hello {name}." + (fullGreeting ? " Hope you're fine !" : ""));
                    return 0;
                });
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });
            try
            {
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
                app.ShowHelp();
            }
        }
    }
}
