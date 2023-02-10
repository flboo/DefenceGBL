using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {

	public AudioClip[] clips;
	public AudioSource audiosource;
	static MusicChange musicchange;

	public static MusicChange GetInstance()
	{
		if (musicchange == null)
		{
			musicchange = GameObject.Find ("Player").GetComponent<MusicChange>();
		}
		return musicchange;
	}

	public void PlayMusic(int num)
	{
		audiosource.clip = clips [num];
		audiosource.Play ();
	}
}
