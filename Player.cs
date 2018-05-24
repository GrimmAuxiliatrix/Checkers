using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I honestly don't know if we even need this script but in this world it's yeet or get yeeted
public class Player : MonoBehaviour {
	GameObject[,] board; 
	GameObject selected; //piece that player selected

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//i and j in this method represent the x and y directions of the board dont really know whats the parameters that go here
	bool canMove(GameObject[i,j] board){
		if(i > 0 && i<8 && j > 0  && j< 8){
			if( 
	}
}
