public class PieceMovement : MonoBehaviour {

	public GameObject selectedpiece; // the piece that moves
	public GameObject selectedtile; // the tile that the piece will move to
	private GameObject pieceInTransition; // neccessary for pieces to move in OnMouseDown 

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

	// this is for moving
	void OnMouseDown(){
		bool pieceselected = false;
		int pieceX; int pieceY; int boardX; int boardY;
		if (this.gameObject.name == "Piece" && pieceselected == false) { // for selecting a piece
			pieceselected = true;
			pieceX = (int) ((selectedpiece.transform.position.x / 1.5) - 1);
			pieceY = (int) ((selectedpiece.transform.position.x / 1.5) - 1); // getting coordinates of piece when piece is selected
			pieceInTransition = this.gameObject;

		}
		else if(this.gameObject.name == "Board" && pieceselected == true) { // for picking a board spot to move after a piece is selected
			boardX = (int) ((selectedpiece.transform.position.x / 1.5) - 1);
			boardY = (int) ((selectedpiece.transform.position.x / 1.5) - 1); // getting coordinates of board when board is selected
			if (CanMove (pieceX, pieceY, boardX, boardY) == true && board [boardX, boardY] == 0) {
				board [boardX, boardY] = board [pieceX, pieceY]; //moves the piece to the targeted location
				board [pieceX, pieceY] = 0; //vacates the spot the moving piece once was
				//pieceInTransition.transform.position.x = selectedpiece.transform.position.x;
				//pieceInTransition.transform.position.y = selectedpiece.transform.position.y; //moves the actual piece to the valid spot
				Vector2 stupidcsharp = new Vector2Int (((int)selectedpiece.transform.position.x), ((int)selectedpiece.transform.position.y));
				pieceInTransition.transform = stupidcsharp;
			}
		}
	}
	private bool CanMove(int posX, int posY, int targetX, int targetY) { // tests whether a move is valid or not
		int pieceType = board [posX, posY]; // returns the type of piece that's being selected in int form

		if (board [targetX, targetY] != 0) { // checks that the target location is empty
			return false;
		} else if ((pieceType == 2) || (pieceType == 4)) { // Kings can have negative and positive change in y position
			if ((Mathf.Abs (targetX - posX)) != 1 || Mathf.Abs (targetY - posY) != 1) { 
				return false; // checks that the target location is one spot away diagonally in any direction
			}
		} else if (pieceType == 1) { // 1 means black man, so the y coordinate change can only be negative(black men can only move downwards)
			if ((Mathf.Abs (targetX - posX)) != 1 || (targetY - posY != -1)) { 
				return false; // checks that the target location is one spot away downward
			}
		} else if (pieceType == 3) { // 3 means red man, so the y coordinate change can only be positive(red men can only move upwards)
			if ((Mathf.Abs (targetX - posX)) != 1 || (targetY - posY != 1)) {
				return false; // checks that the target location is one spot away upward
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
	/*
	  	void OnMouseDown(){
			selectedpiece = this.gameObject;
			int pieceX = (int) ((selectedpiece.transform.position.x / 1.5) - 1);
			int pieceY = (int) ((selectedpiece.transform.position.x / 1.5) - 1);

			if (board [pieceX, pieceY] <= 2) {
			}
		}
		*/
}
