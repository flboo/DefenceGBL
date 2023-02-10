using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
/// <summary>
/// 控制场景中某些节点的不可行走
/// </summary>
public class PathNodesLimit : MonoBehaviour {

	//两个结点
	private Transform firstNode;
	private Transform secondNode;

	//路径节点生成是否结束
	bool creatNodeIsOrEnd=false;
	//bool 是否激活A*  
	bool isActiveAStar=false;
	//A*的组件
	private Transform aStar;
	void Awake(){
		aStar = GameObject.Find ("AStar").transform.Find ("A*").transform;
	}

	void Update(){
		if (!isActiveAStar){
			if (GameContrl.GetInstance.terraincontrl.creatNodeIsOrEnd==true){
				if (GameContrl.CurrentLevel == 3) 
				{
                    SetTwoNodeLineBreak (22,24);
                    SetTwoNodeLineBreak (23,24);
					SetTwoNodeLineBreak (50,61);
				}
				else if (GameContrl.CurrentLevel == 5) 
				{
                    SetTwoNodeLineBreak(1, 14);
                    SetTwoNodeLineBreak(1, 15);
                    SetTwoNodeLineBreak(2, 17);
                    SetTwoNodeLineBreak(8, 22);
                }
			}
			aStar.gameObject.SetActive (true );
			isActiveAStar = true;
		}
	}

    public void BreakNode()
    {
        if (GameContrl.CurrentLevel == 3)
        {
            SetTwoNodeLineBreak(22, 24);
            SetTwoNodeLineBreak(23, 24);
            SetTwoNodeLineBreak(50, 61);
        }
        else if (GameContrl.CurrentLevel == 5)
        {
            SetTwoNodeLineBreak(1, 14);
            SetTwoNodeLineBreak(1, 15);
            SetTwoNodeLineBreak(2, 17);
            SetTwoNodeLineBreak(8, 22);
        }
        //aStar.gameObject.SetActive(true);
    }


	//设置两个结点之间线段的断开
	public void SetTwoNodeLineBreak(int _firstNode,int _secondNode)
	{
		firstNode = transform.GetChild (_firstNode).transform;
		secondNode = transform.GetChild (_secondNode).transform;
		firstNode.GetComponent<NodeLink> ().end = secondNode;
	}
}
