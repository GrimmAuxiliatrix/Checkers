using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMax : MonoBehaviour {
	//Don't know what fields variables or whatever we will need from other classes
	List<int> evalList = new List<int>;

	// Use this for initialization
	void Start () {
		//don't know how this will be used tbh
	}
	
	// Update is called once per frame
	void Update () {
		//foreach(piece with possible moves){
			//int eval = 0;
			//int i = 0
			//while(there are pieces on either side imagined){
				//if(i%2 == 0){maxEval; i ++}
				//else{minEval; i++}
			//if(no imagined pieces left){list.add(eval)}
		//int[] arrayEval = evalList.ToArray();
		//pick the highest value from array as the move


	}

	//enemy become king evaluation
	//enemy take pieces evaluation
	int minEval(){
		//if(enemy can take a piece){recurse method canTakePiece*-1}
		//elif(enemy can turn into king){ eval -=75}
		//else{eval stays same go to max val in update method}
	}

	//ai become king evaluation
	//ai take pieces evaluation
	int maxEval(){
		//if(ai can take a piece){recurse method canTakePiece}
		//elif(ai can turn into king){ eval +=75}
		//else{eval stays same go to min val in update method}
	}

	//void canTakePiece(Gameobject board[,] , whose turn)
		//if(possibleMove == True && jumpOver ==true)
			//{if(piece == king){
			//eval += 150}
			//else{ eval+= 100}
		//else{do nothing then}
}
