using Godot;
using System;

public partial class Encrypt : TabBar
{
	public string userMessage;
	[Export] public DecodingTable library;
	[Export] public LineEdit messageInput;
	[Export] public MatrizManager matrizManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//EncryptMessage();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	
	public void EncryptMessage()
	{
		matrizManager.ResetMatriz();
		string encryptedMessage = "";
		userMessage = messageInput.Text;
		int test;
		foreach(char letter in userMessage)
		{
			test = library.ConvertChar(letter);
			GD.Print(test.ToString());
			encryptedMessage = encryptedMessage + test.ToString() + " ";
			
			matrizManager.AddValuesToMatriz(test);
		}
		GD.Print("Final message: ", encryptedMessage);
	}
}
