int r= 0;
int b = 0;

for(int k= 0; k<3; k++){
	for(int i=0; i<8; i++){
		if(tileList[i,k] == pTile){
			redList[r] = Instantiate(redPiece, tileList[i,k].Transform);
			r++;
		}
	}
}

for(int k= 7; k>4; k--){
	for(int i=0; i<8; i++){
		if(tileList[i,k] == pTile){
			blackList[b] = Instantiate(blackPiece, tileList[i,k].Transform);
			b++;
		}
	}
}