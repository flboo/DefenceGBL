using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	private Transform m_self;
	public Transform m_Camera;

	void Awake () 
	{
        if(m_Camera==null)
            m_Camera = Camera.main.transform;
		m_self = this.transform;
	}

	void Update () 
	{
		m_self.LookAt (m_Camera);
	}
}
