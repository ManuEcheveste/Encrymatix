using Godot;
using System;

public partial class MatrizColumn : VBoxContainer
{
	[Export] public Label matrizChar1;
	[Export] public Label matrizChar2;
	[Export] public Label matrizChar3;
	
	
	public int matriz = 0; //veces que hemos escrito en las filas de la matriz, máximo 3 veces (contador).
	
	public bool WriteValue(int valorM)
	{
		if (matriz == 0)
		{
			matrizChar1.Text = valorM.ToString();
			matriz++;
			return true; //Regresa true para indicar que sí se escribió bien el valor.
		}
		else if(matriz == 1)
		{
			matrizChar2.Text = valorM.ToString();
			matriz++;
			return true;
		}
		else if (matriz == 2)
		{
			matrizChar3.Text = valorM.ToString();
			matriz++;
			return true;
		}
		else
			return false; //Regresa false para indicar que ya no hay cupo, y que pase a la siguiente
	}
}
