using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public abstract T Load(string filePath); // abstract method implemented in derived classes
    }
}