using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIGameContrl : MonoBehaviour
{
	public CalculationShow CS_Coins;
	public CalculationShow CS_Lifes;
	public GameObject g_TowerBuild;
	public GameObject g_TowerOpre;
	public GameObject g_GameResult;
	public GameObject g_Mission;
	public GameObject g_NextLevel;
	public GameObject g_TowerInfor;
	public GameObject g_NoCoinTips;
    public Transform QuitParentRoot;
    public GameObject g_Quit;
    public GameObject g_Loading;
    public GameObject[] g_Skills;
    public GameObject[] g_TowerIcons;
    public Text t_TowerName;
	public Text t_TowerCoins;
	public Text t_TowerAttack;
	GameObject Tower;
	TowerAttribute tab = new TowerAttribute();
	TowerSelfContrl tsc = new TowerSelfContrl ();
	BuildTower buildtower;
	public Image GameResult;
	public Image Star1;
	public Image Star2;
	public Image Star3;
	public Sprite s_DarkStar;
	public Sprite s_LightStar;
	public Sprite s_Victory;
	public Sprite s_Lose;
	public Sprite s_Victory_EN;
	public Sprite s_Lose_EN;
	public Image MissionStar1;
	public Image MissionStar2;
	public Image MissionStar3;
	public Text MissionText1;
	public Text MissionText2;
	public Text MissionText3;
	public Image Firecd;
	public Image Tornadocd;
	public Image Swampcd;
	public Image Duwucd;
	public Image Mission1Icon;
	public Image Mission2Icon;
	public Image Mission3Icon;
	public Text Mission1Infor;
	public Text Mission2Infor;
	public Text Mission3Infor;

    public Text SkillName;
    public static bool IsGazeTower = false;

    public enum CurrentShowUI
    {
        SkillUI,
        BuildTowerUI,
        DismantleTowerUI,
    }
    public static CurrentShowUI m_currentshowUI = CurrentShowUI.SkillUI;
    int TowerIconNum = 0;
	/// <summary>
	/// 显示建塔界面
	/// </summary>
	/// <param name="bt">Bt.</param>
	public void ShowTowerBuild(BuildTower bt)
	{
        buildtower = bt;
        IsGazeTower = bt.IsGazed;
        g_TowerOpre.SetActive (false);
		g_TowerBuild.SetActive (true);
		g_TowerBuild.transform.position = bt.TowerPos + Vector3.up*1f;
        Debug.Log("g_TowerBuild.name ="+ g_TowerBuild.name+ " g_TowerBuild.transform.position ="+ g_TowerBuild.transform.position+ "   TowerBuild "+ g_TowerBuild.activeSelf);
        ChooseBuildTowerIcon(0);
        ShowTowerInfor(TowerIconNum + 1);
        m_currentshowUI = CurrentShowUI.BuildTowerUI;
       // CancelInvoke("SetBuildTowerState");
      //  Invoke("SetBuildTowerState",0.01f);
    }

    void SetBuildTowerState()
    {
        m_currentshowUI = CurrentShowUI.BuildTowerUI;
    }

    public void TurnLeftBuildUI()
    {
        IsPressLeft = true;
        Invoke("ResetPressLeft", 0.2f);
        IsPressRight = false;
        TowerIconNum--;
        if (TowerIconNum < 0)
            TowerIconNum = 3;
        ChooseBuildTowerIcon(TowerIconNum);
        ShowTowerInfor(TowerIconNum + 1);
    }
    public void TurnRightBuildUI()
    {
        IsPressRight = true;
        Invoke("ResetPressRight", 0.2f);
        IsPressLeft = false;
        TowerIconNum++;
        if (TowerIconNum > 3)
            TowerIconNum = 0;
        ChooseBuildTowerIcon(TowerIconNum);
        ShowTowerInfor(TowerIconNum+1);
    }
    void ChooseBuildTowerIcon(int num)
    {
        TowerIconNum = num;
        for (int a=0;a<g_TowerIcons.Length;a++)
        {
            g_TowerIcons[a].SetActive(false);
        }
        g_TowerIcons[num].SetActive(true);
    }
	/// <summary>
	/// 建塔
	/// </summary>
	/// <param name="type">Type.</param>
	public void BuildTower(int type)
	{
        AudioContrl.GetInstance ().PlayAudio ("ClickUI");
		if (!buildtower.CanBuild || m_currentshowUI != CurrentShowUI.BuildTowerUI)
			return;
		GameContrl.GetInstance.towercontrl.SetCurrentTowerAB ((TowerType)(type));
		tab = GameContrl.CurrentChoosedTowerAttribute;
		if (tab.BuildPrice > GameContrl.GetInstance.Coins)
		{
			//显示金币不足，无法造塔
			g_NoCoinTips.SetActive(true);
			return;
		}
		else
		{
			g_TowerBuild.SetActive (false);
			GameContrl.GetInstance.Coins -= tab.BuildPrice;
			GameContrl.GetInstance.UpdateCoins ();
		}
        m_currentshowUI = CurrentShowUI.SkillUI;
        AudioContrl.GetInstance ().PlayAudio ("Build");
		Tower = Instantiate (GameContrl.GetInstance.g_BuildTower[type],buildtower.TowerPos,Quaternion.identity);
		Tower.GetComponent<TowerSelfContrl> ().GetAttribute (tab,buildtower);
		Instantiate (GameContrl.GetInstance.BuildEffect,buildtower.TowerPos,Quaternion.identity);
        Tower.transform.parent = TerrainControl.GetInstance.Buildings;

        GameContrl.m_TowerAll.Add(Tower.GetComponent<TowerSelfContrl>());
        GameContrl.TowerNum++;
		GameContrl.GetInstance.uigamecontrl.UpdateShowMission ();
		buildtower.CanBuild = false;
	}
	/// <summary>
	/// 关闭建塔界面
	/// </summary>
	public void CloseTowerBuild()
	{
        m_currentshowUI = CurrentShowUI.SkillUI;
        AudioContrl.GetInstance ().PlayAudio ("ClickUI");
        g_TowerBuild.SetActive (false);
	}
	/// <summary>
	/// 升级塔
	/// </summary>
	public void UpgradeTower()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
		if(GameContrl.GetInstance.Coins >= tsc.towerAt.BuildPrice + tsc.level*2)
		{
			GameContrl.GetInstance.Coins -= tsc.towerAt.BuildPrice + tsc.towerAt.BuildPrice + tsc.level * 2;
			GameContrl.GetInstance.UpdateCoins ();
			Instantiate (GameContrl.GetInstance.BuildEffect,buildtower.TowerPos,Quaternion.identity);
			tsc.level += 1;
		}
	}


	/// <summary>
	/// 显示塔属性
	/// </summary>
	/// <param name="towerId">Tower identifier.</param>
	public void ShowTowerInfor(int towerId)
	{
		if(towerId == 1)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				t_TowerName.text = "Arrow Tower";
			else
				t_TowerName.text = "铁箭塔";
			t_TowerCoins.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("IronTower").BuildPrice.ToString();
			t_TowerAttack.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("IronTower").AttackNum.ToString ();
		}
		else if(towerId == 2)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				t_TowerName.text = "Tesla Tower";
			else
				t_TowerName.text = "雷电塔";
			
			t_TowerCoins.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("LightningTower").BuildPrice.ToString();
			t_TowerAttack.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("LightningTower").AttackNum.ToString ();
		}
		else if(towerId == 3)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				t_TowerName.text = "Frost Tower";
			else
				t_TowerName.text = "冰霜塔";
			
			t_TowerCoins.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("IceTower").BuildPrice.ToString();
			t_TowerAttack.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("IceTower").AttackNum.ToString ();
		}
		else if(towerId == 4)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				t_TowerName.text = "Flame Tower";
			else
				t_TowerName.text = "火焰塔";
			
			t_TowerCoins.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("FlameTower").BuildPrice.ToString();
			t_TowerAttack.text = GameContrl.GetInstance.towercontrl.GetTowerAttribute ("FlameTower").AttackNum.ToString ();
		}
		g_TowerInfor.SetActive (true);
	}

	public void DismissTowerInfor()
	{
        if (!g_TowerInfor.activeInHierarchy)
            return;
        g_TowerInfor.SetActive (false);
	}

	/// <summary>
	/// 选择技能
	/// </summary>
	/// <param name="num">Number.</param>
	public void ReleaseSkills(int num)
	{
        switch (num)
        {
            case 0:
                if (Application.systemLanguage == SystemLanguage.English)
                    SkillName.text = "Fireball";
                else
                    SkillName.text = "火 球 术";
                break;
            case 1:
                if (Application.systemLanguage == SystemLanguage.English)
                    SkillName.text = "Tornado";
                else
                    SkillName.text = "龙 卷 风";
                break;
            case 2:
                if (Application.systemLanguage == SystemLanguage.English)
                    SkillName.text = "Gooey Blob";
                else
                    SkillName.text = "沼 泽 术";
                break;
            case 3:
                if (Application.systemLanguage == SystemLanguage.English)
                    SkillName.text = "Cloudkill";
                else
                    SkillName.text = "毒 雾 术";
                break;
        }
        if (!GameContrl.IsPlaying)
            return;
        AudioContrl.GetInstance ().PlayAudio ("ClickUI");
        for (int a=0;a<g_Skills.Length;a++)
        {
            g_Skills[a].SetActive(false);
        }
        g_Skills[num].SetActive(true);
		GameContrl.ChoosedSkillType = (SkillsType)(num);
		GameContrl.GetInstance.skillcontrl.SetCurrentSkillAB (GameContrl.ChoosedSkillType);
	}
    
	/// <summary>
	/// 返回主界面
	/// </summary>
	public void BackMenu()
	{
        AudioContrl.GetInstance ().PlayAudio ("ClickUI");
        GameContrl.LoadingSceneName = "MainMenu";
        StartCoroutine("AsyncLoad");
    }

    IEnumerator AsyncLoad()
    {
        this.transform.parent.gameObject.SetActive(false);
        TipsManager.m_bIsLoading = true;
        AsyncOperation op = SceneManager.LoadSceneAsync("Loading");
        while (!op.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("Loading");
    }
	/// <summary>
	/// 重新开始游戏
	/// </summary>
	public void AgainGame()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
        //SceneManager.LoadScene("Game");
        GameContrl.LoadingSceneName = "Game";
        StartCoroutine("AsyncLoad");
    }
	/// <summary>
	/// 下一关
	/// </summary>
	public void NextLevel()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
		GameContrl.CurrentLevel++;
        GameContrl.LoadingSceneName = "Game";
        StartCoroutine("AsyncLoad");
    }

	/// <summary>
	/// 显示游戏结果
	/// </summary>
	/// <param name="aa">Aa.</param>
	public void ShowResult(int aa)
	{
        GameContrl.m_bIsShowAwl = false;
        if (aa == 0)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				GameResult.sprite = s_Lose_EN;
			else
				GameResult.sprite = s_Lose;
		}
		else if(aa == 1)
		{
			if(Application.systemLanguage == SystemLanguage.English)
				GameResult.sprite = s_Victory_EN;
			else
				GameResult.sprite = s_Victory;
		}
	}
	/// <summary>
	/// 显示星星亮暗
	/// </summary>
	/// <param name="bb">Bb.</param>
	public void ShowStars(int bb)
	{
		if(bb == 0)
		{
			Star1.sprite = s_DarkStar;
			Star2.sprite = s_DarkStar;
			Star3.sprite = s_DarkStar;
		}
		else if(bb == 1)
		{
			Star1.sprite = s_LightStar;
			Star2.sprite = s_DarkStar;
			Star3.sprite = s_DarkStar;
		}
		else if(bb == 2)
		{
			Star1.sprite = s_LightStar;
			Star2.sprite = s_LightStar;
			Star3.sprite = s_DarkStar;
		}
		else if(bb == 3)
		{
			Star1.sprite = s_LightStar;
			Star2.sprite = s_LightStar;
			Star3.sprite = s_LightStar;
		}
	}
	/// <summary>
	/// 重置任务星星
	/// </summary>
	public void ResetMissionsStars()
	{
		MissionStar1.sprite = s_DarkStar;
		MissionStar2.sprite = s_DarkStar;
		MissionStar3.sprite = s_DarkStar;
		if(Application.systemLanguage == SystemLanguage.English)
		{
			MissionText1.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].x];
			MissionText2.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].y];
			MissionText3.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].z];
		}
		else
		{
			MissionText1.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].x];
			MissionText2.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].y];
			MissionText3.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].z];
		}

	}
	public void ShowStar1()
	{
		MissionStar1.sprite = s_LightStar;
	}
	public void ShowStar2()
	{
		MissionStar2.sprite = s_LightStar;
	}
	public void ShowStar3()
	{
		MissionStar3.sprite = s_LightStar;
	}

