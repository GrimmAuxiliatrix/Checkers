using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {

	public GameObject selectedpiece; //the piece that moves

	/*
	 1 : Black Man
	 2 : Black King
	 0 : Empty
	 3 : Red Man
	 4 : Red King
	*/

	int[,] board = new[,]{
		{1,0,1,0,1,0,1,0},
		{0,1,0,1,0,1,0,1},
		{1,0,1,0,1,0,1,0},
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0},
		{0,3,0,3,0,3,0,3},
		{3,0,3,0,3,0,3,0},
		{0,3,0,3,0,3,0,3}
	};

	private Vector3 screenPoint;
	private Vector3 offset;

	// this is for dragging
	void OnMouseDown(){
		selectedpiece = this.gameObject;
		int pieceX = (int) ((selectedpiece.transform.position.x / 1.5) - 1);
		int pieceY = (int)((selectedpiece.transform.position.x / 1.5) - 1);

		if (board [pieceX, pieceY] <= 2) {
		}

		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}
	// this is for dragging

	private bool CanMove(int posX, int posY, int targetX, int targetY) { // tests whether a move is valid or not
		int pieceType = board [posX, posY]; // returns the type of piece that's being selected in int form

		if (board [targetX, targetY] != 0) { // checks that the target location is empty
			return false;
		} else if ((pieceType == 2) || (pieceType == 4)) { // Kings can have negative and positive change in y position
			if ((Mathf.Abs (targetX - posX)) != 1 || Mathf.Abs (targetY - posY) != 1) { 
				return false; // checks that the target location is two spots away diagonally in any direction
			}
		} else if (pieceType == 1) { // 1 means black man, so the y coordinate change can only be negative(black men can only move downwards)
			if ((Mathf.Abs (targetX - posX)) != 1 || (targetY - posY != -1)) { 
				return false; // checks that the target location is two spots away downward
			}
		} else if (pieceType == 3) { // 3 means red man, so the y coordinate change can only be positive(red men can only move upwards)
			if ((Mathf.Abs (targetX - posX)) != 1 || (targetY - posY != 1)) {
				return false; // checks that the target location is two spots away upward
			}
		} 
		return true;
	}
	private bool CanCapture(int posX, int posY, int targetX, int targetY) {
		int pieceType = board [posX, posY];
		int victimPiece = board [((posX + targetX) / 2), ((posY + targetY) / 2)];

		if (CanMove (posX, posY, targetX, targetY) == true) { // CanMove will detect whether a piece is blocking a capture
			return false;
		} else if (victimPiece != 0) { // checking that you're not marking jumping over a empty spot as a kill; for use on UI
			return false;
		}
		else if (pieceType >= 3 && (victimPiece >= 3)) {
			return false; // checks that the selected piece and the potential capture are not both red
		} else if (pieceType <= 2 && (victimPiece <= 2)) {
			return false; // ditto, but this time for black
		} 
		//repeat of CanMove, this time testing a jump taking two spaces instead of one (a kill)
		else if ((pieceType == 2) || (pieceType == 4)) { // Kings can have negative and positive change in y position
			if ((Mathf.Abs (targetX - posX)) != 2 || Mathf.Abs (targetY - posY) != 2) { 
				return false; // checks that the target location is two spots away diagonally in any direction
			}
		} else if (pieceType == 1) { // 1 means black man, so the y coordinate change can only be negative(black men can only move downwards)
			if ((Mathf.Abs (targetX - posX)) != 2 || (targetY - posY != -2)) { 
				return false; // checks that the target location is two spots away downward
			}
		} else if (pieceType == 3) { // 3 means red man, so the y coordinate change can only be positive(red men can only move upwards)
			if ((Mathf.Abs (targetX - posX)) != 2 || (targetY - posY != 2)) {
				return false; // checks that the target location is two spots away upward
			}
		} 
		return true;
	}
	public void Move(int posX, int posY, int targetX, int targetY) {
		if (CanMove(posX,posY,targetX,targetY) == true && CanCapture(posX,posY,targetX,targetY) == true) {
			//wtffff
		}
	}
}
