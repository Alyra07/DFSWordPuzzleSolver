## About The Project
**WordPuzzleSolver** is a console-based application built in Visual Studio Code that uses a Depth-First Search (DFS) algorithm to find words in a grid of characters. The project is implemented in C# and demonstrates object-oriented programming principles such as abstraction and generics. It also uses the Spectre.Console library for a visually appealing console output.

## Getting Started

### Prerequisites
To run the project, you need the following:
- .NET 6.0 SDK or later
- A code editor such as Visual Studio Code or Visual Studio
- Basic knowledge of how to use the terminal/command prompt

### Installation
1. Download and unzip the project or clone the GitHub repository to your local machine.
2. Navigate to the project directory `DFSWordPuzzleSolver` and restore required dependencies:
   ```bash
   dotnet restore
### Usage
1. Prepare your input files in the `App/Data` folder (example files are already provided there):
   - `words.txt`: A list of words to search for in the grid - Each word should be placed in its own row.
   - `grid.txt`: A grid of characters where your words will be searched - Each row should have the same number of characters.
2. Navigate to the `App` directory in your terminal and run the console application:
   ```bash
   dotnet run
3. Example Output:
   - The grid with found words highlighted in different colors
   - A list of found words with their positions
   - A list of words that were not found (if any)

## Roadmap 
- Implemented a **Depth-First Search (DFS)** algorithm to find words in a grid
- Used **Spectre.Console** for visually appealing console output
- Organized the project into modular components
- See [report.md](report.md#methodology) for more information...

## License 
This project is licensed under the MIT License.

## Contact
**Mirjam McLachlan** \
E-Mail: cc231033@fhstp.ac.at