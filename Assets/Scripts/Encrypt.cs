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
			if(row < 3)
				row++;
			else			
			{
				row = 0;
				col++;
			}			
			tmpValue = decodingTable.ConvertChar(letter);
			GD.Print(tmpValue.ToString());
			encryptedMessage = encryptedMessage + tmpValue.ToString() + " ";			
			rawMatrixManager.AddValuesToMatrix(tmpValue);
			//matrix[row, col] = tmpValue;
		}
		double[,] encryptedMatrix;
		encryptedMatrix = decodingTable.MultiplyMatrix(matrix,true);
		for (int i = 0; i < matrix.GetLength(1); i++)
		{
			for (int j = 0; j < 3; j++)
			{				
				encryptedMatrixManager.AddValuesToMatrix((int)encryptedMatrix[j,i]);	
			}
		}
	}
}
