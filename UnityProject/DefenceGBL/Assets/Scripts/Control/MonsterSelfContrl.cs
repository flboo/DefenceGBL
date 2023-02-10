using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelfContrl : MonoBehaviour {

	public List<TowerSelfContrl> towerselfContrls;

	public MonsterType monstertype;
	public int HP;
	public int InitHP;
	public Transform Eff_point_pelvis;
	public Transform Eff_point_head;

	public bool Alife;
	MonsterAttribute MonsterAb = new MonsterAttribute ();
//c起终点
	private Transform StartPos;
    private Transform TargetPos;
	private Transform MiddleTargetPos01;
	private Transform MiddleTargetPos02;
	private Animator m_animator;

	public int RunLine;

	public Transform BloodBar;
    public UI_HP NGUIHP;

	public SkinnedMeshRenderer skinSelf;
	public Material MaterialSelf;
	public Material MaterialIce;
	private AudioSource m_audiosource;

	void Awake()
	{
		m_audiosource = GetComponent<AudioSource> ();
		m_animator = GetComponent<Animator> ();
		RunLine = Random.Range (0, 2);
	}
	void Start ()
	{
		StartPos = GameContrl.GetInstance.monstercontrl.StartPos;
		TargetPos = GameContrl.GetInstance.monstercontrl.TargetPos;
		MiddleTargetPos01 = GameContrl.GetInstance.monstercontrl.MiddleTargetPos01;
		MiddleTargetPos02 = GameContrl.GetInstance.monstercontrl.MiddleTargetPos02;
		if(GameContrl.CurrentLevel == 1 || GameContrl.CurrentLevel == 5 || GameContrl.CurrentLevel == 3)
		{
			if(RunLine == 0)
			{
				reSetSelfTargetPos (MiddleTargetPos01);
			}
		}
	}



	void Update () 
	{
		if(GameContrl.CurrentLevel == 1)
		{
            if (Vector3.Distance(transform.position,MiddleTargetPos01.position) < 0.3f) 
			{
				reSetSelfTargetPos (TargetPos);
			}
		}
		else if(GameContrl.CurrentLevel == 3)
		{
			if (Vector3.Distance(transform.position,MiddleTargetPos01.position) < 0.3f) 
			{
				transform.position = new Vector3(-4.5f, 4.15f, 2.5f);
				reSetSelfTargetPos (MiddleTargetPos02);
			}
			if (Vector3.Distance(transform.position,MiddleTargetPos02.position) < 0.3f) 
			{
				transform.position = new Vector3(-3f, 1.15f, 6.5f);
				reSetSelfTargetPos (TargetPos);
			}
		}
		else if(GameContrl.CurrentLevel == 5)
		{
			if (Vector3.Distance(transform.position,MiddleTargetPos01.position) < 0.3f) 
			{
				reSetSelfTargetPos (MiddleTargetPos02);
			}
			if (Vector3.Distance(transform.position,MiddleTargetPos02.position) < 0.3f) 
			{
				reSetSelfTargetPos (TargetPos);
			}
		}

		if(GameContrl.IsPlaying == false)
		{
			SetMonsterSpeed (0);
		}
	}

	void OnDisable()
	{
		towerselfContrls.Clear();
	}
	/// <summary>
	/// 怪物受到伤害
	/// </summary>
	/// <param name="attacknum">Attacknum.</param>
	GameObject ga;
	public void GetAttack(int attacknum)
	{
		HP -= attacknum;
		if(HP <= 0 && Alife)
		{
			Alife = false;
			//怪物死去
			ga = Instantiate(GameContrl.GetInstance.monstercontrl.Eff_Dead,Vector3.zero,Quaternion.identity,Eff_point_pelvis) as GameObject;
			ga.transform.localPosition = Vector3.zero;

			for(int a=0;a<towerselfContrls.Count;a++)
			{
				towerselfContrls [a].RemoveMonsterContrl (this);
			}
			if(m_audiosource.clip != null)
				m_audiosource.Play ();

			GameContrl.GetMonsterNum++;
            GameContrl.KillMonsterNum++;

            Debug.Log("MonsterNum  " + "怪物死亡*1,一共死亡了： " + GameContrl.KillMonsterNum + "当前一共死亡或者逃逸了： " + GameContrl.GetMonsterNum);

            if (monstertype == MonsterType.Goblin)
			{
				GameContrl.KillGoblinNum++;
			}
			else if(monstertype == MonsterType.Witch)
			{
				GameContrl.KillWitchNum++;
			}
			else if(monstertype == MonsterType.RidingGoblin)
			{
				GameContrl.KillRidingGoblinNum++;
			}
			else if(monstertype == MonsterType.Skeleton)
			{
				GameContrl.KillSkeletonNum++;
			}
			else if(monstertype == MonsterType.Giant)
			{
				GameContrl.KillMountainGiantNum++;
			}
			Invoke ("DestoryLast",0.2f);
		}

		if (HP <= 0)
		{
			HP = 0;
		}

        NGUIHP.CheckHP(HP, InitHP);

        //float aaabbb = (float)((HP*0.1f) / (InitHP*0.1f));
        //BloodBar.localScale = new Vector3 (aaabbb,1f,1f);
        //BloodBar.localPosition = new Vector3 ((1-aaabbb)*0.5f,BloodBar.localPosition.y,BloodBar.localPosition.z);
    }

	void DestoryLast()
	{
		CancelInvoke ();
		Instantiate (GameContrl.GetInstance.g_Coins,this.transform.position+Vector3.up*0.5f,Quaternion.identity,TerrainControl.GetInstance.Buildings);
		Destroy (ga);
		for(int a=0;a<towerselfContrls.Count;a++)
		{
			towerselfContrls [a].RemoveMonsterContrl (this);
		}
		GameContrl.GetInstance.uigamecontrl.UpdateShowMission ();
		RecoveryFrozen ();
		RecoveryVertigo ();
		gameObject.transform.position = new Vector3 (100,100,100);
		gameObject.SetActive (false);

    }
	/// <summary>
	/// 怪物受到持续伤害
	/// </summary>
	int Continued_attack;
	int Continued_time;
	public void GetContinuedAttack(int attack,int time)
	{
		Continued_attack = attack;
		Continued_time = time;
		StartCoroutine (ContinuedAttack());
	}
	IEnumerator ContinuedAttack()
	{
		for(int a=0;a<Continued_time;a++)
		{
			GetAttack (Continued_attack);
			yield return new WaitForSeconds (1f);
		}
	}


	public void AddTowerSelfContrl(TowerSelfContrl tsc)
	{
		towerselfContrls.Add (tsc);
	}
	public void RemoveTowerSelfContrl(TowerSelfContrl tsc)
	{
		towerselfContrls.Remove (tsc);
	}

	/// <summary>
	/// 初始化怪物自身
	/// </summary>
	public void InitMonsterSelf()
	{
		GetMonsterAttribute (monstertype);
		HP = MonsterAb.HP;
		InitHP = MonsterAb.HP;
        NGUIHP.transform.GetChild(0).gameObject.SetActive(false);
		//BloodBar.localScale = new Vector3 (1f,1f,1f);
		//BloodBar.localPosition = new Vector3 (0,0,10);
		Alife = true;
	}


	private MonsterAttribute GetMonsterAttribute(string str)
	{
		MonsterAttribute Monsteraa = new MonsterAttribute ();
		Monsteraa.name = CoreStaticDataManager.instance().GetMonsterDataByName (str).m_Name;
		Monsteraa.HP = CoreStaticDataManager.instance().GetMonsterDataByName (str).m_HP;
		Monsteraa.Speed = CoreStaticDataManager.instance().GetMonsterDataByName (str).m_Speed;
		return Monsteraa;
	}

    void GetMonsterAttribute(MonsterType mt)
    {
        switch (mt)
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
    }

	/// <summary>
	/// 设置小怪自身的速度
	/// </summary>
	/// <param name="ssspeed">Ssspeed.</param>
	public void SetMonsterSpeed(float ssspeed)
	{
		transform.GetComponent<AIPath>().speed = ssspeed;
	}
	public float GetMonsterSpeed()
	{
		return transform.GetComponent<AIPath> ().speed;
	}
	/// <summary>
	/// 重新朝向一个新的目标位置移动
	/// </summary>
	/// <param name="Pos">Position.</param>
	public void reSetSelfTargetPos(Transform Pos)
	{
		transform.GetComponentInChildren<AIPath>().target = Pos;
		transform.GetComponentInChildren<Seeker>().StartPath (transform.position, Pos.position);
	}


	float PreSpeed;
	/// <summary>
	/// 定身
	/// </summary>
	public void Vertigo(float ctime,float Discount)
	{
		PreSpeed = GetMonsterSpeed();
		SetMonsterSpeed (PreSpeed*(1-Discount));
		Invoke ("RecoveryVertigo",ctime);
	}

	void RecoveryVertigo()
	{
		m_animator.SetBool ("Walk",true);
		SetMonsterSpeed (PreSpeed);	
	}

	public void Frozen(float ctime)
	{
		skinSelf.material = MaterialIce;
		Invoke ("RecoveryFrozen",ctime);
	}

	void RecoveryFrozen()
	{
		skinSelf.material = MaterialSelf;
	}

	public void ShowLightEffect()
	{
		Instantiate (GameContrl.GetInstance.g_ELight, Eff_point_head.position, Quaternion.identity,Eff_point_head);
	}

	public void ShowBurningEffect()
	{
		Instantiate (GameContrl.GetInstance.g_EBlast, Eff_point_pelvis.position, Quaternion.identity,Eff_point_pelvis);
		Instantiate (GameContrl.GetInstance.g_EBurn, Eff_point_pelvis.position, Quaternion.identity,Eff_point_pelvis);
	}

}
