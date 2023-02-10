using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour {
	Transform m_self;
	public Vector3 TowerPos;
	//是否已经建造
	[HideInInspector]
	public bool CanBuild = true;
    public bool IsGazed = false;
	GameObject Tower;
	TowerAttribute tab = new TowerAttribute();
	void Awake ()
	{
		m_self = this.transform;
		CanBuild = true;	
	}

	public void SetGazedAt(bool gazedAt) 
	{
        TowerPos = new Vector3 (m_self.position.x, m_self.position.y + 0.5f, m_self.position.z);
        if (gazedAt)
        {
            IsGazed = true;
            //GameContrl.m_eCurReticleFoceState = eReticleFoceState.eFoceBase;
        } else
        {
            IsGazed = false;
           // GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
        }
        
	}
	public void OnGazeEnter()
	{
        TowerPos = new Vector3 (m_self.position.x,m_self.position.y + 0.5f,m_self.position.z);
	}
		
	public void Build()
	{
		if (!GameContrl.IsPlaying)
			return;
		if(CanBuild && GameContrl.GetInstance.IsCanCheck)
		{
			GameContrl.GetInstance.uigamecontrl.ShowTowerBuild (this);
		}
	}
}
