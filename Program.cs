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
    try
    {
        string description = args[1];
        TaskItem newItem = new TaskItem(description);
        var createdId = storage.Add(newItem);
        Console.WriteLine($"Successfully created item, Id: {createdId}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}

if (command == Commands.Update)
{
    return;
}

if (command == Commands.Delete)
{
    string id = args[1];

    if (!int.TryParse(id, out int intId))
    {
        Console.WriteLine($"Failed deleting item, Id is not valid.");
    }

    try
    {
        int result = storage.Delete(intId);

        if (result > 0)
        {
            Console.WriteLine($"Successfully deleted item, Id: {id}");
        }

        Console.WriteLine($"Failed deleting item, Id: {id}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Failed deleting item.");
    }
}

if (command == Commands.MarkInProgress)
{
}

if (command == Commands.MarkDone)
{
}

//if (command == Commands.List)
//{
//    // status (done, in-progress, todo );
//    string status = args[1];
//
//    if (string.IsNullOrWhiteSpace(status))
//    {
//        var list = storage.List(status);
//
//        Console.WriteLine($"Successfully got items list with status {status},\n qwe");
//    }
//
//
//    var list = storage.List();
//}
