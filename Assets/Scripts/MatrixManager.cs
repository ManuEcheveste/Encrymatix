using Godot;
using System;

public partial class MatrixManager : HBoxContainer
{
	
	public int cols = 1; //Columnas de la matriz
	int valueCounter = 0;
	
	[Export] public MatrixColumn currentColumn;
	public PackedScene column = GD.Load<PackedScene>("res://Assets/Prefabs/MatrixColumn.tscn");
	
	
	public void ResetMatrix()
	{
		foreach(Node child in GetChildren())
		{
			child.QueueFree();			
		}		
			MatrixColumn newColumn = (MatrixColumn)column.Instantiate();
			this.AddChild(newColumn);
			currentColumn = newColumn;
			valueCounter = 0;
	}
	
	public void AddValuesToMatrix(int valueM)
	{
		bool writeSuccesful = currentColumn.WriteValue(valueM);
		if(!writeSuccesful)
		{
			GD.Print("NOT ENOUGH SPACE");
			MatrixColumn newColumn = (MatrixColumn)column.Instantiate();
			this.AddChild(newColumn);
			currentColumn = newColumn;
			currentColumn.WriteValue(valueM);
		}
	}
	
	
}
