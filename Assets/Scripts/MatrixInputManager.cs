using Godot;
using System;

public partial class MatrixInputManager : HBoxContainer
{
	
	public int cols = 0;
	public PackedScene columnInput = GD.Load<PackedScene>("res://Assets/Prefabs/MatrixColumnInput.tscn"); //prefab
	public string decriptedMessage = "";
	[Export] public Node addButton;
	[Export] public DecodingTable decodingTable;
	[Export] public Label messageLabel;
	[Export] public MatrixManager matrixManager; //To show decrypted Matrix

#region GUI
	public void AddColumn()
	{
		MatrixInput newColumn = (MatrixInput)columnInput.Instantiate();
		this.AddChild(newColumn);
		MoveChild(addButton, GetChildCount() - 1);		
	}
		
#endregion


	public void DecryptMatrix() //Called from button press
	{
		int matrixColumns = GetChildCount() - 1; //Quita una pq quita el botón de +		
		double[,] inputMatrix = new double[3, matrixColumns];
		decriptedMessage = "";
		matrixManager.ResetMatrix();
		for (int col = 0; col < matrixColumns; col++)
		{
			Node columnNode = GetChild(col);
			//MatrixInput columnData = column.GetNode
			var column = columnNode as MatrixInput;
			
			//GD.Print("TESTING AAAAAAAAAAAAAAAAAAAAAAAAA: " + column); //objeto de donde se llama
			for (int row = 0; row < 3; row++)  // Se usan 3 filas por columna
			{
				inputMatrix[row, col] = column.GetValues(row);
				//var test = column.GetValues(row); //necesitaria un tipo getcomponent
				GD.Print($"Matrix CORDS COL {col} ROW {row} value is: {inputMatrix[row, col]}");
			}
		}

		// Imprimir la matriz original
		GD.Print("Matriz recibida:");
		for (int i = 0; i < 3; i++)
		{
			string rowValues = "";
			for (int j = 0; j < matrixColumns; j++)
			{
				rowValues += inputMatrix[i, j].ToString() + "\t";
			}
			GD.Print(rowValues);
		}
		
		double[,] decryptedMatrix;
		decryptedMatrix = decodingTable.MultiplyMatrix(inputMatrix);
		
		//Imprimir la matrix desencriptada
		
		GD.Print("Matriz desencriptada:");
		for (int i = 0; i < 3; i++)
		{
			string rowValues = "";
			for (int j = 0; j < matrixColumns; j++)
			{
				rowValues += decryptedMatrix[i, j].ToString() + "\t";
			}
			GD.Print(rowValues);
		}
		for (int i = 0; i < matrixColumns; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				decriptedMessage += decodingTable.ConvertValueToChar((int)decryptedMatrix[j,i]);
				matrixManager.AddValuesToMatrix((int)decryptedMatrix[j,i]);	
			}
		}
		GD.Print("The message is: " + decriptedMessage);
		messageLabel.Text = decriptedMessage;
	}





}
	
	
