using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
public class TowerSelfContrl : MonoBehaviour {

	public TowerType towertype;
	public List<MonsterSelfContrl> monsterselfContrls;
	private int AttackNum;
	public GameObject p_Bullet;
	private int AttackSpeed;
	private float Intervaltime;
	private float time;
	[HideInInspector]
	public int level;
	[HideInInspector]
	public TowerAttribute towerAt ;
	[HideInInspector]
	public BuildTower buildtower;

	private AudioSource m_audiosource;

	void Awake()
	{
		m_audiosource = GetComponent<AudioSource> ();
		time = Time.time; 
	}

	GameObject buttle;
	void FixedUpdate () 
	{
		if (!GameContrl.IsPlaying)
			return;
		if(Time.time - time >= Intervaltime)
		{
			time = Time.time;
			if(monsterselfContrls.Count > 0)
			{
				buttle = Instantiate (p_Bullet,new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z),Quaternion.identity,TerrainControl.GetInstance.Buildings);
				Bullet c_bullet = buttle.GetComponent<Bullet> ();
				if(monsterselfContrls[0].gameObject != null)
					c_bullet.SetTarget (monsterselfContrls[0].gameObject,AttackNum);
				if(m_audiosource.clip != null)
					m_audiosource.Play ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Goblin") || other.CompareTag("RidingGoblin") || other.CompareTag("Witch") || other.CompareTag("Skeleton") || other.CompareTag("Giant"))
		{
			MonsterSelfContrl mon = other.gameObject.GetComponent<MonsterSelfContrl> ();
			mon.AddTowerSelfContrl (this);
			monsterselfContrls.Add (mon);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Goblin") || other.CompareTag("RidingGoblin") || other.CompareTag("Witch") || other.CompareTag("Skeleton") || other.CompareTag("Giant"))
		{
			MonsterSelfContrl mon = other.gameObject.GetComponent<MonsterSelfContrl> ();
			mon.RemoveTowerSelfContrl (this);
			monsterselfContrls.Remove (mon);
		}
	}
	public void RemoveMonsterContrl(MonsterSelfContrl msc)
	{
		monsterselfContrls.Remove (msc);
	}

	public void GetAttribute(TowerAttribute ta,BuildTower bt)
	{
		towerAt = ta;
		buildtower = bt;
		Intervaltime = 1 / towerAt.AttackSpeed;
		AttackNum = towerAt.AttackNum;
	}

	public void ShowTowerOpre()
	{
		if (!GameContrl.IsPlaying)
			return;
        Debug.Log("#@############# = " + UIGameContrl.m_currentshowUI);
        if (UIGameContrl.m_currentshowUI == UIGameContrl.CurrentShowUI.DismantleTowerUI)
        {
            //GameContrl.m_TowerAll.Remove(this);
            //GameContrl.instance.CheckTowerCollider(true);
            GameContrl.m_bIsShowAwl = false;
            GameContrl.GetInstance.g_Dismantle.SetActive(false);
            buildtower.CanBuild = true;
            GameContrl.GetInstance.Coins += Mathf.FloorToInt(towerAt.BuildPrice * 0.5f);
            GameContrl.GetInstance.UpdateCoins();
            Instantiate(GameContrl.GetInstance.BuildEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            UIGameContrl.m_currentshowUI = UIGameContrl.CurrentShowUI.SkillUI;
       }
    }

    public void OnPointerEnter()
    {
        //if (UIGameContrl.m_currentshowUI == UIGameContrl.CurrentShowUI.DismantleTowerUI)
        //    GameContrl.m_bIsShowAwl = true;
        GameContrl.m_eCurReticleFoceState = eReticleFoceState.eFoceTower;
    }
    public void OnPointerExit()
    {
        //if (UIGameContrl.m_currentshowUI == UIGameContrl.CurrentShowUI.DismantleTowerUI)
        //    GameContrl.m_bIsShowAwl = false;
        GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
    }

}
