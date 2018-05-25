using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreation : MonoBehaviour {
	public GameObject[,] tileList = new GameObject[8, 8]; //Contains the tile objects. Indices corresponds to their positions on the board.
	public GameObject gTile; //green prefab
	public GameObject pTile; //pink prefab
	public Texture gTexture; //the original non-prefab version
	public Texture pTexture; //the original non-prefab version

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

	void BoardFill(){ //Arranges the pieces on the board and fills their respective arrays
		int r= 0;
		int b = 0;

		for(int k= 0; k<3; k++){
			for(int i=0; i<8; i++){
				//this part doesn't seem to be working
				if(tileList[i,k].GetComponent<SpriteRenderer>().sprite == pTexture){
					
					redList[r] = Instantiate(rPiece, tileList[i,k].transform);
					r++;
				}
			}
		}

		for(int k= 7; k>4; k--){
			for(int i=0; i<8; i++){
				//this part doesn't seem to be working
				if(tileList[i,k].GetComponent<SpriteRenderer>().sprite == gTexture){
					blackList[b] = Instantiate(bPiece, tileList[i,k].transform);
					b++;
				}
			}
		}


	}
}
