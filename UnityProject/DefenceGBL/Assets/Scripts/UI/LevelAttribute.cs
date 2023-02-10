using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAttribute : MonoBehaviour {

	public Button b_LevelButton;
	public Image LevelButton;
	public Image Locked;
	public Image OneStar;
	public Image TwoStar;
	public Image ThreeStar;


	public Sprite LevelGeted;
	public Sprite LevelNoGeted;

	public Image image_Level;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetStars(int num)
	{
		if (num == 0)
		{
			OneStar.enabled = false;
			TwoStar.enabled = false;
			ThreeStar.enabled = false;
		}
		else if(num == 1)
		{
			OneStar.enabled = true;
			TwoStar.enabled = false;
			ThreeStar.enabled = false;
		}
		else if(num == 2)
		{
			OneStar.enabled = true;
			TwoStar.enabled = true;
			ThreeStar.enabled = false;
		}
		else if(num == 3)
		{
			OneStar.enabled = true;
			TwoStar.enabled = true;
			ThreeStar.enabled = true;
		}
	}

	public void SetIconImage(int ok)
	{
		if(ok == 0)
		{
			LevelButton.sprite = LevelNoGeted;
			b_LevelButton.enabled = false;
			Locked.enabled = true;
		}
		else if(ok == 1)
		{
			LevelButton.sprite = LevelGeted;
			b_LevelButton.enabled = true;
			Locked.enabled = false;
		}
		else if(ok == 2)
		{
			LevelButton.sprite = LevelGeted;
			b_LevelButton.enabled = true;
			Locked.enabled = false;
		}

	}


}
