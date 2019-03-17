using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace SimpleCLI
{
    public class MaCLI : CommandLineApplication
    {
        public MaCLI(AppContext context)
        {
            this.HelpOption("-?|-h|--help");
            this.VersionOption("--version", "1.0.0");

            this.Command("greetings", command =>
            {

                command.Description = "Greet someone";
                command.HelpOption("-?|-h|--help");

                CommandArgument idArg = command.Argument("[Id]", "Id of the user to greet");
                CommandOption fullOption = command.Option("-f|--full", "full greeting flag", CommandOptionType.NoValue);

                command.OnExecute(() =>
                {
                    if (int.TryParse(idArg.Value, out int id))
                    {
                        User user = context.Users.First(x => x.Id == id);
                        bool fullGreeting = fullOption.HasValue();
                        Console.WriteLine($"Hello {user.FirstName} {user.LastName}." + (fullGreeting ? " Hope you're fine !" : ""));
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine($"Argument 'Id' was not an integer");
                        return 1;
                    }
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
