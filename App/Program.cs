using Services;
using Algorithm;

// Spectre.Console is a library for creating pretty console applications in .NET :)
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        // Create loader instances
        var gridLoader = new GridLoader();
        var wordLoader = new WordLoader();

        // Load grid & words from /Data txt files
        var grid = gridLoader.Load("Data/grid.txt");
        var words = wordLoader.Load("Data/words.txt");

        // Initialize the solver and find words in the grid (DFS algorithm)
        var solver = new DfsSolver();
        var results = solver.FindWords(grid, words);

        if (results.Count == 0) // no words found
        {
            AnsiConsole.MarkupLine("[bold red]No words found! Try editing the words.txt & grid.txt files.[/]");
        }
        else // display words found
        {
            AnsiConsole.MarkupLine($"[green bold]{results.Count} out of {words.Count} words found![/]");
            AnsiConsole.WriteLine();

            // Colors for highlighting found words (from Spectre.Console)
            var colors = new[] { "red", "orange1", "yellow", "lime", "cyan1", "blue", "purple_1", "magenta1" };

            // Draw grid (letter table with headers)
            var table = new Table();
            table.Border(TableBorder.Square);
            table.AddColumn(new TableColumn("[grey]pos[/]")); // position labels

            for (int col = 0; col < grid.Columns; col++)
                table.AddColumn(new TableColumn($"[grey]{col}[/]")); // column number labels

            for (int row = 0; row < grid.Rows; row++)
            {
                var rowCells = new List<string> { $"[grey]{row}[/]" }; // row number labels

                for (int col = 0; col < grid.Columns; col++)
                {
                    string cellText = grid.Grid[row, col].ToString();

                    // Check if this position is part of a found word
                    var matchingResult = results
                        .Select((res, idx) => new { Result = res, Color = colors[idx % colors.Length] })
                        .FirstOrDefault(r => r.Result.Positions.Any(p => p.Row == row && p.Col == col));

                    // -> if it is, highlight the cell with corresponding color
                    if (matchingResult != null)
                    {
                        cellText = $"[{matchingResult.Color} bold]{cellText}[/]";
                    }

                    rowCells.Add(cellText); // add cell text to row
                }

                table.AddRow(rowCells.ToArray()); // add row to table
            }

            AnsiConsole.Write(table); // print table to the console
            AnsiConsole.WriteLine();

            // List found colored words with matching positions (row, col)
            for (int i = 0; i < results.Count; i++)
            {
                var color = colors[i % colors.Length]; // same color for same word in the grid
                var word = results[i];
                AnsiConsole.MarkupLine($"[bold {color}]Found '{word.Word}'[/] at positions: " +
                    string.Join(", ", word.Positions.Select(p => $"({p.Row},{p.Col})")));
            }
            AnsiConsole.WriteLine();

            // List not found words (if there are any)
            var foundWords = results.Select(r => r.Word).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var notFoundWords = words.Where(w => !foundWords.Contains(w)).ToList();

            if (notFoundWords.Count > 0)
            {
                AnsiConsole.MarkupLine("[bold red]Words not found:[/]");
                foreach (var missing in notFoundWords)
                {
                    AnsiConsole.MarkupLine($"[grey]{missing}[/]");
                }
            }
        }
    }
}