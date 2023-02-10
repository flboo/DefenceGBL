using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour {

	public GameObject tips;

	void OnEnable()
	{
		Invoke ("HideTips",2f);
	}

	void HideTips()
	{
		tips.SetActive (false);
	}
}
