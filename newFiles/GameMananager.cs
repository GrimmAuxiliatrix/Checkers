using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananager : MonoBehaviour {

	public CellRow[] board = new CellRow[8];

	public Material[] materials = new Material[4];

	public Cell cell1, cell2;

	bool needed = true; //IMPORTANT:: need to set this to true again at start of player turn

	// Use this for initialization
	void Start () {
		int turn = 1;
		int FIN = 0;
		if(needed == false) { //update will make needed false when both cell1 and cell2 have values and that the move is valid
			updateMove(cell1, cell2, board);
			cell1 = null;
			cell2 = null;
			codeToGUI(board);
			turn *= -1;
			Debug.Log ("Gauntlet Completed");
		}
		/* while (FIN == 0)
        {
            if (turn == 1)
            {
                needed = true;
                bool checkValid = false;
                bool hey = true;
                while (hey)
                {
                    if (needed == false)
                    {
                        updateMove(cell1, cell2, board);
                        cell1 = null;
                        cell2 = null;
                        codeToGUI(board);
                        hey = false;
                        turn *= -1;
                    }
                }            
            }
            if (turn == -1)
            {
                //call AI
            }
            FIN = checkWin(board);            
        }
		*/
		codeToGUI(board);
		int[,] hello = makeItEasy(board);    
	}

	// Update is called once per frame
	void Update()
	{
		if (needed) {
			if (cell1 == null)
			{
				cell1 = helpMe();
				if (cell1 != null) {
					Debug.Log ("Cell1 is filled");
				}
			}
			else if (cell2 == null)
			{
				cell2 = helpMe();
				if (cell2 != null) {
					Debug.Log ("Cell2 is filled");
				}
			}
			if (cell1 != null && cell2 != null)
			{
				if (validMove(cell1, cell2, board))
				{
					needed = false;
					Debug.Log ("cell1 and cell2 have been filled");
					Start ();
				}
			}
		}
		//need to set needed = true start of player turn
	}

	public Cell helpMe ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("SendJesusPart0");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				if (hit.transform != null)
				{
					//Debug.Log("SendJesus1");
					if (hit.transform.GetComponent<Collider>().gameObject.CompareTag("hi"))
					{
						//Debug.Log("SendJesus");
						Cell c = hit.transform.gameObject.GetComponent<Cell>();
						return c;
					}
				}
			}
		}
		return null;
	}


	public bool validMove(Cell cell1, Cell cell2, CellRow[] board){
		//for reg piece
		if (cell1.getType() == 2)
		{
			if (cell2.getType() == 1) {
				//for movement
				if ((Mathf.Abs(cell2.getCol()-cell1.getCol() )==1) && (cell2.getRow() - cell1.getRow () == 1)){
					return true;
				}
				//for single jump
				else if ((Mathf.Abs(cell2.getCol()-cell1.getCol())==2) && (cell2.getRow() - cell1.getRow () == 2)) {
					CellRow cr = board[cell1.getRow ()+1];
					Cell c;
					if (cell2.getCol()-cell1.getCol() == 2) {
						c = cr.getCell (cell1.getCol() +1);
					}
					else {
						c = cr.getCell (cell1.getCol() -1);
					}
					if (c.getType() == 4 || c.getType() == 5) {
						return true;
					}
					else {
						return false;
					}
				}
				return false;
			}
			else {
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

	public void codeToGUI (CellRow[] board)
	{
		for(int i = 0; i < 8; i++)
		{
			CellRow cr = board[i];
			for(int k = 0; k < 8; k++)
			{
				Cell c = cr.getCell(k);
				int cellType = c.getType();
				switch (cellType)
				{
				case 1:
					c.transform.GetChild(0).gameObject.SetActive(false);
					break;
				case 2:
					c.transform.GetChild(0).gameObject.SetActive(true);
					c.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materials[0];
					break;
				case 3:
					c.transform.GetChild(0).gameObject.SetActive(true);
					c.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materials[1];
					break;
				case 4:
					c.transform.GetChild(0).gameObject.SetActive(true);
					c.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materials[2];
					break;
				case 5:
					c.transform.GetChild(0).gameObject.SetActive(true);
					c.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = materials[3];
					break;
				}
			}

		}
	}

	public void crownMeBitch (CellRow[] board)
	{
		CellRow cr0 = board[0];
		CellRow cr7 = board[7];
		for (int i = 0; i < 7; i++)
		{
			if(cr0.getCell(i).getType() == 4)
			{
				cr0.getCell(i).setType(5);
			}
		}
		for (int i = 0; i < 7; i++)
		{
			if (cr7.getCell(i).getType() == 2)
			{
				cr7.getCell(i).setType(3);
			}
		}
	}

	public int[,] makeItEasy(CellRow[] board)
	{
		int[,] intBoard = new int[8,8];
		for (int i = 0; i < 8; i++)
		{
			CellRow cr = board[i];
			for (int k = 0; k < 8; k++)
			{
				Cell c = cr.getCell(k);
				intBoard[i,k] = c.getType();
			}
		}
		return intBoard;
	}

	public int checkWin (CellRow[] board)
	{
		int [,] weNeedJesus = makeItEasy(board);
		int countP = 0;
		int countC = 0;
		for (int i = 0; i < 7; i++)
		{
			for (int k = 0; k < 7; k++)
			{
				if (weNeedJesus[i, k] == 2 || weNeedJesus[i, k] == 3)
				{
					countP++;
				}
				else if (weNeedJesus[i, k] == 3 || weNeedJesus[i, k] == 4)
				{
					countC++;
				}
			}
			if (countP == 0)
			{
				return -1;
			}
			else if (countC == 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		return 0;
	}

	public void updateMove(Cell cell1, Cell cell2, CellRow[] board)
	{
		if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 2) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 2))
		{
			CellRow cr = board[cell1.getRow() + 1];
			Cell c;
			if (cell2.getCol() - cell1.getCol() == 2)
			{
				cell2.setType(cell1.getType());
				cell1.setType(1);
				cr.getCell(cell1.getCol() + 1).setType(1);
			}
			else
			{
				cell2.setType(cell1.getType());
				cell1.setType(1);
				cr.getCell(cell1.getCol() - 1).setType(1);
			}

		}
		else
		{
			if ((Mathf.Abs(cell2.getCol() - cell1.getCol()) == 1) && (Mathf.Abs(cell2.getRow() - cell1.getRow()) == 1))
			{
				cell2.setType(cell1.getType());
				cell1.setType(1);
			}
		}
	}
}



