using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinContrl : MonoBehaviour {


	void Update () 
	{
		this.transform.Rotate (0,3,0,Space.Self);
	}



	void Start()
	{
		Invoke ("GetCoins",1f);
	}
	public void GetCoins()
	{
		GameContrl.GetInstance.Coins++;
		GameContrl.GetInstance.UpdateCoins ();
		Destroy (this.gameObject);
	}


}
