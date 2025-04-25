using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    // Generic loader interface for different types of data (grid & words)
    public interface ILoader<T>
    {
        T Load(string filePath);
    }
}