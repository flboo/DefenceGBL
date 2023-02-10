using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContrl : MonoBehaviour {

	public static GameContrl instance = null;
	public static GameContrl GetInstance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.Find ("GameContrl").GetComponent<GameContrl> ();
			}
			return instance;
		}
	}

    public UIGameContrl.CurrentShowUI m_currentshowUI { get; private set; }

    public static float ReticleSize = 1;

    public static string LANGUAGE = "zh";

    public static string LoadingSceneName;

    /// <summary>
    /// 当前拥有金币数量
    /// </summary>
    public int Coins;
	/// <summary>
	/// 当前拥有星星的数量
	/// </summary>
	public static int Stars;
	/// <summary>
	/// 当前关卡
	/// </summary>
	public static int CurrentLevel = 1;

	public static int GetMaxLevel = 0;
	/// <summary>
	/// 某关卡怪物总数量
	/// </summary>
	public int TotalMonsterNum;
	/// <summary>
	/// 剩余生命值
	/// </summary>
	public int LeftLifeNum;
	/// <summary>
	/// 建塔的数量
	/// </summary>
	public static int TowerNum;
	/// <summary>
	/// 杀死哥布林的数量
	/// </summary>
	public static int KillGoblinNum;
	/// <summary>
	/// 杀死女巫的数量
	/// </summary>
	public static int KillWitchNum;
	/// <summary>
	/// 杀死骑狼哥布林的数量
	/// </summary>
	public static int KillRidingGoblinNum;
	/// <summary>
	/// 杀死骷髅怪的数量
	/// </summary>
	public static int KillSkeletonNum;
	/// <summary>
	/// 杀死山巨人的数量
	/// </summary>
	public static int KillMountainGiantNum;
	/// <summary>
	/// 初始化生命值
	/// </summary>
	public int InitLifeNum;
    //逃逸怪物数量
    public static int RunMonsterNum;
	//被打死或者成功脱逃的怪物数量
	public static int GetMonsterNum;
	//被打死的怪物数量
	public static int KillMonsterNum;
	/// <summary>
	/// 是否正在游戏
	/// </summary>
	public static bool IsPlaying;
    /// <summary>
    /// 是否开始建筑
    /// </summary>
    public static bool IsStartBuild;

    public static bool m_bIsShowAwl=false;
	/// <summary>
	/// 当前选中的塔类型
	/// </summary>
	public static TowerType ChoosedTowerType;
	/// <summary>
	/// 当前选中的主角技能类型
	/// </summary>
	public static SkillsType ChoosedSkillType = SkillsType.FireBall;
	/// <summary>
	/// 当前选中的塔的属性
	/// </summary>
	public static TowerAttribute CurrentChoosedTowerAttribute = new TowerAttribute ();
	/// <summary>
	/// 当前选中的技能的属性
	/// </summary>
	public static SkillAttribute CurrentChoosedSkillAttribute = new SkillAttribute ();
	/// <summary>
	/// 当前选中塔的工程
	/// </summary>
	public TowerProgramme ChoosedProgramme;
    /// <summary>
    /// 当前光标所焦距的状态
    /// </summary>
    public static eReticleFoceState m_eCurReticleFoceState= eReticleFoceState.eNone;

    //所以在的塔
    public static List<TowerSelfContrl> m_TowerAll = new List<TowerSelfContrl>();

    /// <summary>
    /// 每关卡怪物血量的升级指数
    /// </summary>
    public float MonsterHPUpgrade = 0.1f;
    /// <summary>
    /// 技能的等级
    /// </summary>Tornado(Clone)
    public static int FireBallLevel;
	public static int TornadoLevel;
	public static int SwampLevel;
	public static int DuwuLevel;

	[HideInInspector]
	public GameObject g_Ponter;
    public Transform t_ERange;

	public Transform t_MainCamera;
	public CameraContrl cameracontrl;
	public MonsterContrl monstercontrl;
	public TowerContrl towercontrl;
	public SkillContrl skillcontrl;
	public MissionContrl missioncontrl;
	public TerrainControl terraincontrl;
	public UIGameContrl uigamecontrl;
	public DataSave datasave;
    public PathNodesLimit pathNodesLimit;
	/// <summary>
	/// 塔的prefab
	/// </summary>
	public GameObject[] g_BuildTower;
	public GameObject BuildEffect;
	public GameObject g_FireBall;
	public GameObject g_Tornado;
	public GameObject g_Swamp;
	public GameObject g_Duwu;

	public GameObject g_EBlast;
	public GameObject g_Ice;
	public GameObject g_ELight;
	public GameObject g_EBurn;
	public GameObject g_Coins;

    public GameObject g_Dismantle;
    public bool IsCanCheck = true;

    void Awake()
	{
        if (t_MainCamera == null) { t_MainCamera = Camera.main.transform; }
		cameracontrl = GameObject.Find ("Player").GetComponent<CameraContrl> ();
		monstercontrl = GetComponent<MonsterContrl> ();
		towercontrl = GetComponent<TowerContrl> ();
		skillcontrl = GetComponent<SkillContrl> ();
		missioncontrl = GetComponent<MissionContrl> ();
		terraincontrl = GetComponent<TerrainControl> ();
		IsPlaying = false;
        IsStartBuild = false;
    }

    void Start()
    {
        NarHandleShake.init();
    }

	void Update()
	{
        if (GetMonsterNum >= TotalMonsterNum && IsPlaying)
        {
            Debug.Log("MonsterNum  " + "胜利界面");
            CheckUIInfor();
            IsPlaying = false;
            Invoke("EndGame", 0.2f);
        }
		if(LeftLifeNum <= 0 && IsPlaying)
		{
            CheckUIInfor();
            IsPlaying = false;
            Invoke("EndGame", 0.2f);
        }
	}

    void CheckUIInfor()
    {
        uigamecontrl.g_TowerBuild.SetActive(false);
    }

    bool m_bIsShaking = false;

    public void SetHandleShake()
    {
        Debug.Log("震动");
        if (!m_bIsShaking)
        {
            NarHandleShake.startVibrate(3, 3);
            m_bIsShaking = true;
            CancelInvoke("CancleSD");
            Invoke("CancleSD", 0.8F);
        }
    }

    public void CancleSD()
    {
        m_bIsShaking = false;
    }

    public void CheckTowerCollider(bool m_Flag)
    {
        for (int i = 0; i < m_TowerAll.Count; i++)
        {
            m_TowerAll[i].gameObject.GetComponent<Collider>().enabled = m_Flag;
        }
    }
		
	/// <summary>
	/// 初始化并开始游戏
	/// </summary>
	public void InitAndStartGame()
	{
		InitLifeNum = 25;
		LeftLifeNum = InitLifeNum;
		TowerNum = 0;
		KillMonsterNum = 0;
		KillWitchNum = 0;
		KillGoblinNum = 0;
		KillRidingGoblinNum = 0;
		KillSkeletonNum = 0;
		KillMountainGiantNum = 0;
		Coins = 20;
		GetMonsterNum = 0;
		GetMissionNum = 0;
		monstercontrl.StartCreatMonster ();
		UpdateCoins ();
		UpdateLifes ();
		IsPlaying = true;
		uigamecontrl.ReleaseSkills (1);
		uigamecontrl.ReleaseSkills (2);
		uigamecontrl.ReleaseSkills (3);
		uigamecontrl.ReleaseSkills (0);
		monstercontrl.GetLevelAllMonster ();
        //Debug.LogError("InitAndStartGame 初始化开始游戏");
		uigamecontrl.ResetMissionsStars ();
		uigamecontrl.InitMissionShow ();
	}
	/// <summary>
	/// 游戏结束结算
	/// </summary>
	int GetMissionNum;

	public void EndGame()
	{
		AudioContrl.GetInstance ().bgAudioSource.Stop ();
		datasave.GetDataSave ();
		if (missioncontrl.MissionByLevel((int)MissionContrl.MissionNumByLevel[CurrentLevel].x)) 
		{
			GetMissionNum++;
			uigamecontrl.ShowStar1 ();
		}
		if (missioncontrl.MissionByLevel((int)MissionContrl.MissionNumByLevel[CurrentLevel].y)) 
		{
			GetMissionNum++;
			uigamecontrl.ShowStar2 ();
		}
		if (missioncontrl.MissionByLevel((int)MissionContrl.MissionNumByLevel[CurrentLevel].z)) 
		{
			GetMissionNum++;
			uigamecontrl.ShowStar3 ();
            
		}

		uigamecontrl.g_GameResult.SetActive (true);

		if(LeftLifeNum > 0)
		{
			//完成任务	
			if(CurrentLevel >= 5)
				uigamecontrl.g_NextLevel.SetActive(false);
			else
				uigamecontrl.g_NextLevel.SetActive(true);
			if(CurrentLevel > GetMaxLevel)
			{
				GameContrl.Stars += GetMissionNum;
				GetMaxLevel = CurrentLevel;
				LevelSelectModel.StarsData [GetMaxLevel] = GetMissionNum;
			}
			else
			{
				if(GetMissionNum > LevelSelectModel.StarsData[GetMaxLevel])
				{
					GameContrl.Stars += GetMissionNum - LevelSelectModel.StarsData [GetMaxLevel];
					LevelSelectModel.StarsData [GetMaxLevel] = GetMissionNum;
				}
			}
			AudioContrl.GetInstance ().PlayAudio ("GameWin");
			uigamecontrl.ShowResult(1);
			uigamecontrl.ShowStars (GetMissionNum);
		}
		else
		{
            IsPlaying = false;
			//任务失败
			uigamecontrl.g_NextLevel.SetActive(false);
			AudioContrl.GetInstance ().PlayAudio ("GameLose");
			uigamecontrl.ShowResult(0);
			uigamecontrl.ShowStars (0);
		}
		datasave.SetDataSave ();
	}
	/// <summary>
	/// 更新金币数量
	/// </summary>
	public void UpdateCoins()
	{
		uigamecontrl.CS_Coins.SetNum (Coins);
	}
	/// <summary>
	/// 更新生命值
	/// </summary>
	public void UpdateLifes()
	{
		uigamecontrl.CS_Lifes.SetNum (LeftLifeNum);
	}
	/// <summary>
	/// 更新金币数量
	/// </summary>
	public void UpdateCoins(int num)
	{
		uigamecontrl.CS_Coins.SetNum (num);
	}
	/// <summary>
	/// 更新生命值
	/// </summary>
	public void UpdateLifes(int num)
	{
		uigamecontrl.CS_Lifes.SetNum (num);
	}
}
