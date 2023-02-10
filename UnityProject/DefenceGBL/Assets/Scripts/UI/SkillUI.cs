using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour {

	public DataSave datasave;
	public UIMenuContrl uiMenuContrl;

	public Image SkillIcon;
	public Text SkillTitle;
	public Text SkillInfor;

	public Text LevelNum;
	public Text LevelUpNum;
	public Text TimeNum;
	public Text TimeUpNum;
	public Text AttackNum;
	public Text AttackUpNum;
	public Text NeedStars;

	public Text AllStars;

	public Sprite FireBallIcon;
	public Sprite TornaboIcon;
	public Sprite SwampIcon;
	public Sprite DuwuIcon;

	public GameObject Tips;
	public Image tipsImage;
	public Sprite NoEnough;
	public Sprite FullLevel;
	public Sprite NoEnough_EN;
	public Sprite FullLevel_EN;
	private SkillsType CurrentSkill;
	SkillAttribute skilla = new SkillAttribute();


	void OnEnable()
	{
		datasave.GetDataSave ();
		AllStars.text = GameContrl.Stars.ToString ();
		ChooseSkillAB (0);
	}
	public void ChooseSkillAB(int num)
	{
		uiMenuContrl.PlayAudio ();
		datasave.GetDataSave ();
		if(num == 0)
		{
			CurrentSkill = SkillsType.FireBall;
			SetCurrentSkillAB (CurrentSkill);
			SkillIcon.sprite = FireBallIcon;
			if(Application.systemLanguage == SystemLanguage.English)
			{
				SkillTitle.text = "Fireball";
				SkillInfor.text = "Small fireball \n and huge damage";
			}
			else
			{
				SkillTitle.text = "火 球 术";
				SkillInfor.text = "小小的火球, \n 大大的伤害。";
			}

			LevelNum.text = GameContrl.FireBallLevel.ToString();
			LevelUpNum.text = "1";
			TimeNum.text = (skilla.CD - (GameContrl.FireBallLevel-1)*skilla.CDDown).ToString();
			TimeUpNum.text = skilla.CDDown.ToString();
			AttackNum.text = Mathf.FloorToInt(skilla.AttackNum*(1 +  skilla.AttackNumUpgrade*(GameContrl.FireBallLevel-1))).ToString();
			AttackUpNum.text =  Mathf.FloorToInt(skilla.AttackNum*skilla.AttackNumUpgrade*GameContrl.FireBallLevel).ToString();
			NeedStars.text = (skilla.Stars + skilla.StartsUpgrade * (GameContrl.FireBallLevel - 1)).ToString();
		}
		else if(num == 1)
		{
			CurrentSkill = SkillsType.Tornado;
			SetCurrentSkillAB (CurrentSkill);
			SkillIcon.sprite = TornaboIcon;
			if(Application.systemLanguage == SystemLanguage.English)
			{
				SkillTitle.text = "Tornado";
				SkillInfor.text = "Wind blade and \n violent cut";
			}
			else
			{
				SkillTitle.text = "龙 卷 风";
				SkillInfor.text = "风刃之术,\n暴力切割。";
			}

			LevelNum.text = GameContrl.TornadoLevel.ToString();
			LevelUpNum.text = "1";
			TimeNum.text = (skilla.CD - (GameContrl.TornadoLevel - 1) * skilla.CDDown).ToString();
			TimeUpNum.text = skilla.CDDown.ToString();
			AttackNum.text = Mathf.FloorToInt(skilla.AttackNum*(1 +  skilla.AttackNumUpgrade*(GameContrl.TornadoLevel-1))).ToString();
			AttackUpNum.text =  Mathf.FloorToInt(skilla.AttackNum*skilla.AttackNumUpgrade*GameContrl.TornadoLevel).ToString();
			NeedStars.text = (skilla.Stars + skilla.StartsUpgrade * (GameContrl.TornadoLevel - 1)).ToString();
		}
		else if(num == 2)
		{
			CurrentSkill = SkillsType.Swamp;
			SetCurrentSkillAB (CurrentSkill);
			SkillIcon.sprite = SwampIcon;
			if(Application.systemLanguage == SystemLanguage.English)
			{
				SkillTitle.text = "Gooey Blob";
				SkillInfor.text = "Gooey Blob, best \n for deceleration";
			}
			else
			{
				SkillTitle.text = "沼 泽 术";
				SkillInfor.text = "地狱泥沼,\n减速绝佳。";
			}

			LevelNum.text = GameContrl.SwampLevel.ToString();
			LevelUpNum.text = "1";
			TimeNum.text = (skilla.CD - (GameContrl.SwampLevel - 1) * skilla.CDDown).ToString();
			TimeUpNum.text = skilla.CDDown.ToString();
			AttackNum.text = Mathf.FloorToInt(skilla.AttackNum*(1 +  skilla.AttackNumUpgrade*(GameContrl.SwampLevel-1))).ToString();
			AttackUpNum.text =  Mathf.FloorToInt(skilla.AttackNum*skilla.AttackNumUpgrade*GameContrl.SwampLevel).ToString();
			NeedStars.text = (skilla.Stars + skilla.StartsUpgrade * (GameContrl.SwampLevel - 1)).ToString();
		}
		else if(num == 3)
		{
			CurrentSkill = SkillsType.Duwu;
			SetCurrentSkillAB (CurrentSkill);
			SkillIcon.sprite = DuwuIcon;
			if(Application.systemLanguage == SystemLanguage.English)
			{
				SkillTitle.text = "Cloudkill";
				SkillInfor.text = "Alchemic cloudkill \n and devastating blow";
			}
			else
			{
				SkillTitle.text = "毒 雾 术";
				SkillInfor.text = "炼金的毒雾,\n毁灭性打击。";
			}

			LevelNum.text = GameContrl.DuwuLevel.ToString();
			LevelUpNum.text = "1";
			TimeNum.text = (skilla.CD - (GameContrl.DuwuLevel - 1) * skilla.CDDown).ToString();
			TimeUpNum.text = skilla.CDDown.ToString();
			AttackNum.text = Mathf.FloorToInt(skilla.AttackNum*(1 +  skilla.AttackNumUpgrade*(GameContrl.DuwuLevel-1))).ToString();
			AttackUpNum.text =  Mathf.FloorToInt(skilla.AttackNum*skilla.AttackNumUpgrade*GameContrl.DuwuLevel).ToString();
			NeedStars.text = (skilla.Stars + skilla.StartsUpgrade * (GameContrl.DuwuLevel - 1)).ToString();
		}
	}



	/// <summary>
	/// 关闭界面
	/// </summary>
	public void Close()
	{
		
	}

	/// <summary>
	/// 升级按钮
	/// </summary>
	public void UpgradeButton()
	{
		uiMenuContrl.PlayAudio ();
		if(CurrentSkill == SkillsType.FireBall)
		{
			if(GameContrl.FireBallLevel >= 5)
			{
				//已经满级
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = FullLevel_EN;
				else
					tipsImage.sprite = FullLevel;
				Tips.SetActive(true);
				return;
			}
			if(GameContrl.Stars >= skilla.Stars + skilla.StartsUpgrade*(GameContrl.FireBallLevel-1))
			{
				GameContrl.Stars -= skilla.Stars + skilla.StartsUpgrade*(GameContrl.FireBallLevel-1);
				GameContrl.FireBallLevel++;
			}
			else
			{
				//升级星星不足
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = NoEnough_EN;
				else
					tipsImage.sprite = NoEnough;
				Tips.SetActive(true);
			}
			datasave.SetDataSave ();
			ChooseSkillAB (0);
		}
		else if(CurrentSkill == SkillsType.Tornado)
		{
			if(GameContrl.TornadoLevel >= 5)
			{
				//已经满级
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = FullLevel_EN;
				else
					tipsImage.sprite = FullLevel;
				
				Tips.SetActive(true);
				return;
			}
			if(GameContrl.Stars >= skilla.Stars + skilla.StartsUpgrade*(GameContrl.TornadoLevel-1))
			{
				GameContrl.Stars -= skilla.Stars + skilla.StartsUpgrade*(GameContrl.TornadoLevel-1);
				GameContrl.TornadoLevel++;
			}
			else
			{
				//升级星星不足
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = NoEnough_EN;
				else
					tipsImage.sprite = NoEnough;
				Tips.SetActive(true);
			}
			datasave.SetDataSave ();
			ChooseSkillAB (1);
		}
		else if(CurrentSkill == SkillsType.Swamp)
		{
			if(GameContrl.SwampLevel >= 5)
			{
				//已经满级
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = FullLevel_EN;
				else
					tipsImage.sprite = FullLevel;
				Tips.SetActive(true);
				return;
			}
			if(GameContrl.Stars >= skilla.Stars + skilla.StartsUpgrade*(GameContrl.SwampLevel-1))
			{
				GameContrl.Stars -= skilla.Stars + skilla.StartsUpgrade*(GameContrl.SwampLevel-1);
				GameContrl.SwampLevel++;
			}
			else
			{
				//升级星星不足
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = NoEnough_EN;
				else
					tipsImage.sprite = NoEnough;
				Tips.SetActive(true);
			}
			datasave.SetDataSave ();
			ChooseSkillAB (2);
		}
		else if(CurrentSkill == SkillsType.Duwu)
		{
			if(GameContrl.DuwuLevel >= 5)
			{
				//已经满级
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = FullLevel_EN;
				else
					tipsImage.sprite = FullLevel;
				Tips.SetActive(true);
				return;
			}
			if(GameContrl.Stars >= skilla.Stars + skilla.StartsUpgrade*(GameContrl.DuwuLevel-1))
			{
				GameContrl.Stars -= skilla.Stars + skilla.StartsUpgrade*(GameContrl.DuwuLevel-1);
				GameContrl.DuwuLevel++;
			}
			else
			{
				//升级星星不足
				if(Application.systemLanguage == SystemLanguage.English)
					tipsImage.sprite = NoEnough_EN;
				else
					tipsImage.sprite = NoEnough;
				
				Tips.SetActive(true);
			}
			datasave.SetDataSave ();
			ChooseSkillAB (3);
		}
		AllStars.text = GameContrl.Stars.ToString ();
	}

	/// <summary>
	/// 设置当前技能属性
	/// </summary>
	/// <param name="st">St.</param>
	public void SetCurrentSkillAB(SkillsType st)
	{
		switch (st)
		{
		case SkillsType.FireBall:
			skilla = GetSkillAttribute ("FireBall");
			break;
		case SkillsType.Tornado:
			skilla = GetSkillAttribute ("Tornado");
			break;
		case SkillsType.Swamp:
			skilla = GetSkillAttribute ("Swamp");
			break;
		case SkillsType.Duwu:
			skilla = GetSkillAttribute ("Duwu");
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
		aaa.id = CoreStaticDataManager.instance().GetSkillDataByName (str).m_id;
		aaa.name = CoreStaticDataManager.instance().GetSkillDataByName (str).m_Name;
		aaa.Level = CoreStaticDataManager.instance().GetSkillDataByName (str).m_Level;
		aaa.MaxLevel = CoreStaticDataManager.instance().GetSkillDataByName (str).m_MaxLevel;
		aaa.Instant = CoreStaticDataManager.instance().GetSkillDataByName (str).m_Instant;
		aaa.IsAOE = CoreStaticDataManager.instance().GetSkillDataByName (str).m_IsAOE;
		aaa.AOERange = CoreStaticDataManager.instance().GetSkillDataByName (str).m_AOERange;
		aaa.AOERangeUpgrade = CoreStaticDataManager.instance().GetSkillDataByName (str).m_AOERangeUpgrade;
		aaa.AttackNum = CoreStaticDataManager.instance().GetSkillDataByName (str).m_AttackNum;
		aaa.AttackNumUpgrade = CoreStaticDataManager.instance().GetSkillDataByName (str).m_AttackNumUpgrade;
		aaa.LastTime = CoreStaticDataManager.instance().GetSkillDataByName (str).m_LastTime;
		aaa.LastTimeUpgrade = CoreStaticDataManager.instance().GetSkillDataByName (str).m_LastTimeUpgrade;
		aaa.CD = CoreStaticDataManager.instance().GetSkillDataByName (str).m_CD;
		aaa.CDDown = CoreStaticDataManager.instance().GetSkillDataByName (str).m_CDDown;
		aaa.CoinCost = CoreStaticDataManager.instance().GetSkillDataByName (str).m_CoinCost;
		aaa.SlowDown = CoreStaticDataManager.instance().GetSkillDataByName (str).m_SlowDown;
		aaa.SlowDownUpgrade = CoreStaticDataManager.instance().GetSkillDataByName (str).m_SlowDownUpgrade;
		aaa.Stars = CoreStaticDataManager.instance().GetSkillDataByName (str).m_Stars;
		aaa.StartsUpgrade = CoreStaticDataManager.instance().GetSkillDataByName (str).m_StarsUpgrade;
		return aaa;
	}
}
