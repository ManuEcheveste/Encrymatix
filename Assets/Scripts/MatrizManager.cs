using Godot;
using System;

public partial class MatrizManager : HBoxContainer
{
	
	public int cols = 1; //Columnas de la matriz
	int valueCounter = 0;
	
	[Export] public MatrizColumn currentColumn;
	public PackedScene column = GD.Load<PackedScene>("res://Assets/Prefabs/MatrizColumn.tscn");
	
	
	public void ResetMatriz()
	{
		foreach(Node child in GetChildren())
		{
			child.QueueFree();			
		}		
			MatrizColumn newColumn = (MatrizColumn)column.Instantiate();
			this.AddChild(newColumn);
			currentColumn = newColumn;
			valueCounter = 0;
	}
	
	public void AddValuesToMatriz(int valueM)
	{
		bool writeSuccesful = currentColumn.WriteValue(valueM);
		if(!writeSuccesful)
		{
			GD.Print("NOT ENOUGH SPACE");
			MatrizColumn newColumn = (MatrizColumn)column.Instantiate();
			this.AddChild(newColumn);
			currentColumn = newColumn;
			currentColumn.WriteValue(valueM);
			//Crear la siguiente columna e intentarlo
		}
	}
	
	
}
