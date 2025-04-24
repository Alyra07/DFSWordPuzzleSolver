namespace Services;

// Loads the list of words from /App/Data/words.txt
public static class WordLoader
{
    public static List<string> LoadWords(string filePath)
    {
        return File.ReadAllLines(filePath)
                   .Where(line => !string.IsNullOrWhiteSpace(line)) // read only non-empty lines
                   .Select(line => line.Trim().ToUpper()) // convert letters to uppercase
                   .ToList();
    }
}