namespace Models;

// This class represents a position in a 2D grid with row & column indices
public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    // Constructor to initialize the position with given row / column indices
    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }
}