using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEETonthePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void startUp(CellRow[] board) //Initialize the recursion and is the place where all the scores flow back to
    {
        List<int> moves = possMoves(board, -1, -999, 999, 5); //YOU ACTUALLY NEED THE MOVE THAT GETS YOU EVERYTHING
    }

    List<int> possMoves(CellRow[] board, int turn, int alpha, int beta, int depth) //Counts up the number of possible moves
    {
        int pvar = 0; //this is the comparative variable, the one that keeps getting altered by higher or lower variables
        if (turn == -1) //checks if min or max
        {
            pvar = -999; //ai must maximize
        }
        else
        {
            pvar = 999; //ai must minimize player moves
        }
        for (int y = 0; y < 8; /*I CHANGED X++ TO Y++*/ y++)
        { //these two parts just iterate through the entire board
            for (int x = 0; x < 8; x = x + 2)
            {
                if (y % 2 != 0) { x = 1; } //shorten run time slightly by jumping over blanks and adjusting for the awkwardness of rows
                if (turn == 1)
                {
                    if (getCell(board, x, y).getType() == 2) //the turn + this line check to see which piece will be analyzed and in what way they will be analyzed (if they're moving forward or backwards)
                    { //^ this is the player piece evaluation
                        for (int i = -1; i < 2; i = i + 2) //to check both potential moves, I have a for statement here to iterate through both and create two recursive loops
                        {
                            CellRow[] copy = copyCR(board); //= board; //make a copy of the board so the original board stays unaffected
                            if (validPlayerMove(getCell(copy, x, y), getCell(copy, x + i, y + 1), copy)) //basic idea is check to see if move is possible... 
                            {
                                getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                getCell(copy, x + i, y + 1).setType(2);
                                pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                beta = Mathf.Min(beta, pvar);
                                if (alpha >= beta) { break; }
                            }
                            else if (validKillComp(getCell(copy, x, y), getCell(copy, x + 2 * i, y + 2), copy)) //basic idea is check to see if move is possible... 
                            {
                                getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                getCell(copy, x + 2 * i, y + 2).setType(2);
                                pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                beta = Mathf.Min(beta, pvar);
                                if (alpha >= beta) { break; }
                            }
                        }
                    }
                    else if (getCell(board, x, y).getType() == 3) //this is for the player king evaluation
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            CellRow[] copy = board; //this is all the same idea as the last thing
                            if (i == 0) //This is what my life has come to
                            {
                                if (validPlayerMove(getCell(copy, x, y), getCell(copy, x - 1, y + 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 1, y + 1).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validPlayerKill(getCell(copy, x, y), getCell(copy, x - 2, y + 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 2, y + 2).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else if (i == 1)
                            {
                                if (validPlayerMove(getCell(copy, x, y), getCell(copy, x + 1, y + 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 1, y + 1).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validPlayerKill(getCell(copy, x, y), getCell(copy, x + 2, y + 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 2, y + 2).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else if (i == 2)
                            {
                                if (validPlayerMove(getCell(copy, x, y), getCell(copy, x - 1, y - 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 1, y - 1).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validPlayerKill(getCell(copy, x, y), getCell(copy, x - 2, y - 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 2, y - 2).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else
                            {
                                if (validPlayerMove(getCell(copy, x, y), getCell(copy, x + 1, y - 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 1, y - 1).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validPlayerKill(getCell(copy, x, y), getCell(copy, x + 2, y - 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 2, y - 2).setType(3);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    beta = Mathf.Min(beta, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                        }
                    }
                }
                else //THE AI BORDER WALL YEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEET
                {
                    if (getCell(board, x, y).getType() == 4) //AI piece
                    {
                        for (int i = -1; i < 2; i = i + 2) //to check both potential moves, I have a for statement here to iterate through both and create two recursive loops
                        {
                            CellRow[] copy = copyCR(board); //= board; //make a copy of the board so the original board stays unaffected
                            if (validMoveComp(getCell(copy, x, y), getCell(copy, x + i, y - 1), copy)) //basic idea is check to see if move is possible... 
                            {
                                getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                getCell(copy, x + i, y - 1).setType(4);
                                pvar = Mathf.Max(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                alpha = Mathf.Max(alpha, pvar);
                                if (alpha >= beta) { break; }
                            }
                            else if (validKillComp(getCell(copy, x, y), getCell(copy, x + 2 * i, y - 2), copy)) //basic idea is check to see if move is possible... 
                            {
                                getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                getCell(copy, x + 2 * i, y - 2).setType(4);
                                pvar = Mathf.Max(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                alpha = Mathf.Max(alpha, pvar);
                                if (alpha >= beta) { break; }
                            }
                        }
                    }
                    else if (getCell(board, x, y).getType() == 5) //AI king
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            CellRow[] copy = board; //this is all the same idea as the last thing
                            if (i == 0) //This is what my life has come to
                            {
                                if (validMoveComp(getCell(copy, x, y), getCell(copy, x - 1, y + 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 1, y + 1).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validKillComp(getCell(copy, x, y), getCell(copy, x - 2, y + 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 2, y + 2).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else if (i == 1)
                            {
                                if (validMoveComp(getCell(copy, x, y), getCell(copy, x + 1, y + 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 1, y + 1).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validKillComp(getCell(copy, x, y), getCell(copy, x + 2, y + 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 2, y + 2).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else if (i == 2)
                            {
                                if (validMoveComp(getCell(copy, x, y), getCell(copy, x - 1, y - 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 1, y - 1).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validKillComp(getCell(copy, x, y), getCell(copy, x - 2, y - 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x - 2, y - 2).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                            else
                            {
                                if (validMoveComp(getCell(copy, x, y), getCell(copy, x + 1, y - 1), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 1, y - 1).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                                else if (validKillComp(getCell(copy, x, y), getCell(copy, x + 2, y - 2), copy)) //basic idea is check to see if move is possible... 
                                {
                                    getCell(copy, x, y).setType(1); //and then alter the board accordingly...
                                    getCell(copy, x + 2, y - 2).setType(5);
                                    pvar = Mathf.Min(pvar, aiShit(copy, turn) + possMoves(copy, -turn, 5)); //and run the recursion and board evaluation 
                                    alpha = Mathf.Min(alpha, pvar);
                                    if (alpha >= beta) { break; }
                                }
                            }
                        }
                    }
                }
            }
        }
        //below only bc 'not all code paths return a value, added by Aarushi
        return null;
    }
    //yeet
    CellRow[] copyCR(CellRow[] ogboard)
    {
        CellRow[] copy = new CellRow[8];
        for (int l = 0; l < 7; l++)
        {
            CellRow ori = ogboard[l];
            CellRow currentCR = copy[l];
            for (int k = 0; k < 7; k++)
            {
                Cell toCopy = ori.getCell(k);
                int toCopyType = toCopy.getType();
                Cell hi = new Cell(toCopyType, l, k);
                copy[k] = hi;
            }
        }
        return copy;
    }

    Cell getCell(CellRow[] board, int x, int y) //maybe unnecessary depending on whether we use cells or int[][]
    {
        return board[y].getCell(x);
    }

   
    int aiShit(int[,] board) //this is the board evaluation that you can try to implement but I have an idea I thinks
    {
        int score = 0;
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x = x + 2) 
            {
                if (y % 2 != 0) { x = 1; }
                Cell eval = getCell(board, x, y); // This is the basis for the scoring algorithm
                if (eval.getType() == 2) //Player piece, since this is the AI's perspective points will be deducted
                {
                    score -= 1000; //points for existing
                    if (x == 0 || x == 7) //points for the safe wall position
                    {
                        score -= 300; 
                    }
                    if (y > 2) //points for moving farther up
                    {
                        score -= 100 * (y - 2);
                    }
                    if (validPlayerKill(eval, getCell(board, x - 1, y + 1), board)) //points if can kill by moving leftward
                    {
                        score -= 2000; //points for the kill
                        if (x == 1) //point bonus for moving to the wall
                        {
                            score -= 300;
                        }
                    }
                    if (validPlayerKill(eval, getCell(board, x + 1, y + 1), board)) //points if can kill by moving rightward
                    {
                        score -= 2000; //points for the kill
                        if (x == 6) //point bonus for moving to the wall
                        {
                            score -= 300;
                        }
                    }
                }
                else if (getCell(board, x, y).getType() == 3) //player king
                {
                    score -= 1500;
                }
                else if (getCell(board, x, y).getType() == 4) //AI piece, points will be added
                {
                    score += 1000;
                }
                else if (getCell(board, x, y).getType() == 5) //AI king
                {
                    score += 1500;
                }
            }
        }
        return 1;
    }

    public bool validKillCompComp(Cell cell1, Cell cell2, CellRow[] board)
    {
        //for reg piece
        if (cell1.getType() == 4)
        {
            if (cell2.getType() == 1)
            {
                //for single jump
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 2) && (cell1.getRow() - cell2.getRow() == 2))
                {
                    CellRow cr = board[cell1.getRow() - 1];
                    Cell c;
                    if (cell2.getCol() - cell1.getCol() == 2)
                    {
                        c = cr.getCell(cell1.getCol() + 1);
                    }
                    else
                    {
                        c = cr.getCell(cell1.getCol() - 1);
                    }
                    if (c.getType() == 2 || c.getType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        if (cell1.getType() == 5)
        {
            if (cell2.getType() == 1)
            {
                //for single jump
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 2) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 2))
                {
                    Cell c;
                    CellRow cr;
                    if (cell2.getRow() - cell1.getRow() == 2)
                    {
                        cr = board[cell1.getRow() + 1];
                    }
                    else
                    {
                        cr = board[cell1.getRow() - 1];
                    }
                    if (cell2.getCol() - cell1.getCol() == 2)
                    {
                        c = cr.getCell(cell1.getCol() + 1);
                    }
                    else
                    {
                        c = cr.getCell(cell1.getCol() - 1);
                    }
                    if (c.getType() == 2 || c.getType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool validMoveComp(Cell cell1, Cell cell2, CellRow[] board)
    {
        //for reg piece
        if (cell1.getType() == 4)
        {
            if (cell2.getType() == 1)
            {
                //for movement
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 1) && (cell1.getRow() - cell2.getRow() == 1))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        if (cell1.getType() == 5)
        {
            if (cell2.getType() == 1)
            {
                //for movement
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 1) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 1))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    public bool validPlayerKill(Cell cell1, Cell cell2, CellRow[] board)
    {
        //for reg piece
        if (cell1.getType() == 2)
        {
            if (cell2.getType() == 1)
            {
            //for single jump
            else if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 2) && (cell2.getRow() - cell1.getRow() == 2))
                {
                    CellRow cr = board[cell1.getRow() + 1];
                    Cell c;
                    if (cell2.getCol() - cell1.getCol() == 2)
                    {
                        c = cr.getCell(cell1.getCol() + 1);
                    }
                    else
                    {
                        c = cr.getCell(cell1.getCol() - 1);
                    }
                    if (c.getType() == 4 || c.getType() == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        if (cell1.getType() == 3)
        {
            if (cell2.getType() == 1)
            {
            //for single jump
            else if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 2) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 2))
                {
                    CellRow cr = board[cell1.getRow() + 1];
                    Cell c;
                    if (cell2.getCol() - cell1.getCol() == 2)
                    {
                        c = cr.getCell(cell1.getCol() + 1);
                    }
                    else
                    {
                        c = cr.getCell(cell1.getCol() - 1);
                    }
                    if (c.getType() == 4 || c.getType() == 5)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool validPlayerMove(Cell cell1, Cell cell2, CellRow[] board)
    {
        //for reg piece
        if (cell1.getType() == 2)
        {
            if (cell2.getType() == 1)
            {
                //for movement
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 1) && (cell2.getRow() - cell1.getRow() == 1))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        if (cell1.getType() == 3)
        {
            if (cell2.getType() == 1)
            {
                //for movement
                if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 1) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 1))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        //DELETE LINE BELOEW LATER
        return false;
    }

}