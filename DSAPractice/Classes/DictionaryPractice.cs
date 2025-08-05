namespace collections_and_data_iteration_fundamentals;

public class DictionaryPractice
{
    private Dictionary<string, string> _breed = new Dictionary<string, string>
    {
        {"max", "doberman"},
        {"bobie", "chihuahua"},
        {"abie", "golden retriever"}
    };

    public void CheckName(string name)
    {
        if (_breed.ContainsKey(name))
        {
            Console.WriteLine($"{name} exists!");
            return;
        }
        Console.WriteLine("Name not found");
    }

    public void UpdateBreed(string name, string breed)
    {
        if (!KeyFound(name)) return;

        _breed[name] = breed;
        Console.WriteLine($"Breed {breed} successfully updated for name {name}!");
    }

    public void RemovePet(string name)
    {
        if (!KeyFound(name)) return;

        string breed = _breed[name];
        _breed.Remove(name);
        Console.WriteLine($"Pet with breed {breed} and name {name} removed successfully!");
    }

    private bool KeyFound(string name)
    {
        if (_breed.ContainsKey(name)) return true;
        
        Console.WriteLine($"Breed with name {name} not found");
        return false;
    }

}