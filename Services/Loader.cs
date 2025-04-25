namespace Services
{
    // Generic loader interface for different types of data (grid & words)
    public interface ILoader<T>
    {
        T Load(string filePath);
    }
}