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

	private bool CanMove(int posX, int posY, int targetX, int targetY, bool isKing, bool PlayerSide) {
		if (board [targetX, targetY] != 0) { // checks that the target location is empty
			return false;
		} else if (isKing == true) { // Kings can have negative and position change in y position
			if ((Mathf.Abs (targetX - posX)) != 2 || Mathf.Abs (targetY - posY) != 2) { 
				return false; // checks that the target location is two spots away diagonally in any direction
			}
		} else if (isKing == false) { // Men can only have either positive or negative change in y position, depending on color
			if (PlayerSide == true) { // if PlayerSide == true then red man is in motion; so y coordinate can only increase
				if ((Mathf.Abs (targetX - posX)) != 2 || (targetY - posY != -2)) { 
					return false; // checks that the target location is two spots away upward
				}
			} else if (PlayerSide == false) { // if PlayerSide == false then black man is in motion; so y coordinate can only decrase
				if ((Mathf.Abs (targetX - posX)) != 2 || (targetY - posY != 2)) {
					return false; // checks that the target location is two spots away downward
				}
			}
		} 
		return true;
	}
}
