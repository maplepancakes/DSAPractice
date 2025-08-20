namespace collections_and_data_iteration_fundamentals;

public class Dictionary
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

    public List<List<string>> GroupAnagramsSolutionOne(string[] anagrams)
    {
        Dictionary<string, List<string>> groupedAnagrams = new Dictionary<string, List<string>>();
        List<List<string>> result = new List<List<string>>();

        for (int i = 0; i < anagrams.Length; i++)
        {
            char[] characters = anagrams[i].ToCharArray();
            Array.Sort(characters);

            string sortedString = new string(characters).ToLower();

            if (!groupedAnagrams.ContainsKey(sortedString))
            {
                groupedAnagrams.Add(sortedString, new List<string>());
            }
            groupedAnagrams[sortedString].Add(anagrams[i]);
        }

        foreach (KeyValuePair<string, List<string>> group in groupedAnagrams)
        {
            result.Add(group.Value);
        }

        return result;
    }

    public List<List<string>> GroupAnagramsSolutionTwo(string[] anagrams)
    {
        Dictionary<string, List<string>> groupedAnagrams = new Dictionary<string, List<string>>();
        List<List<string>> result = new List<List<string>>();

        for (int i = 0; i < anagrams.Length; i++)
        {
            int[] indexOfAlphabets = new int[26];
            string anagram = anagrams[i].ToLower();
            foreach (char c in anagram)
            {
                int index = c - 'a';
                indexOfAlphabets[index]++;
            }

            string key = string.Join("#", indexOfAlphabets);
            if (!groupedAnagrams.ContainsKey(key))
            {
                groupedAnagrams.Add(key, new List<string>());
            }
            groupedAnagrams[key].Add(anagrams[i]);
        }

        foreach (KeyValuePair<string, List<string>> group in groupedAnagrams)
        {
            result.Add(group.Value);
        }

        return result;
    }
}