namespace Models

{
    // This class represents a grid of characters used in the puzzle
    public class Puzzle
    {
        // contains properties for the grid itself and its dimensions (rows & columns)
        public char[,] Grid { get; set; } = new char[0,0]; // default empty grid
        public int Rows => Grid.GetLength(0);
        public int Columns => Grid.GetLength(1);
    }
}