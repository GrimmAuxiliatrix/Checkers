﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRow : MonoBehaviour {

	public Cell[] CellR = new Cell[8];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Cell getCell(int ind){
		return CellR [ind];
	}
}
