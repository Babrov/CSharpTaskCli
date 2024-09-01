namespace CSharpConsoleTaskTracker;
    
public static class Commands
    {
        public const string Add = "add";
        public const string Update = "update";
        public const string Delete = "delete";
        public const string List = "list";
        public const string Exit = "exit";
        public const string MarkInProgress = "mark-in-progress";
        public const string MarkDone = "mark-done";
        public const string Help = "help";
        
        public static string[] Values => [Add, Update, Delete, List, Exit, MarkInProgress, MarkDone];
    
    public static bool Validate(string command)
    {
        return Values.Contains(command);
    }
}
