using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour {


	/// <summary>
	/// 保存数据
	/// </summary>
	public void SetDataSave()
	{
        PlayerPrefsX.SetIntArray("StarsData", LevelSelectModel.StarsData);
        PlayerPrefs.SetInt ("Stars",GameContrl.Stars);
		PlayerPrefs.SetInt ("FireBallLevel",GameContrl.FireBallLevel);
		PlayerPrefs.SetInt ("TornadoLevel",GameContrl.TornadoLevel);
		PlayerPrefs.SetInt ("SwampLevel",GameContrl.SwampLevel);
		PlayerPrefs.SetInt ("DuwuLevel",GameContrl.DuwuLevel);
		PlayerPrefs.SetInt ("GetMaxLevel",GameContrl.GetMaxLevel);
	}
	/// <summary>
	/// 获得保存的数据
	/// </summary>
	public void GetDataSave()
	{
        if (PlayerPrefs.HasKey("StarsData"))
            LevelSelectModel.StarsData = PlayerPrefsX.GetIntArray("StarsData");
        GameContrl.Stars = PlayerPrefs.GetInt ("Stars",0);
		GameContrl.FireBallLevel = PlayerPrefs.GetInt ("FireBallLevel",1);
		GameContrl.TornadoLevel = PlayerPrefs.GetInt ("TornadoLevel",1);
		GameContrl.SwampLevel = PlayerPrefs.GetInt ("SwampLevel",1);
		GameContrl.DuwuLevel = PlayerPrefs.GetInt ("DuwuLevel",1);
		GameContrl.GetMaxLevel = PlayerPrefs.GetInt ("GetMaxLevel",0);
	}
}
