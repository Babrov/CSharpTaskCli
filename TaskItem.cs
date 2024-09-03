namespace CSharpConsoleTaskTracker;

public class TaskItem
{
    public int Id { get; set; }
    public string Status { get; private set; } = "todo";
    public string Description { get; set; } = "";
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public TaskItem(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new Exception("Description cannot be empty");
        }

        Description = description;
        CreatedAt = DateTimeOffset.Now;
        UpdatedAt = DateTimeOffset.Now;
    }
};