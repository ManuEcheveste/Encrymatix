using Godot;
using System;

public partial class DecodingTable : Node
{



	public float[,] encryptKey = new float[3,3]
	{
		{1,1,3},
		{-1,4,0},
		{3,0,6}
	};
	
	public float[,] decryptKey = new float[3,3] //to be changed
	{
		{1,1,3},
		{-1,4,0},
		{3,0,6}
	};
	
	public float[,] currentMat = null;
	
	public int currentIndexMat = 0;
	
	
	public void SetMatrixValue(float value)
	{
		if (currentIndexMat == null)
		{
			currentMat = new float[3,3];//testing, el último 3 será cambiado luego por las columnas esas
		}
		
		int row = currentIndexMat / 3;
		int col = currentIndexMat % 3;
		
		currentMat[row,col] = value;
		currentIndexMat++;
	}
	
	
	public float[,] EncryptMatrix(float[,] matrix, bool isEncrypting = true)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		int targetCols = encryptKey.GetLength(1); //siempre será 3 no sé ni pq lo hago así
		float[,] currentMatrix = encryptKey;
		if(!isEncrypting)
			currentMatrix = decryptKey;
		
		if (cols !=targetCols)
		{
			GD.PrintErr("Las matrices no coinciden. Algo petateó");
			throw new Exception("Petateó (no se pueden multiplicar)");			
		}
		
		float [,] newMatrix = new float[rows, targetCols];
		
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < targetCols; j++)
			{
				newMatrix[i,j] = 0;
				for (int k = 0; k < cols; k++)
				{
					newMatrix[i,j] += matrix[i,k] * currentMatrix[k,j];
				}
			}
		}
		return newMatrix;
	}
	
	public int ConvertChar(char letter)
	{
		switch (letter)
		{
   			case 'a':
				return 1;
			case 'A':
				return 1;				
			case 'b':
				return 2;
			case 'B':
				return 2;
			case 'c':
				return 3;
			case 'C':
				return 3;
			case 'd':
				return 4;
			case 'D':
	   			return 4;
			case 'e':
				return 5;
			case 'E':
				return 5;
			case 'f':
				return 6;
			case 'F':
				return 6;
			case 'g':
				return 7;
			case 'G':
				return 7;
			case 'h':
				return 8;
			case 'H':
				return 8;
			case 'i':
				return 9;
			case 'I':
				return 9;
			case 'j':
				return 10;
			case 'J':
				return 10;
			case 'k':
				return 11;
			case 'K':
				return 11;
			case 'l':
				return 12;
			case 'L':
				return 12;
			case 'm':
				return 13;
			case 'M':
				return 13;
			case 'n':
				return 14;
			case 'N':
				return 14;
			case 'o':
				return 15;
			case 'O':
				return 15;
			case 'p':
				return 16;
			case 'P':
				return 16;
			case 'q':
				return 17;
			case 'Q':
				return 17;
			case 'r':
				return 18;
			case 'R':
				return 18;
			case 's':
				return 19;
			case 'S':
				return 19;
			case 't':
				return 20;
			case 'T':
				return 20;
			case 'u':
				return 21;
			case 'U':
				return 21;
			case 'v':
				return 22;
			case 'V':
				return 22;
			case 'w':
				return 23;
			case 'W':
				return 23;
			case 'x':
				return 24;
			case 'X':
				return 24;
			case 'y':
				return 25;
			case 'Y':
				return 25;
			case 'z':
				return 26;
			case 'Z':
				return 26;
			default:
				return 27;
}

	}
}
