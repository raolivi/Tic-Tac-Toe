﻿Console.WriteLine("Welcome to Tic-Tac-Toe!");
Console.WriteLine();

//Prompts 1st player to enter what symbol they want to use
string P1S;
Console.Write("Please enter a symbol for Player 1: ");
P1S = Console.ReadLine();

//Prompts 2nd player to enter what symbol they want to use
string P2S;
Console.Write("Please enter a symbol for player 2: ");
P2S = Console.ReadLine();
Console.WriteLine("--------------------------------------");

string[,] board = new string[3, 3];

//Sets the board to fill with "*"
for (int i = 0; i < board.GetLength(0); i++)
{
    for (int j = 0; j < board.GetLength(1); j++)
    {
        board[i, j] = "*";
    }
}

bool user = true;

int turns = 0;

//Asks players to enter coordinates and validates what they put
//Checks and displays if a player won of if there was a draw
do
{
    drawBoard(board);

    Console.WriteLine();
    Console.WriteLine("Player 1's turn: ");

    int x_coord;
    Console.Write("Enter an x: "); //Prompts player 1 for an x coordinate
    x_coord = int.Parse(Console.ReadLine());

    //Validates that the number entered was greater than 0 and less than or equal to 2
    if (x_coord > 2 || x_coord < 0)
    {
        Console.WriteLine();
        Console.Write("Error. Please re-enter: ");
        x_coord = int.Parse(Console.ReadLine());
        Console.WriteLine();
    }

    int y_coord;
    Console.Write("Enter a y: "); //Prompts player 1 for a y coordinate
    y_coord = int.Parse(Console.ReadLine());

    //Validates that the number entered was greater than 0 and less than or equal to 2
    if (y_coord > 2 || y_coord < 0)
    {
        Console.WriteLine();
        Console.Write("Error. Please re-enter: ");
        y_coord = int.Parse(Console.ReadLine());
    }

    //Checks if the coordintaes entered are already full
    if (board[x_coord, y_coord] != "*")
    {
        Console.WriteLine();
        Console.Write("Error. Please re-enter an x: ");
        x_coord = int.Parse(Console.ReadLine());

        Console.Write("Now re-enter a y: ");
        y_coord = int.Parse(Console.ReadLine());
    }

    placeMarker(board, P1S, x_coord, y_coord); //Puts marker in coordinates entered
    Console.WriteLine("------------------");

    turns += 1;

    int Win = winCheck(board); //Checks for a win or draw

    if (Win == 3) //Says what to do display if conditions for return 3 in the WinCheck part are met
    {
        drawBoard(board);
        Console.WriteLine("------------------");
        Console.WriteLine("Draw!");
        user = false;
    }
    else if (Win == 1) //same as above but for return 1
    {
        drawBoard(board);
        Console.WriteLine("------------------");
        Console.WriteLine("Player 1 Wins!");
        user = false;
    }
    else
    {
        drawBoard(board);

        Console.WriteLine();
        Console.WriteLine("Player 2's turn: ");

        Console.Write("Enter an x: "); //Prompts player 2 to enter an x coordinate
        x_coord = int.Parse(Console.ReadLine());

        //Validates that the number entered was greater than 0 and less than or equal to 2
        if (x_coord > 2 || x_coord < 0)
        {
            Console.WriteLine();
            Console.Write("Error. Please re-enter: ");
            x_coord = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        Console.Write("Enter a y: ");
        y_coord = int.Parse(Console.ReadLine());


        //Validates that the number entered was greater than 0 and less than or equal to 2
        if (y_coord > 2 || y_coord < 0)
        {
            Console.WriteLine();
            Console.Write("Error. Please re-enter: ");
            y_coord = int.Parse(Console.ReadLine());
        }

        //Checks if the coordintaes entered are already full
        if (board[x_coord, y_coord] != "*")
        {
            Console.WriteLine();
            Console.Write("Error. Please re-enter an x: ");
            x_coord = int.Parse(Console.ReadLine());

            Console.Write("Now re-enter a y: ");
            y_coord = int.Parse(Console.ReadLine());
        }

        placeMarker(board, P2S, x_coord, y_coord); //Puts marker in coordinates entered

        Console.WriteLine("------------------");

        turns += 1;

        Win = winCheck(board); //Checks board for win

        if (Win == 2) //Says what to do display if conditions for return 2 in the WinCheck part are met
        {
            drawBoard(board);
            Console.WriteLine("------------------");
            Console.WriteLine("Player 2 Wins!");
            user = false;
        }

    }


} while (user); //end do 


//Creates the board
void drawBoard(string[,] board)
{

    Console.WriteLine("    0   1   2   ");
    Console.WriteLine("   -----------");
    Console.WriteLine("0 | {0} | {1} | {2} |", board[0, 0], board[1, 0], board[2, 0]);
    Console.WriteLine("   -----------");
    Console.WriteLine("1 | {0} | {1} | {2} |", board[0, 1], board[1, 1], board[2, 1]);
    Console.WriteLine("   -----------");
    Console.WriteLine("2 | {0} | {1} | {2} |", board[0, 2], board[1, 2], board[2, 2]);
    Console.WriteLine("   -----------");


}

//Holds marker in place
void placeMarker(string[,] board, string marker, int x_coord, int y_coord)
{
    board[x_coord, y_coord] = marker;

    if (board[x_coord, y_coord] == "*")
    {
        board[x_coord, y_coord] = marker;
    }
    else if (board[x_coord, y_coord] == "^")
    {
        board[x_coord, y_coord] = marker;
    }

}

//Says what circumstances to check for to see if a player won or if there was a draw 
int winCheck(string[,] board)
{
    if (board[0, 0] == P1S && board[0, 1] == P1S && board[0, 2] == P1S || board[1, 0] == P1S && board[1, 1] == P1S && board[1, 2] == P1S || board[2, 0] == P1S && board[2, 1] == P1S && board[2, 2] == P1S)
    {
        return 1;
    }
    else if (board[0, 0] == P2S && board[0, 1] == P2S && board[0, 2] == P2S || board[1, 0] == P2S && board[1, 1] == P2S && board[1, 2] == P2S || board[2, 0] == P2S && board[2, 1] == P2S && board[2, 2] == P2S)
    {
        return 2;
    }
    else if (board[0, 0] == P1S && board[1, 0] == P1S && board[2, 0] == P1S || board[0, 1] == P1S && board[1, 1] == P1S && board[2, 1] == P1S || board[0, 2] == P1S && board[1, 2] == P1S && board[2, 2] == P1S)
    {
        return 1;
    }
    else if (board[0, 0] == P2S && board[1, 0] == P2S && board[2, 0] == P2S || board[0, 1] == P2S && board[1, 1] == P2S && board[2, 1] == P2S || board[0, 2] == P2S && board[1, 2] == P2S && board[2, 2] == P2S)
    {
        return 2;
    }
    else if (board[0, 0] == P1S && board[1, 1] == P1S && board[2, 2] == P1S)
    {
        return 1;
    }
    else if (board[0, 0] == P2S && board[1, 1] == P2S && board[2, 2] == P2S)
    {
        return 2;
    }
    else if (board[2, 0] == P1S && board[1, 1] == P1S && board[0, 2] == P1S)
    {
        return 1;
    }
    else if (board[2, 0] == P2S && board[1, 1] == P2S && board[0, 2] == P2S)
    {
        return 2;
    }
    else if (turns == 9)
    {
        return 3;
    }
    else
    {
        return -1;
    }
}

