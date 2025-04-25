namespace Services
{
    // Loader class for loading the list of words from a file (words.txt)
    public class WordLoader : LoaderBase<List<string>>
    {
        public override List<string> Load(string filePath)
        {
            return ReadLines(filePath); // read all lines and clean them
        }
    }
}