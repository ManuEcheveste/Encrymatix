using Godot;
using System;
using System.Collections;

public partial class MatrixInput : VBoxContainer
{
	[Export] public SpinBox matrixInput1;
	[Export] public SpinBox matrixInput2;
	[Export] public SpinBox matrixInput3;
	
	
	public void DeleteColumn()
	{
		//chance indicarle al manager que ya no existo
		QueueFree();
	}
	
	public int GetValues(int row)
	{
		switch (row)
		{
			case 0:
				return (int)matrixInput1.Value;
			case 1:
				return (int)matrixInput2.Value;
			case 2:
				return (int)matrixInput3.Value;
			default:
				GD.PrintErr("Requested value from invalid input.");
				return 160288; //código de error, podría comprobarse después si es este número, lanzar una excepción
		}
	}
	
}
