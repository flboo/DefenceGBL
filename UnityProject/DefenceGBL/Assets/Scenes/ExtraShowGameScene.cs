using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShowGameScene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //m_gameobject.SetActive(true);
        //        Time.timeScale = 1;
        if (!GameContrl.IsStartBuild)
        {
            GameContrl.IsStartBuild = true;
            TerrainControl.GetInstance.StartGame();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
