using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterContrl : MonoBehaviour {

	//小怪行走的起终点(传送门)
	public  Transform StartPos;
	//传送门2(怪物消失点)
	public  Transform TargetPos;
	public Transform MiddleTargetPos01;
	public Transform MiddleTargetPos02;
	public Transform EndMonster;
    /// <summary>
    /// 第一种小怪
    /// </summary>
	public GameObject MonstersOnePrefab;
	//每一种小怪在池子中生成的数量
	private int[] MonstersOneCount = 
    {
		33,
		25,
		15,
		20,
		15,
	};
	//小怪的预设体
	public GameObject[] MonsterPrefabs;
	//池子
	public Transform[] MonsterPools;
	//是否达到创建小怪的条件
	public bool isArriveCreatMonsterTerm=false;
	//小怪行走的速度
	public float Speed=0.8f;

	public GameObject Eff_Dead;

	CreatMonsterData cmd = new CreatMonsterData();
	void Start()
	{
		//创建池子
		CreatMonstarPool();
		cmd = CoreStaticDataManager.instance ().GetCreateMonsterDataByName("level" + GameContrl.CurrentLevel.ToString());
	}

	void Update()
	{
		if (!GameContrl.IsPlaying) 
		{
			return;
		}
	}


	public void StartCreatMonster()
	{
		StartCoroutine ("CreatMonster");
	}
	MonsterBand mband = new MonsterBand();
    IEnumerator CreatMonster()
    {
        yield return new WaitForSeconds(0.3f);
        for (int b = 1; b < cmd.BandNum + 1; b++)
        {
            if (b == 1)
                mband = cmd.mb1;
            else if (b == 2)
                mband = cmd.mb2;
            else if (b == 3)
                mband = cmd.mb3;
            else if (b == 4)
                mband = cmd.mb4;
            CreatMonsterBegin(b);
            yield return new WaitForSeconds(GetPerBigCount(b) * 1 + 15f);
        }
    }
	void CreatMonsterBegin(int Band)
	{
        StartCoroutine (CreatMonster(Band));
	}

    void CheckMonster(GameObject go,int type,bool Flag)
    {
        if (GameContrl.GetInstance.LeftLifeNum <= 0)
            return;

        if (Flag)
        {
            g_Monsters[type].Add(go);
            go.transform.parent = MonsterPools[type].transform;
        }
        go.SetActive(true);
        go.transform.position = StartPos.position;
        go.GetComponent<MonsterSelfContrl>().InitMonsterSelf();
        go.GetComponentInChildren<AIPath>().target = TargetPos;
        go.GetComponentInChildren<Seeker>().StartPath(StartPos.position, TargetPos.position);
        go.GetComponentInChildren<AIPath>().speed = GetMonsterAttribute((MonsterType)(type)).Speed;
        CreatOneFirstMonster++;
    }

	//每一小波创建小怪的数量
	int CreatOneFirstMonster=0;
    IEnumerator CreatMonster(int Band)
    {
       
        for (int i = 0; i < GetPerBigCount(Band); i++)
        {
            //Debug.Log("1");
            bool Flag = true;

            if (i < mband.Monstertype1Num)
            {
                //Debug.Log("2");
                if (i == mband.Monstertype1Num-1)
                {
                    //Debug.Log("2222222222222");
                }

                foreach (GameObject go in g_Monsters[mband.Monstertype1 - 1])
                {
                    if (go.activeInHierarchy == false)
                    {
                        Flag = false;
                        CheckMonster(go, mband.Monstertype1 - 1, Flag);
                        break;
                    }
                }
                if (Flag)
                {
                    GameObject TempModel = (GameObject)Instantiate(MonsterPrefabs[mband.Monstertype1 - 1]);
                    CheckMonster(TempModel, mband.Monstertype1 - 1, Flag);
                }
            }
            else if (i < mband.Monstertype1Num + mband.Monstertype2Num)
            {
                //Debug.Log("3");
                foreach (GameObject go in g_Monsters[mband.Monstertype2 - 1])
                {
                    if (go.activeInHierarchy == false)
                    {
                        Flag = false;
                        CheckMonster(go, mband.Monstertype2 - 1, Flag);
                        break;
                    }
                }
                if (Flag)
                {
                    GameObject TempModel = (GameObject)Instantiate(MonsterPrefabs[mband.Monstertype2 - 1]);
                    CheckMonster(TempModel, mband.Monstertype2 - 1, Flag);
                }
            }
            else if (i < mband.Monstertype1Num + mband.Monstertype2Num + mband.Monstertype3Num)
            {
                
                foreach (GameObject go in g_Monsters[mband.Monstertype3 - 1])
                {
                    if (go.activeInHierarchy == false)
                    {
                        Flag = false;
                        CheckMonster(go, mband.Monstertype3 - 1, Flag);
                        break;
                    }
                }
                if (Flag)
                {
                    GameObject TempModel = (GameObject)Instantiate(MonsterPrefabs[mband.Monstertype3 - 1]);
                    CheckMonster(TempModel, mband.Monstertype3 - 1, Flag);
                }
            }

            yield return new WaitForSeconds(1f);
        }

    }
	private List<GameObject> g_Goblins = new List<GameObject>();
	private List<GameObject> g_RidingGoblins = new List<GameObject>();
	private List<GameObject> g_Witchs = new List<GameObject>();
	private List<GameObject> g_Skeletons = new List<GameObject>();
	private List<GameObject> g_Giants = new List<GameObject>();
	private List<List<GameObject>> g_Monsters = new List<List<GameObject>>(); 
	/// <summary>
	/// 创建小怪池
	/// </summary>
	void CreatMonstarPool()
	{
        g_Giants = new List<GameObject>();
        g_RidingGoblins = new List<GameObject>();
        g_Witchs = new List<GameObject>();
        g_Skeletons = new List<GameObject>();
        g_Giants = new List<GameObject>();

        //for (int a = 0; a < MonsterPools.Length; a++) 
        //{
        //	for (int i = 0; i < MonstersOneCount[a]; i++)
        //	{
        //		GameObject aa = (GameObject)Instantiate (MonsterPrefabs[a]);
        //		aa.transform.parent =MonsterPools[a].transform;
        //		if(a==0)
        //			g_Goblins.Add (aa);	
        //		else if(a==1)
        //			g_RidingGoblins.Add (aa);
        //		else if(a==2)
        //			g_Witchs.Add (aa);
        //		else if(a==3)
        //			g_Skeletons.Add (aa);
        //		else if(a==4)
        //			g_Giants.Add (aa);
        //		aa.SetActive (false );
        //	}
        //}

        g_Monsters.Add (g_Goblins);
		g_Monsters.Add (g_RidingGoblins);
		g_Monsters.Add (g_Witchs);
		g_Monsters.Add (g_Skeletons);
		g_Monsters.Add (g_Giants);
	}

	//重置起终点的位置
	public  void AgainSetStartAndTargetPos(Vector3 startPos,Vector3 targetPos)
	{
		StartPos.position=startPos;
		TargetPos.position = targetPos;
	}
	//获取各个大波所要生成小怪的总数量
	int GetPerBigCount(int band)
	{
		int temp=0;
		if(band == 1)
			temp = cmd.mb1.Monstertype1Num + cmd.mb1.Monstertype2Num + cmd.mb1.Monstertype3Num;
		else if(band == 2)
			temp = cmd.mb2.Monstertype1Num + cmd.mb2.Monstertype2Num + cmd.mb2.Monstertype3Num;
		else if(band == 3)
			temp = cmd.mb3.Monstertype1Num + cmd.mb3.Monstertype2Num + cmd.mb3.Monstertype3Num;
		else if(band == 4)
			temp = cmd.mb4.Monstertype1Num + cmd.mb4.Monstertype2Num + cmd.mb4.Monstertype3Num;
		return temp;
	}

    public void GetLevelAllMonster()
    {
        GameContrl.GetInstance.TotalMonsterNum = cmd.mb1.Monstertype1Num + cmd.mb1.Monstertype2Num + cmd.mb1.Monstertype3Num + cmd.mb2.Monstertype1Num + cmd.mb2.Monstertype2Num
        + cmd.mb2.Monstertype3Num + cmd.mb3.Monstertype1Num + cmd.mb3.Monstertype2Num + cmd.mb3.Monstertype3Num + cmd.mb4.Monstertype1Num + cmd.mb4.Monstertype2Num + cmd.mb4.Monstertype3Num;
        Debug.Log("MonsterNum  " + GameContrl.GetInstance.TotalMonsterNum);
    }

	MonsterAttribute GetMonsterAttribute(string str)
	{
		MonsterAttribute Monsteraa = new MonsterAttribute ();
		Monsteraa.name = CoreStaticDataManager.instance ().GetMonsterDataByName (str).m_Name;
		Monsteraa.HP = CoreStaticDataManager.instance ().GetMonsterDataByName (str).m_HP;
		Monsteraa.Speed = CoreStaticDataManager.instance ().GetMonsterDataByName (str).m_Speed;
		return Monsteraa;
	}

	MonsterAttribute GetMonsterAttribute(MonsterType mt)
	{
		MonsterAttribute MonsterAb = new MonsterAttribute ();
		switch(mt)
		{
		case MonsterType.Goblin:
			MonsterAb = GetMonsterAttribute("Goblin");
			break;
		case MonsterType.RidingGoblin:
			MonsterAb = GetMonsterAttribute("RidingGoblin");
			break;
		case MonsterType.Witch:
			MonsterAb = GetMonsterAttribute("Witch");
			break;
		case MonsterType.Skeleton:
			MonsterAb = GetMonsterAttribute("Skeleton");
			break;
		case MonsterType.Giant:
			MonsterAb = GetMonsterAttribute("Giant");
			break;
		}
		return MonsterAb;
	}
}
