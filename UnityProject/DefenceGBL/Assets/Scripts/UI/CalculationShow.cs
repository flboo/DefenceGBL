using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CalculationShow : MonoBehaviour {

	public Image mt_Thousand; 
	public Image mt_Hundreds; 
	public Image mt_Ten; 
	public Image mt_Single; 
	public Sprite[] tx_Number;


	public void SetNum(int num)
	{
		int q = (int)(num / 1000);
		int	bsg = num % 1000;
		int b = (int)(bsg / 100);
		int sg = bsg % 100;
		int s = (int)(sg / 10);
		int g = num % 10;
		if(mt_Thousand != null)
			mt_Thousand.sprite = tx_Number [q];
		if(mt_Hundreds != null)
			mt_Hundreds.sprite = tx_Number [b];
		if(mt_Ten != null)
			mt_Ten.sprite = tx_Number [s];
		if(mt_Single != null)
			mt_Single.sprite = tx_Number [g];
	}



}

