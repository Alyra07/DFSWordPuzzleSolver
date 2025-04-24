using Models;

namespace Algorithm;

// This class implements a depth-first search (DFS) algorithm to find words in a grid puzzle
public class DfsSolver
{
    // Directions for searching in 8 possible ways (N, NE, E, SE, S, SW, W, NW)
    private static readonly int[] RowDirs = { -1, -1, -1, 0, 0, 1, 1, 1 };
    private static readonly int[] ColDirs = { -1, 0, 1, -1, 1, -1, 0, 1 };

    // Method to find words in the puzzle grid (takes Puzzle object and list of words.txt as input)
    public List<WordResult> FindWords(Puzzle puzzle, List<string> words)
    {
        var results = new List<WordResult>();

        foreach (var word in words)
        {
            for (int row = 0; row < puzzle.Rows; row++)
            {
                for (int col = 0; col < puzzle.Columns; col++)
                {
                    if (puzzle.Grid[row, col] == word[0])
                    {
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

    // Method to search for a word in the grid starting from a specific position (row, col)
    private bool SearchWord(Puzzle puzzle, string word, int row, int col, out List<Position> positions)
    {
        positions = new List<Position>();

        for (int dir = 0; dir < 8; dir++)
        {
            var tempPositions = new List<Position>();
            int r = row, c = col;
            int idx;

            for (idx = 0; idx < word.Length; idx++)
            {
                if (r < 0 || r >= puzzle.Rows || c < 0 || c >= puzzle.Columns || puzzle.Grid[r, c] != word[idx])
                    break;

                tempPositions.Add(new Position(r, c));
                r += RowDirs[dir];
                c += ColDirs[dir];
            }

            if (idx == word.Length)
            {
                positions = tempPositions;
                return true;
            }
        }

        return false;
    }
}