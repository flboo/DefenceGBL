using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerContrl : MonoBehaviour {

	/// <summary>
	/// 设置当前塔属性
	/// </summary>
	/// <param name="tt">Tt.</param>
	public void SetCurrentTowerAB(TowerType tt)
	{
		switch(tt)
		{
		case TowerType.IronTower:
			GameContrl.CurrentChoosedTowerAttribute = GetTowerAttribute ("IronTower");
			break;
		case TowerType.LightningTower:
			GameContrl.CurrentChoosedTowerAttribute = GetTowerAttribute ("LightningTower");
			break;
		case TowerType.IceTower:
			GameContrl.CurrentChoosedTowerAttribute = GetTowerAttribute ("IceTower");
			break;
		case TowerType.FlameTower:
			GameContrl.CurrentChoosedTowerAttribute = GetTowerAttribute ("FlameTower");
			break;
		}
	}


	/// <summary>
	/// 获得塔属性
	/// </summary>
	/// <returns>The tower attribute.</returns>
	/// <param name="str">String.</param>
	public TowerAttribute GetTowerAttribute(string str)
	{
		TowerAttribute ttt = new TowerAttribute ();
		ttt.name = CoreStaticDataManager.instance().GetTowerDataByName (str).m_Name;
		ttt.level = CoreStaticDataManager.instance().GetTowerDataByName (str).m_Level;
		ttt.AttackNum = CoreStaticDataManager.instance().GetTowerDataByName (str).m_AttackNum;
		ttt.AttackRange = CoreStaticDataManager.instance().GetTowerDataByName (str).m_AttackRange;
		ttt.AttackSpeed = CoreStaticDataManager.instance().GetTowerDataByName (str).m_AttackSpeed;
		ttt.AttackSpeedUpgrade = CoreStaticDataManager.instance().GetTowerDataByName (str).m_AttackSpeedUpgrade;
		ttt.IsAOE = CoreStaticDataManager.instance().GetTowerDataByName (str).m_IsAOE;
		ttt.BuildPrice = CoreStaticDataManager.instance().GetTowerDataByName (str).m_BuildPrice;
		ttt.DismantlePrice = CoreStaticDataManager.instance().GetTowerDataByName (str).m_DismantlePrice;
		ttt.Skills = CoreStaticDataManager.instance().GetTowerDataByName (str).m_skills;
		return ttt;
	}

}
