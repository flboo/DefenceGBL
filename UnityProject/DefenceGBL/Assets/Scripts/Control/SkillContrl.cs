using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContrl : MonoBehaviour {

	public bool CanFire = false;
	public bool CanTornado = false;
	public bool CanSwamp = false;
	public bool CanDuwu = false;
	public float Fire_time = 0;
	public float Tornado_time = 0;
	public float Swamp_time = 0;
	public float Duwu_time = 0;
	float Fire_Cd;
	float Fire_CdDown;
	float Tornado_Cd;
	float Tornado_CdDown;
	float Swamp_Cd;
	float Swamp_CdDown;
	float Duwu_Cd;
	float Duwu_CdDown;
	/// <summary>
	/// 设置当前技能属性
	/// </summary>
	/// <param name="st">St.</param>
	public void SetCurrentSkillAB(SkillsType st)
	{
		switch (st)
		{
		case SkillsType.FireBall:
			GameContrl.CurrentChoosedSkillAttribute = GetSkillAttribute ("FireBall");
			Fire_Cd = GetSkillAttribute ("FireBall").CD;
			Fire_CdDown = GetSkillAttribute ("FireBall").CDDown;
			break;
		case SkillsType.Tornado:
			GameContrl.CurrentChoosedSkillAttribute = GetSkillAttribute ("Tornado");
			Tornado_Cd = GetSkillAttribute ("Tornado").CD;
			Tornado_CdDown = GetSkillAttribute ("Tornado").CDDown;
			break;
		case SkillsType.Swamp:
			GameContrl.CurrentChoosedSkillAttribute = GetSkillAttribute ("Swamp");
			Swamp_Cd = GetSkillAttribute ("Swamp").CD;
			Swamp_CdDown = GetSkillAttribute ("Swamp").CDDown;
			break;
		case SkillsType.Duwu:
			GameContrl.CurrentChoosedSkillAttribute = GetSkillAttribute ("Duwu");
			Duwu_Cd = GetSkillAttribute ("Duwu").CD;
			Duwu_CdDown = GetSkillAttribute ("Duwu").CDDown;
			break;
		}

	}

	/// <summary>
	/// 获得当前技能属性
	/// </summary>
	/// <param name="str">String.</param>
	private SkillAttribute GetSkillAttribute(string str)
	{
		SkillAttribute aaa = new SkillAttribute();
		aaa.id = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_id;
		aaa.name = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_Name;
		aaa.Level = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_Level;
		aaa.MaxLevel = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_MaxLevel;
		aaa.Instant = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_Instant;
		aaa.IsAOE = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_IsAOE;
		aaa.AOERange = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_AOERange;
		aaa.AOERangeUpgrade = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_AOERangeUpgrade;
		aaa.AttackNum = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_AttackNum;
		aaa.AttackNumUpgrade = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_AttackNumUpgrade;
		aaa.LastTime = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_LastTime;
		aaa.LastTimeUpgrade = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_LastTimeUpgrade;
		aaa.CD = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_CD;
		aaa.CDDown = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_CDDown;
		aaa.CoinCost = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_CoinCost;
		aaa.SlowDown = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_SlowDown;
		aaa.SlowDownUpgrade = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_SlowDownUpgrade;
		aaa.Stars = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_Stars;
		aaa.StartsUpgrade = CoreStaticDataManager.instance ().GetSkillDataByName (str).m_StarsUpgrade;
		return aaa;
	}


	void Update()
	{
		if(Time.time - Fire_time >= Fire_Cd - (GameContrl.FireBallLevel-1)*Fire_CdDown)
		{
			GameContrl.GetInstance.uigamecontrl.Firecd.fillAmount = 0;
			CanFire = true;
		}
		else
		{
			GameContrl.GetInstance.uigamecontrl.Firecd.fillAmount = 1 - (Time.time - Fire_time) / (Fire_Cd - (GameContrl.FireBallLevel - 1) * Fire_CdDown);
		}

		if(Time.time - Tornado_time >= Tornado_Cd - (GameContrl.TornadoLevel-1)*Tornado_CdDown)
		{
			GameContrl.GetInstance.uigamecontrl.Tornadocd.fillAmount = 0;
			CanTornado = true;
		}
		else
		{
			GameContrl.GetInstance.uigamecontrl.Tornadocd.fillAmount = 1 - (Time.time - Tornado_time) / (Tornado_Cd - (GameContrl.TornadoLevel - 1) * Tornado_CdDown);
		}

		if(Time.time - Swamp_time >= Swamp_Cd - (GameContrl.SwampLevel-1)*Swamp_CdDown)
		{
			GameContrl.GetInstance.uigamecontrl.Swampcd.fillAmount = 0;
			CanSwamp = true;
		}
		else
		{
			GameContrl.GetInstance.uigamecontrl.Swampcd.fillAmount = 1 - (Time.time - Swamp_time) / (Swamp_Cd - (GameContrl.SwampLevel - 1) * Swamp_CdDown);
		}

		if(Time.time - Duwu_time >= Duwu_Cd - (GameContrl.DuwuLevel-1)*Duwu_CdDown)
		{
			GameContrl.GetInstance.uigamecontrl.Duwucd.fillAmount = 0;
			CanDuwu = true;
		}
		else
		{
			GameContrl.GetInstance.uigamecontrl.Duwucd.fillAmount = 1 - (Time.time - Duwu_time) / (Duwu_Cd - (GameContrl.DuwuLevel - 1) * Duwu_CdDown);
		}
	}

}
