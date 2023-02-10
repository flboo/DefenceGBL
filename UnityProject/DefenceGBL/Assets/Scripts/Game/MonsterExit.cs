using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExit : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (GameContrl.IsPlaying == false)
			return;
		if (other.CompareTag ("Goblin") || other.CompareTag ("RidingGoblin") || other.CompareTag ("Witch") || other.CompareTag ("Skeleton") || other.CompareTag ("Giant"))
		{
			if(other.GetComponent<MonsterSelfContrl>() != null)
			{
				if(other.GetComponent<MonsterSelfContrl>().Alife == false)
				{
					return;
				}
			}
			GameContrl.GetInstance.LeftLifeNum--;
			if (GameContrl.GetInstance.LeftLifeNum <= 0)
				GameContrl.GetInstance.LeftLifeNum = 0;
			GameContrl.GetInstance.UpdateLifes ();
            GameContrl.instance.SetHandleShake();
            GameContrl.GetInstance.uigamecontrl.UpdateShowMission ();
            GameContrl.RunMonsterNum++;
			GameContrl.GetMonsterNum++;
           // Debug.Log("MonsterNum  " + "逃一个*1，一共逃离了： " + GameContrl.RunMonsterNum + "当前一共死亡或者逃逸了： " + GameContrl.GetMonsterNum);
            //			Debug.LogError ("GetMonsterNum = " + GameContrl.GetMonsterNum);
            other.gameObject.SetActive (false);
		}
	}
}
