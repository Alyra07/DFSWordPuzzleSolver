namespace Services;

// Loads the list of words from /App/Data/words.txt
public static class WordLoader
{
    public static List<string> LoadWords(string filePath)
    {
        return File.ReadAllLines(filePath).ToList();
    }
}