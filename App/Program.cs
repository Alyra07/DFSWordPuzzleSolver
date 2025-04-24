using Services;
using Algorithm;
using Models;

class Program
{
    static void Main(string[] args)
    {
        // Load the grid and words from /Data folder
        var grid = GridLoader.LoadGrid("Data/grid.txt");
        var words = WordLoader.LoadWords("Data/words.txt");

        // Create an instance of the DfsSolver class to find words in the grid
        var solver = new DfsSolver();
        var results = solver.FindWords(grid, words);

        // Display the results
        Console.WriteLine("Words found in the grid:");
        foreach (var result in results)
        {
            Console.WriteLine($"Found '{result.Word}' at positions:");
            foreach (var pos in result.Positions)
            {
                Console.WriteLine($"({pos.Row}, {pos.Col})");
            }
            Console.WriteLine();
        }
    }
}