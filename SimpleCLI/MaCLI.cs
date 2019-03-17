using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCLI
{
    public class MaCLI: CommandLineApplication
    {
        public MaCLI()
        {
            this.HelpOption("-?|-h|--help");
            this.VersionOption("--version", "1.0.0");

            this.Command("greetings", command =>
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

            this.OnExecute(() =>
            {
                this.ShowHelp();
                return 0;
            });
        }
    }
}
