using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAGrid : MonoBehaviour {
	//子物体身上的脚本组件
	private Transform AGridControl; 
	void Awake () {
		AGridControl = this.transform.Find(Tags.AStar).transform;
	}
	public void SetAEnable() {
		AGridControl.gameObject.SetActive (true);
	}
}
