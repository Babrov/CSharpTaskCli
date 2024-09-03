using System.Text.Json;

namespace CSharpConsoleTaskTracker;

public class JsonStorage
{
    private const string FilePath = "storage.json";

    public JsonStorage()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }
    }

    public List<TaskItem> List(string? status = default)
    {
        List<string> lines = File.ReadLines(FilePath).ToList();

        return lines.Select(line => JsonSerializer.Deserialize<TaskItem>(line)).ToList();
    }

    public TaskItem? GetById(int id)
    {
        string? itemByLine = ReadLineByNumber(id);

        if (itemByLine is not null)
        {
            return JsonSerializer.Deserialize<TaskItem>(itemByLine);
        }

        return null;
    }

    public int Add(TaskItem item)
    {
        item.Id = GetCount() + 1;

        string serializedItem = JsonSerializer.Serialize(item);

        WriteNewLine(serializedItem);

        return item.Id;
    }

    public int Delete(int id)
    {
        var lines = File.ReadAllLines(FilePath).ToList();

        if (id > 0 && id <= lines.Count)
        {
            lines.RemoveAt(id - 1);
            File.WriteAllLines(FilePath, lines);
            return id;
        }

        return -1; // Indicate failure
    }

    private int GetCount()
    {
        return File.ReadLines(FilePath).Count();
    }

    private void WriteNewLine(string content)
    {
        using (StreamWriter sw = new StreamWriter(FilePath, true))
        {
            sw.WriteLine(content);
        }
    }

    private string? ReadLineByNumber(int lineNumber)
    {
        using (StreamReader sr = new StreamReader(FilePath))
        {
            for (int i = 0; i < lineNumber - 1; i++)
            {
                if (sr.ReadLine() == null)
                {
                    return null;
                }
            }

            return sr.ReadLine();
        }
    }
}