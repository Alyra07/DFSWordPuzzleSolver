namespace Services
{
    // Abstract base class providing file reading functionality for WordLoader & GridLoader
    public abstract class LoaderBase<T> : ILoader<T>
    {
        // Read lines from a file & clean them
        protected List<string> ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line)) // skip empty lines
                       .Select(line => line.Trim().ToUpper()) // trim & convert to uppercase
                          .Select(line => line.Replace(" ", "")) // remove spaces
                       .ToList(); // convert to list of strings
        }
        // Abstract method implemented in derived classes (GridLoader & WordLoader)
        public abstract T Load(string filePath);
    }
}