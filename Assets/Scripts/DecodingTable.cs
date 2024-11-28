using Godot;
using System;

public partial class DecodingTable : Node
{

	[Export] public MatrixManager targetMatrix;

	public double[,] encryptKey = new double[3,3]
	{
		{1,2,1},
		{3,0,-1},
		{4,0,2}
	};
	
	public double[,] decryptKey = new double[3,3]
	{
		{0, 1.0/5.0, 1.0/10.0},
		{1.0/2.0, 1.0/10.0, -1.0/5.0},
		{0, -2.0/5.0, 3.0/10.0}
	};

	#region Libraries
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
	
	public char ConvertValueToChar(int value)
	{
		switch (value)
		{
			case 1: return 'A';
			case 2: return 'B';
			case 3: return 'C';
			case 4: return 'D';
			case 5: return 'E';
			case 6: return 'F';
			case 7: return 'G';
			case 8: return 'H';
			case 9: return 'I';
			case 10: return 'J';
			case 11: return 'K';
			case 12: return 'L';
			case 13: return 'M';
			case 14: return 'N';
			case 15: return 'O';
			case 16: return 'P';
			case 17: return 'Q';
			case 18: return 'R';
			case 19: return 'S';
			case 20: return 'T';
			case 21: return 'U';
			case 22: return 'V';
			case 23: return 'W';
			case 24: return 'X';
			case 25: return 'Y';
			case 26: return 'Z';
			default: return ' ';
		}
	}
	
	#endregion

	public double[,] MultiplyMatrix(double[,] matrix, bool isEncrypting = false)
	{
		int cols = matrix.GetLength(1);
		GD.Print($"Colums in matrix received is: {cols}");
		double[,] newMatrix = new double[3, cols];
		double[,] keyUsed = isEncrypting ? encryptKey : decryptKey;
		double temp = 0;
		for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    temp = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        temp += keyUsed[i, k] * matrix[k, j];
                    }
                    newMatrix[i, j] = Math.Round(temp);
                }
            }
		
		
		GD.Print("Returning value");
		return newMatrix;
	}
}