/// <summary>
/// 初始化任务图标显示
/// </summary>
	public void InitMissionShow()
	{
		Mission1Icon.sprite = GameContrl.GetInstance.missioncontrl.MissionIcon[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].x];
		Mission2Icon.sprite = GameContrl.GetInstance.missioncontrl.MissionIcon[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].y];
		Mission3Icon.sprite = GameContrl.GetInstance.missioncontrl.MissionIcon[(int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].z];
		UpdateShowMission ();
	}
    /// <summary>
    /// 更新显示任务
    /// </summary>
	public void UpdateShowMission()
	{
		ShowMission ((int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].x,1);
		ShowMission ((int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].y,2);
		ShowMission ((int)MissionContrl.MissionNumByLevel[GameContrl.CurrentLevel].z,3);
	}
	string aaa;
	void ShowMission(int MissionNum,int Oder)
	{
		
		switch(MissionNum)
		{
		case 1:
			aaa = GameContrl.KillMonsterNum.ToString () + " / " + GameContrl.GetInstance.TotalMonsterNum.ToString ();
			break;
		case 2:
			aaa = GameContrl.GetInstance.LeftLifeNum.ToString() + " / " + "10";
			break;
		case 3:
			aaa = GameContrl.GetInstance.LeftLifeNum.ToString() + " / " + "15";
			break;
		case 4:
			aaa = GameContrl.TowerNum.ToString() + " / " + "0";
			break;
		case 5:
			aaa = GameContrl.KillGoblinNum.ToString() + " / " + "20";
			break;
		case 6:
			aaa = GameContrl.KillGoblinNum.ToString() + " / " + "25";
			break;
		case 7:
			aaa = GameContrl.KillWitchNum.ToString() + " / " + "3";
			break;
		case 8:
			aaa = GameContrl.KillWitchNum.ToString() + " / " + "4";
			break;
		case 9:
			aaa = GameContrl.KillWitchNum.ToString() + " / " + "5";
			break;
		case 10:
			aaa = GameContrl.KillRidingGoblinNum.ToString() + " / " + "6";
			break;
		case 11:
			aaa = GameContrl.KillRidingGoblinNum.ToString() + " / " + "10";
			break;
		case 12:
			aaa = GameContrl.KillRidingGoblinNum.ToString() + " / " + "12";
			break;
		case 13:
			aaa = GameContrl.KillSkeletonNum.ToString() + " / " + "4";
			break;
		case 14:
			aaa = GameContrl.KillSkeletonNum.ToString() + " / " + "8";
			break;
		case 15:
			aaa = GameContrl.KillSkeletonNum.ToString() + " / " + "12";
			break;
		case 16:
			aaa = GameContrl.KillMountainGiantNum.ToString() + " / " + "2";
			break;
		case 17:
			aaa = GameContrl.KillMountainGiantNum.ToString() + " / " + "3";
			break;
		case 18:
			aaa = GameContrl.KillMountainGiantNum.ToString() + " / " + "4";
			break;
		}
		if(Oder == 1)
		{
			Mission1Infor.text = aaa;
		}
		else if(Oder == 2)
		{
			Mission2Infor.text = aaa;
		}
		else if(Oder == 3)
		{
			Mission3Infor.text = aaa;
		}
	}

	bool IsShowMission = false;


	public void OnPressDown()
    {
        if (!IsShowMission)
        {
            IsShowMission = true;
            g_Mission.SetActive(true);
        }
        else if (IsShowMission)
        {
            IsShowMission = false;
            g_Mission.SetActive(false);
        }
    }
    public bool IsShowQuit = false;
    public void NoQuit()
    {
        Time.timeScale = 1;
        AudioContrl.GetInstance().PlayAudio("ClickUI");
        g_Quit.SetActive(false);
        IsShowQuit = false;
        IsCanCheck = true;
        GameContrl.instance.IsCanCheck = IsCanCheck;
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
        AudioContrl.GetInstance().PlayAudio("ClickUI");
        BackMenu();
    }
    int skillNum = 0;
    bool IsPressLeft = false;
    bool IsPressRight = false;
    bool IsCanCheck = true;
    RaycastHit hit01;
    RaycastHit hit;
    LayerMask mask = (1 << 5);
    LayerMask masktower = (1 << 12);
    void FixedUpdate()
    {
        if (m_currentshowUI == CurrentShowUI.BuildTowerUI && IsCanCheck)
        {
            if (Physics.Raycast(GameContrl.GetInstance.t_MainCamera.position, GameContrl.GetInstance.t_MainCamera.forward, out hit, 2000, mask))
            {
                if (hit.collider.CompareTag("TowerUI"))
                {
                    GameContrl.m_eCurReticleFoceState = eReticleFoceState.eFoceBase;
                }
                else
                {
                    GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
                }
            }
        }
        if (m_currentshowUI == CurrentShowUI.DismantleTowerUI && IsCanCheck)
        {
            if (Physics.Raycast(GameContrl.GetInstance.t_MainCamera.position, GameContrl.GetInstance.t_MainCamera.forward, out hit, 2000, masktower))
            {
                if (hit.collider.CompareTag("TowerCollider"))
                {
                    GameContrl.m_bIsShowAwl = true;
                    GameContrl.m_eCurReticleFoceState = eReticleFoceState.eFoceTower;
                    Debug.Log("TowerCheck");
                    if ((Input.GetButtonUp("joystick button 0") || Input.GetMouseButtonDown(0)))
                    {
                        Debug.Log("111");
                        if (Physics.Raycast(GameContrl.GetInstance.t_MainCamera.position, GameContrl.GetInstance.t_MainCamera.forward, out hit01, 2000, masktower))
                        {
                            if (hit.collider.CompareTag("TowerCollider"))
                            {
                                hit01.transform.parent.gameObject.GetComponent<TowerSelfContrl>().ShowTowerOpre();
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("2222");
                    GameContrl.m_bIsShowAwl = false;
                    GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
                }
            }
            else
            {
                GameContrl.m_bIsShowAwl = false;
                GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
            }
        }
    }
    void LateUpdate()
    {
        if (!GameContrl.IsPlaying)
            return;
        if ((Input.GetButtonDown("joystick button 3")||Input.GetKeyDown(KeyCode.X))&& IsCanCheck)
        {
            if (m_currentshowUI == CurrentShowUI.BuildTowerUI)
            {
                Debug.LogWarning("CloseTowerBuild");
                CloseTowerBuild();
                GameContrl.m_bIsShowAwl = false;
            }
            m_currentshowUI = CurrentShowUI.DismantleTowerUI;
            GameContrl.GetInstance.g_Dismantle.SetActive(true);
        }
        if (TipsManager.m_bIsFindMarker && (Input.GetButtonDown("joystick button 1") || Input.GetKeyDown(KeyCode.Escape)))
        {
            Debug.Log(IsShowQuit);

            if (m_currentshowUI == CurrentShowUI.BuildTowerUI)
            {
                Debug.LogWarning("CloseTowerBuild");
                CloseTowerBuild();
                GameContrl.m_bIsShowAwl = false;
            }
            else if (m_currentshowUI == CurrentShowUI.DismantleTowerUI)
            {
                Debug.Log("DismantleTowerUI");
                GameContrl.m_bIsShowAwl = false;
                m_currentshowUI = CurrentShowUI.SkillUI;
                GameContrl.GetInstance.g_Dismantle.SetActive(false);
            }
            else if (!IsShowQuit && GameContrl.IsPlaying)
            {
                Debug.Log("Quit");

              //  if (!TipsManager.m_bIsFindMarker)
               // {
             //      // g_Quit.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
                   // g_Quit.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
                   // g_Quit.transform.localScale = Vector3.one;
              //  }
              //  else
              //  {
                    g_Quit.transform.localPosition = Vector3.zero;
                    g_Quit.transform.localRotation = Quaternion.identity;
                    g_Quit.transform.localScale = Vector3.one;
               // }

                IsCanCheck = false;
                IsShowQuit = true;
                GameContrl.instance.IsCanCheck = IsCanCheck;
                g_Quit.SetActive(true);
                Time.timeScale = 0;
            }
            else if (IsShowQuit)
            {
                Debug.Log("NoQuit");
                NoQuit();
            }
        }
        if ((Input.GetAxisRaw("Horizontal") < 0 || (Input.GetKeyDown(KeyCode.A))) && !IsPressLeft && IsCanCheck)
        {
          if (m_currentshowUI == CurrentShowUI.BuildTowerUI)
              TurnLeftBuildUI();
          else if (m_currentshowUI == CurrentShowUI.SkillUI)
              TurnLeft();
        }
        if ((Input.GetAxisRaw("Horizontal") > 0 || (Input.GetKeyDown(KeyCode.D)))&& !IsPressRight && IsCanCheck)
        {
           if (m_currentshowUI == CurrentShowUI.BuildTowerUI)
              TurnRightBuildUI();
            else if (m_currentshowUI == CurrentShowUI.SkillUI)
              TurnRight();
        }
        if (InputManager.Instance.IsClickOkButton() && IsCanCheck)
        {
            switch (m_currentshowUI)
            {
                case CurrentShowUI.SkillUI:
                    switch (GameContrl.m_eCurReticleFoceState)
                    {
                        case eReticleFoceState.eFoceTerrain:
                            //释放技能
                            
                            break;
                        case eReticleFoceState.eFoceBase:
                            //打开炮塔
                            break;
                        default:
                            //无效
                            break;
                    }
                    GameContrl.m_bIsShowAwl = false;
                    break;
                case CurrentShowUI.BuildTowerUI:
                    switch (GameContrl.m_eCurReticleFoceState)
                    {
                        case eReticleFoceState.eFoceBase:
                            //建塔
                            BuildTower(TowerIconNum);
                            break;
                        default:
                            //关闭建塔
                            CloseTowerBuild();
                            break;
                    }
                    GameContrl.m_bIsShowAwl = false;
                    break;
                case CurrentShowUI.DismantleTowerUI:
                    switch (GameContrl.m_eCurReticleFoceState)
                    {
                        case eReticleFoceState.eFoceTower:
                            //对准塔
                            //Debug.LogError("$$$$$$$$$$$$1111 = " + GameContrl.m_eCurReticleFoceState);
                            break;
                        default:
                            //
                            //Debug.LogError("$$$$$$$$$$$$2222 = " + GameContrl.m_eCurReticleFoceState);
                            m_currentshowUI = CurrentShowUI.SkillUI;
                            GameContrl.GetInstance.g_Dismantle.SetActive(false);
                            break;
                          
                    }
                    GameContrl.m_bIsShowAwl = false;
                    break;
                default:
                    Debug.LogError("当前游戏CurrentShowUI状态不明显,请核实");
                    break;
            }
        }
    }

    public void TurnLeft()
    {
        IsPressLeft = true;
        Invoke("ResetPressLeft", 0.6f);
        IsPressRight = false;
        skillNum -= 1;
        if (skillNum < 0)
            skillNum = 3;
        ReleaseSkills(skillNum);
    }
    public void TurnRight()
    {
        IsPressRight = true;
        Invoke("ResetPressRight", 0.6f);
        IsPressLeft = false;
        skillNum += 1;
        if (skillNum > 3)
            skillNum = 0;
        ReleaseSkills(skillNum);
    }

    void ResetPressLeft()
    {
        IsPressLeft = false;
    }
    void ResetPressRight()
    {
        IsPressRight = false;
    }
}
