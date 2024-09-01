using CSharpConsoleTaskTracker;

if (args.Length == 0)
{
    Console.WriteLine("Please enter a valid command. Use --help for available commands.");
    return;
}

string command = args[0].ToLower();

if (!Commands.Validate(command))
{
    Console.WriteLine($"Unknown command '{command}'. Use --help for available commands.");
}

if (command == Commands.Help)
{
    Console.WriteLine($"Available commands: {string.Join(",", Commands.Values)}");
}

var storage = new JsonStorage();

if (command == Commands.Add)
{
    int newId = storage.GetNewId();

    string description = args[1];
    TaskItem newItem = new TaskItem(newId, description);

    var createdId = storage.Add(newItem);

    Console.WriteLine($"Successfully created item, Id: {createdId}");
}

if (command == Commands.Update)
{
    return;
}

if (command == Commands.Delete)
{
    return;
}

if (command == Commands.MarkInProgress)
{
}

if (command == Commands.MarkDone)
{
}

if (command == Commands.List)
{
    // status (done, in-progress, todo );
}
