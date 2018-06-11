using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public int type;
	public int row;
	public int col;

    public Cell (int t, int r, int c)
    {
        type = t;
        row = r;
        col = c;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getRow(){
		return row;
	}

	public int getCol(){
		return col;
	}

	public int getType(){
		return type;
	}

    public void setType(int ty)
    {
        type = ty;
    }
}
