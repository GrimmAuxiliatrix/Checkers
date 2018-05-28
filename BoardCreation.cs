using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour {
	public GameObject[,] tileList = new GameObject[8, 8]; //Contains the tile objects. Indices corresponds to their positions on the board.
	public GameObject gTile; //green prefab
	public GameObject pTile; //pink prefab

	float x_int = 1.5f; //x distance between tiles
	float y_int = 1.5f; //y distance between tiles
	//Note: I might have switched them. They're the same number right now so it doesn't matter yet.

	public GameObject[] redList = new GameObject[12];
	public GameObject rPiece;
	public GameObject[] blackList = new GameObject[12]; //Heh.... blacklist....
	public GameObject bPiece;


	void Start () {
		BoardGen ();
		BoardFill();
	}

	void BoardGen(){ //iterates through tileList to fill it and arrange the tiles
		
		for (int i = 0; i < 8; i++) {
			for (int k = 0; k < 8; k++) {
				
				if ((i%2==0 && k%2==0) || (i%2!=0 && k%2!=0)) { //decides whether to use green or pink tile based on position
					//i.e. green tile is used when the indices are both even or both odd
					tileList [i, k] = Instantiate (gTile);
					tileList [i, k].transform.position = new Vector2 (i * x_int, k * y_int);
				} 
				else {
					tileList [i, k] = Instantiate (pTile);
					tileList [i, k].transform.position = new Vector2 (i * x_int, k * y_int);
				}
					
			}
		}
	}

	void BoardFill(){ //This is some delirious biznasty
		int r= 0;
		int b = 0;
		int i = 0;

		for(int k= 0; k<3; k++){
			if (k % 2 == 0) {
				i = 1;
			} else {
				i = 0;
			}
			while(i<8){
				redList[r] = Instantiate(rPiece, tileList[i,k].transform.position, tileList[i,k].transform.rotation);
				r++;
				i += 2;
			}
		}

		for(int k= 7; k>4; k--){
			if (k % 2 == 0) {
				i = 1;
			} else {
				i = 0;
			}
			while(i<8){
				blackList[b] = Instantiate(bPiece, tileList[i,k].transform.position, tileList[i,k].transform.rotation);
				b++;
				i += 2;
			}
		}


	}
}
