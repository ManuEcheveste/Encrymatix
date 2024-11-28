using Godot;
using System;

public partial class Encrypt : TabBar
{
	public string userMessage;
	[Export] public DecodingTable decodingTable;
	[Export] public LineEdit messageInput;
	[Export] public MatrixManager rawMatrixManager;
	[Export] public MatrixManager encryptedMatrixManager;
	

	
	public void EncryptMessage()
	{
		rawMatrixManager.ResetMatrix();
		encryptedMatrixManager.ResetMatrix();
		string encryptedMessage = "";
		userMessage = messageInput.Text;
		double[,] matrix = new double[3, userMessage.Length / 3 + userMessage.Length % 3];
		for(int i = 0; i < matrix.GetLength(0); i++) //primero asigno a todos los valores de la matriz 27 apra evitar errores
		{
			for(int j = 0; j < matrix.GetLength(1); j++)
			{
				matrix[i,j] = 27;
			}
		}
		int tmpValue;
		int col = 0;
		int row = 0;
		foreach(char letter in userMessage)
		{			
			tmpValue = decodingTable.ConvertChar(letter);
			GD.Print($"Writing value {tmpValue} in Column {col} and row {row}");
			//matrix[col, row] = tmpValue;
			matrix[row, col] = tmpValue;
			if(row < 2)
				row++;
			else			
			{
				row = 0;
				col++;
			}			
			GD.Print(tmpValue.ToString());
			encryptedMessage = encryptedMessage + tmpValue.ToString() + " ";			
			rawMatrixManager.AddValuesToMatrix(tmpValue);
		}
		double[,] encryptedMatrix;
		encryptedMatrix = decodingTable.MultiplyMatrix(matrix,true);
		//GD.Print("AAAAAAAAAAAAAAAAAAAAAsgd: " + encryptedMatrix[0,0]);
		for (int i = 0; i < encryptedMatrix.GetLength(1); i++)
		{
			for (int j = 0; j < 3; j++)
			{				
				encryptedMatrixManager.AddValuesToMatrix((int)encryptedMatrix[j,i]);
				//encryptedMatrixManager.AddValuesToMatrix((int)encryptedMatrix[i,j]);	
			}
		}
	}
}
