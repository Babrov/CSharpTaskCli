if (args.Length == 0)
{
    Console.WriteLine("Please enter a valid command. Use --help for available commands.");
    return;
}

string[] availableCommands = ["add", "update", "delete", "exit"];
string command = args[0].ToLower();

if (!availableCommands.Contains(command))
{
    Console.WriteLine($"Unknown command '{command}'. Use --help for available commands.");
}

if (command == "--help")
{
    Console.WriteLine($"Available commands: {string.Join(",", availableCommands)}");
}

if (command == "add")
{
    Console.WriteLine($"Adding");

    return;
}

if (command == "update")
{
    Console.WriteLine($"Updating");

    return;
}

if (command == "Delete")
{
    Console.WriteLine($"Adding");

    return;
}
