using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionContrl : MonoBehaviour {


	public static string[] MissionName = 
	{
		"",
		"消灭所有敌人",
		"不低于10条命",
		"不低于15条命",
		"不建造塔",
		"杀死20个哥布林",
		"杀死25个哥布林",
		"杀死3个女巫",
		"杀死4个女巫",
		"杀死5个女巫",
		"杀死6个狼骑",
		"杀死10个狼骑",
		"杀死12个狼骑",
		"杀死4个骷髅怪",
		"杀死8个骷髅怪",
		"杀死12个骷髅怪",
		"杀死2个山巨人",
		"杀死3个山巨人",
		"杀死4个山巨人",
	};

	public static string[] MissionName_EN = 
	{
		"",
		"Kill all the enemies",
		"At least 10 lives",
		"At least 15 lives",
		"No tower establishment",
		"Kill 20 Goblins",
		"Kill 25 Goblins",
		"Kill 3 Witches",
		"Kill 4 Witches",
		"Kill 5 Witches",
		"Kill 6  Wolf ride",
		"Kill 10 Wolf ride",
		"Kill 12 Wolf ride",
		"Kill 4 Skeletons",
		"Kill 8 Skeletons",
		"Kill 12 Skeletons",
		"Kill 2 Giants",
		"Kill 3 Giants",
		"Kill 4 Giants",
	};





	public Sprite[] MissionIcon;

	public static int[] NeedKillNum = {
		0,
		0,
		10,
		15,
		0,
		20,
		25,
		3,
		4,
		5,
		6,
		10,
		12,
		4,
		8,
		12,
		2,
		3,
		4,

	};

	public static Vector3[] MissionNumByLevel = 
	{
		new Vector3(0,0,0),//None
		new Vector3(1,5,10),
		new Vector3(1,7,11),
		new Vector3(3,8,4),
		new Vector3(12,15,17),
		new Vector3(1,3,18),
	};


	/// <summary>
	/// 根据关卡，完成任务情况
	/// </summary>
	/// <returns><c>true</c>, if by level was missioned, <c>false</c> otherwise.</returns>
	/// <param name="level">Level.</param>
	public bool MissionByLevel(int MissionNum)
	{
		switch (MissionNum) 
		{
		case 1:
			if (GameContrl.GetInstance.LeftLifeNum >= GameContrl.GetInstance.InitLifeNum)
				return true;
			break;
		case 2:
			if (GameContrl.GetInstance.LeftLifeNum >= 10)
				return true;
			break;
		case 3:
			if (GameContrl.GetInstance.LeftLifeNum >= 15)
				return true;
			break;
		case 4:
			if (GameContrl.TowerNum == 0)
				return true;
			break;
		case 5:
			if (GameContrl.KillGoblinNum >= 20)
				return true;
			break;
		case 6:
			if (GameContrl.KillGoblinNum >= 25)
				return true;
			break;
		case 7:
			if (GameContrl.KillWitchNum >= 3)
				return true;
			break;
		case 8:
			if (GameContrl.KillWitchNum >= 4)
				return true;
			break;
		case 9:
			if (GameContrl.KillWitchNum >= 5)
				return true;
			break;
		case 10:
			if (GameContrl.KillRidingGoblinNum >= 6)
				return true;
			break;
		case 11:
			if (GameContrl.KillRidingGoblinNum >= 10)
				return true;
			break;
		case 12:
			if (GameContrl.KillRidingGoblinNum >= 12)
				return true;
			break;
		case 13:
			if (GameContrl.KillSkeletonNum >= 4)
				return true;
			break;
		case 14:
			if (GameContrl.KillSkeletonNum >= 8)
				return true;
			break;
		case 15:
			if (GameContrl.KillSkeletonNum >= 12)
				return true;
			break;
		case 16:
			if (GameContrl.KillMountainGiantNum >= 2)
				return true;
			break;
		case 17:
			if (GameContrl.KillMountainGiantNum >= 3)
				return true;
			break;
		case 18:
			if (GameContrl.KillMountainGiantNum >= 4)
				return true;
			break;
		}
		return false;
	}


}
