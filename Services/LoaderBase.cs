namespace Services
{
    // Generic loader interface for loading data from a file (grid.txt & words.txt)
    public interface ILoader<T>
    {
        T Load(string filePath);
    }
}

namespace Services
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    // Abstract base class providing file reading functionality for WordLoader & GridLoader
    public abstract class LoaderBase<T> : ILoader<T>
    {
        // Read lines from a file & clean them
        protected List<string> ReadLines(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Where(line => !string.IsNullOrWhiteSpace(line)) // skip empty lines
                       .Select(line => line.Trim().ToUpper()) // uppercase to ensure uniformity
                          .Select(line => line.Replace(" ", "")) // remove spaces
                       .ToList();
        }
        // Abstract method implemented in derived classes (GridLoader & WordLoader)
        public abstract T Load(string filePath);
    }
}