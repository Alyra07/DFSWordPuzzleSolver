using Models;

namespace Algorithm;

// This class implements a depth-first search (DFS) algorithm to find words in a grid puzzle
public class DfsSolver
{
    // Directions for searching in 8 possible ways (N, NE, E, SE, S, SW, W, NW)
    private static readonly int[] RowDirs = { -1, -1, -1, 0, 0, 1, 1, 1 };
    private static readonly int[] ColDirs = { -1, 0, 1, -1, 1, -1, 0, 1 };

    // Main method to find words in the puzzle grid
    public List<WordResult> FindWords(Puzzle puzzle, List<string> words)
    {
        var results = new List<WordResult>(); // List to store found words & their positions

        // iterate through each word from words.txt
        foreach (var word in words)
        {
            // check every cell in the grid as potential starting point of the word
            for (int row = 0; row < puzzle.Rows; row++)
            {
                for (int col = 0; col < puzzle.Columns; col++)
                {
                    // if first character matches, start searching for the word
                    if (puzzle.Grid[row, col] == word[0])
                    {
                        // run DFS to check if word can be formed starting from this cell
                        if (SearchWord(puzzle, word, row, col, out var positions))
                        {
                            results.Add(new WordResult { Word = word, Positions = positions });
                        }
                    }
                }
            }
        }

        return results;
    }

    // Helper method to search for a word in the grid starting from the specific cell
    private bool SearchWord(Puzzle puzzle, string word, int row, int col, out List<Position> positions)
    {
        positions = new List<Position>(); // positions of the word in the grid

        // search in all 8 directions - for each direction, check if the word can be formed
        for (int dir = 0; dir < 8; dir++)
        {
            var tempPositions = new List<Position>(); // store positions for current direction
            int r = row, c = col; // start search from the given position
            int idx; // index to track current character in the word

            // Check if the word can be formed in the current direction
            for (idx = 0; idx < word.Length; idx++)
            {
                // check if current position is within bounds + matches the current character
                if (r < 0 || r >= puzzle.Rows || c < 0 || c >= puzzle.Columns || puzzle.Grid[r, c] != word[idx])
                    break; // if not, break out of the loop

                // add the current position to the temporary list
                tempPositions.Add(new Position(r, c));
                // move to next row / col in the current direction
                r += RowDirs[dir];
                c += ColDirs[dir];
            }

            // if the entire word is found, return its positions
            if (idx == word.Length)
            {
                positions = tempPositions;
                return true;
            }
        }
        // if the word is not found in any direction, return false
        return false;
    }
}