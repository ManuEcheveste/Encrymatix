using Godot;
using System;

public partial class AudioManager : AudioStreamPlayer2D
{
	[Export] public AudioStreamPlayer2D sfx;
	[Export] public AudioStream convertSFX;
	[Export] public AudioStream deleteSFX;
	[Export] public AudioStream confirmSFX;


	public void PlayConvert()
	{
		Stop();
		Stream = convertSFX;
		Play();
	}

	public void PlayConfirm()
	{
		Stop();
		Stream = confirmSFX;
		Play();
	}

	public void PlayDeleteSFX()
	{
		Stop();
		Stream = deleteSFX;
		Play();
	}
}
