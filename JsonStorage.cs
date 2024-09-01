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
    
    public int GetLatestId()
    {
        return File.ReadAllLines(FilePath).Length;
    }
    
    public int GetNewId()
    {
        int latestId = GetLatestId();
        
        return latestId + 1;
    }
    
    public List<T> GetAll<T>(string status)
    {
        return List
    }
    
    public T GetById<T>(int id)
    {
        
        
        return JsonSerializer.Deserialize<T>();
    }
    
    public int Add(TaskItem item)
    {
        string serializedItem = JsonSerializer.Serialize(item);
        
        return 0;
    }
    
    public void SaveChanges()
    {
        
    }
}