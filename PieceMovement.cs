using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {

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

	private bool CanMove(int posX, int posY, int targetX, int targetY) {
		int pieceType = board [posX, posY]; // returns the type of piece that's being targeted in int form

		if (board [targetX, targetY] != 0) { // checks that the target location is empty
			return false;
		} else if ((pieceType == 2) || (pieceType == 4)) { // Kings can have negative and position change in y position
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
}
