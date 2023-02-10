using UnityEngine;
using System.Collections;

public class AudioContrl : MonoBehaviour {

	public AudioClip[] clips;
	public AudioSource audiosource;
	public AudioSource audiosource2;
	public AudioSource bgAudioSource;
	static AudioContrl audiocontrl;


	public static AudioContrl GetInstance()
	{
		if (audiocontrl == null)
		{
			audiocontrl = GameObject.Find ("AudioContrl").GetComponent<AudioContrl>();
		}
		return audiocontrl;
	}

	public void PlayAudio(string str)
	{
		switch (str) 
		{
		case "ClickUI":
			audiosource.clip = clips [0];
			audiosource2.clip = clips [0];
			break;
		case "GameWin":
			audiosource.clip = clips [1];
			audiosource2.clip = clips [1];
			break;
		case "GameLose":
			audiosource.clip = clips [2];
			audiosource2.clip = clips [2];
			break;
		case "FireBall":
			audiosource.clip = clips [3];
			audiosource2.clip = clips [3];
			break;
		case "Fornado":
			audiosource.clip = clips [4];
			audiosource2.clip = clips [4];
			break;
		case "Swamp":
			audiosource.clip = clips [5];
			audiosource2.clip = clips [5];
			break;
		case "Gas":
			audiosource.clip = clips [6];
			audiosource2.clip = clips [6];
			break;
		case "Iron":
			audiosource.clip = clips [7];
			audiosource2.clip = clips [7];
			break;
		case "Lightning":
			audiosource.clip = clips [8];
			audiosource2.clip = clips [8];
			break;
		case "LightningAttack":
			audiosource.clip = clips [9];
			audiosource2.clip = clips [9];
			break;
		case "Ice":
			audiosource.clip = clips [10];
			audiosource2.clip = clips [10];
			break;
		case "IceAttack":
			audiosource.clip = clips [11];
			audiosource2.clip = clips [11];
			break;
		case "Flame":
			audiosource.clip = clips [12];
			audiosource2.clip = clips [12];
			break;
		case "Bomb":
			audiosource.clip = clips [13];
			audiosource2.clip = clips [13];
			break;
		case "GoblinDeath":
			audiosource.clip = clips [14];
			audiosource2.clip = clips [14];
			break;
		case "WitchDeath":
			audiosource.clip = clips [15];
			audiosource2.clip = clips [15];
			break;
		case "GiantDeath":
			audiosource.clip = clips [16];
			audiosource2.clip = clips [16];
			break;
		case "SkeletonDeath":
			audiosource.clip = clips [17];
			audiosource2.clip = clips [17];
			break;
		case "Build":
			audiosource.clip = clips [18];
			audiosource2.clip = clips [18];
			break;
		}
		if (audiosource.isPlaying)
		{
			if(!audiosource2.isPlaying)
				audiosource2.Play ();
		}
		else
		{
			audiosource.Play ();
		}
		if(audiosource2.isPlaying)
		{
			if(!audiosource.isPlaying)
				audiosource.Play ();
		}
		else
		{
			audiosource2.Play ();
		}
	}

}
