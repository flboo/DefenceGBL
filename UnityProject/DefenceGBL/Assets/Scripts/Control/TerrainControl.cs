using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainControl : MonoBehaviour {

    public static TerrainControl instance = null;
    public static TerrainControl GetInstance
    {
        get
        {
            if(instance == null)
                instance = GameObject.Find("GameContrl").GetComponent<TerrainControl>();
            return instance;
        }
    }

    public GameObject[] BuildingPrefabs;
	private List<CoordinateAttribute> teerainlist = new List<CoordinateAttribute>();
	private float BuildingHight = 1f;
	private float BuildingWeight = 1;
	private float BuildingLong = 1;
	public Transform Buildings;
	ArrayList coor = new ArrayList();
    AstarPath a1;
    public static bool m_bRotate = false;
    public Vector2 Coordinates = new Vector2 (0,0);
	public Vector2 MeshSize = new Vector2 (12,12);
	private Vector3[] StartPos = 
	{
		new Vector3(0,0,0),
		new Vector3(2.5f,1.15f,12.5f),
		new Vector3(12.5f,1.15f,10.5f),
		new Vector3(2.5f,1.15f,12.5f),
		new Vector3(2.5f,1.15f,12.5f),
		new Vector3(12.5f,1.15f,11.5f),
	};
	private Vector3[] TargetPos = 
	{
		new Vector3(0,0,0),
		new Vector3(11.5f,1.15f,1.5f),
		new Vector3(1.5f,1.15f,3.5f),
		new Vector3(10.5f,1.15f,1.5f),
		new Vector3(11.5f,1.15f,1.5f),
		new Vector3(12.5f,1.15f,1.5f),
	};
	private Vector3[] MiddleTargetPos01 = 
	{
		new Vector3(0,0,0),
		new Vector3(8.5f,4.15f,1.5f),
		new Vector3(0,0,0),
		new Vector3(2.5f,1.15f,1.5f),
		new Vector3(0,0,0),
		new Vector3(5.5f,1.15f,1.5f),
	};
	private Vector3[] MiddleTargetPos02 = 
	{
		new Vector3(0,0,0),
		new Vector3(0,0,0),
		new Vector3(0,0,0),
		new Vector3(6.5f,4.15f,10.5f),
		new Vector3(0,0,0),
		new Vector3(8.5f,4.15f,10.5f),
	};
	void Awake()
	{
        m_bRotate = false;
        GetMapInfor ();
		GameContrl.GetInstance.monstercontrl.StartPos.position = StartPos[GameContrl.CurrentLevel] - new Vector3(7f, 0f, 6f); 
		GameContrl.GetInstance.monstercontrl.TargetPos.position = TargetPos[GameContrl.CurrentLevel] - new Vector3(7f, 0f, 6f);
		GameContrl.GetInstance.monstercontrl.MiddleTargetPos01.position = MiddleTargetPos01[GameContrl.CurrentLevel] - new Vector3(7f, 0f, 6f);
		GameContrl.GetInstance.monstercontrl.MiddleTargetPos02.position = MiddleTargetPos02[GameContrl.CurrentLevel] - new Vector3(7f, 0f, 6f);
		GameContrl.GetInstance.monstercontrl.EndMonster.position = TargetPos[GameContrl.CurrentLevel] - new Vector3(7f, 0f, 6f);
	}
	public void StartGame()
	{
        //CreatTerrain ();
        StartCoroutine(CreatTerrain());
		CreatRoadNode ();
	}

	CoordinateData[] coordinatedata;
	/// <summary>
	/// 获得地形数据
	/// </summary>
	public void GetMapInfor()
	{
		teerainlist.Clear ();
		if(GameContrl.CurrentLevel == 1)
			coordinatedata = CoreStaticDataManager.instance().m_arrCoordinateData1;
		else if(GameContrl.CurrentLevel == 2)
			coordinatedata = CoreStaticDataManager.instance().m_arrCoordinateData2;
		else if(GameContrl.CurrentLevel == 3)
			coordinatedata = CoreStaticDataManager.instance().m_arrCoordinateData3;
		else if(GameContrl.CurrentLevel == 4)
			coordinatedata = CoreStaticDataManager.instance().m_arrCoordinateData4;
		else if(GameContrl.CurrentLevel == 5)
			coordinatedata = CoreStaticDataManager.instance().m_arrCoordinateData5;
		for(int a=0;a<coordinatedata.Length;a++)
		{
			CoordinateBuildings m_coordinate = new CoordinateBuildings ();
			m_coordinate.FirstFloor = coordinatedata[a].m_first;
			m_coordinate.SecondFloor = coordinatedata[a].m_second;
			m_coordinate.ThridFloor = coordinatedata[a].m_thrid;
			m_coordinate.FourthFloor = coordinatedata[a].m_fourth;
			m_coordinate.FifthFloor = coordinatedata[a].m_fifth;
			CoordinateAttribute coorattr = new CoordinateAttribute ();
			coorattr.Coordinates = new Vector2(coordinatedata[a].m_x, coordinatedata[a].m_y);
			coorattr.coordinatebuilding = m_coordinate;
			teerainlist.Add (coorattr);
		}
	}
	/// <summary>
	/// 获得坐标上建筑层数
	/// </summary>
	/// <returns>The layer number.</returns>
	/// <param name="a">The alpha component.</param>
	public int GetLayerNum(CoordinateBuildings a)
	{
		if(a.FirstFloor == -1)
		{
			return 0;
		}
		else if(a.SecondFloor == -1)
		{
			return 1;
		}
		else if(a.ThridFloor == -1)
		{
			return 2;
		}
		else if(a.FourthFloor == -1)
		{
			return 3;
		}
		else if(a.FifthFloor == -1)
		{
			return 4;
		}
		else
		{
			return 5;
		}
		return 0;
	}
	/// <summary>
	/// 创建地形
	/// </summary>
	GameObject ga;
	int b;
	IEnumerator CreatTerrain()
	{
		for(int a=0;a<teerainlist.Count;a++)
		{
			if (teerainlist [a].coordinatebuilding.FirstFloor != -1)
			{
				b = 0;
				ga = Instantiate (BuildingPrefabs [teerainlist [a].coordinatebuilding.FirstFloor]);
				ga.transform.position = new Vector3 (BuildingLong * (0.5f + teerainlist [a].Coordinates.x), BuildingHight * b, BuildingWeight * (0.5f + teerainlist [a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
				ga.transform.parent = Buildings;
				if (teerainlist [a].coordinatebuilding.FirstFloor==5) {
					ga = Instantiate (pathNoadPrefab);
					ga.transform.position = new Vector3 (BuildingLong*(0.5f + teerainlist[a].Coordinates.x) ,BuildingHight*(b+0.4f), BuildingWeight*(0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
					ga.transform.parent = PathNodes;
					ga.name = "pathNode" + NameId.ToString ();
					NameId++;
				}
                yield return new WaitForSeconds(0.05f);
            }
        }
        yield return new WaitForSeconds(0.2f);
        for (int a = 0; a < teerainlist.Count; a++)
        {
            if (teerainlist[a].coordinatebuilding.SecondFloor != -1)
            {
                b = 1;
                ga = Instantiate(BuildingPrefabs[teerainlist[a].coordinatebuilding.SecondFloor]);
                ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * b, BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                ga.transform.parent = Buildings;
                if (teerainlist[a].coordinatebuilding.SecondFloor == 4)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 1.3f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                if (teerainlist[a].coordinatebuilding.SecondFloor == 5)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 0.4f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        yield return new WaitForSeconds(0.2f);
        for (int a = 0; a < teerainlist.Count; a++)
        {
            if (teerainlist[a].coordinatebuilding.ThridFloor != -1)
            {
                b = 2;
                ga = Instantiate(BuildingPrefabs[teerainlist[a].coordinatebuilding.ThridFloor]);
                ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * b, BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                ga.transform.parent = Buildings;
                if (teerainlist[a].coordinatebuilding.ThridFloor == 4)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 1.3f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                if (teerainlist[a].coordinatebuilding.ThridFloor == 5)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 0.4f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        yield return new WaitForSeconds(0.2f);
        for (int a = 0; a < teerainlist.Count; a++)
        {
            if (teerainlist[a].coordinatebuilding.FourthFloor != -1)
            {
                b = 3;
                ga = Instantiate(BuildingPrefabs[teerainlist[a].coordinatebuilding.FourthFloor]);
                ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * b, BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                ga.transform.parent = Buildings;
                if (teerainlist[a].coordinatebuilding.FourthFloor == 4)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 1.3f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                if (teerainlist[a].coordinatebuilding.FourthFloor == 5)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 0.4f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        yield return new WaitForSeconds(0.2f);
        for (int a = 0; a < teerainlist.Count; a++)
        {
            if (teerainlist[a].coordinatebuilding.FifthFloor != -1)
            {
                b = 4;
                ga = Instantiate(BuildingPrefabs[teerainlist[a].coordinatebuilding.FifthFloor]);
                ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * b, BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                ga.transform.parent = Buildings;
                if (teerainlist[a].coordinatebuilding.FifthFloor == 4)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 1.3f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                if (teerainlist[a].coordinatebuilding.FifthFloor == 5)
                {
                    ga = Instantiate(pathNoadPrefab);
                    ga.transform.position = new Vector3(BuildingLong * (0.5f + teerainlist[a].Coordinates.x), BuildingHight * (b + 0.4f), BuildingWeight * (0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
                    ga.transform.parent = PathNodes;
                    ga.name = "pathNode" + NameId.ToString();
                    NameId++;
                }
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        a1 = GameObject.FindObjectOfType<AstarPath>();
        //if (GameContrl.CurrentLevel != 1)
      //  Debug.LogError("aInitAndStartGame  gdsdsdag");
        GameContrl.GetInstance.InitAndStartGame();
        GameContrl.GetInstance.pathNodesLimit.BreakNode();
        m_bRotate = true;
        if (a1 != null)
            a1.Scan();
    }


	//道路节点的预设体
	public GameObject pathNoadPrefab;
	//创建路径节点是否结束
	public bool creatNodeIsOrEnd=false;
	bool isCreatRodeNodeOne=false;
	bool isCreatRodeNodeTwo=false;
	bool isCreatRodeNodethree=false;
	bool isCreatRodeNodefour=false;
	bool CanToFour=true;
	bool CanTothree=true;
	public Transform PathNodes;



	int bb;
	int temp;
	GameObject gaa;
	int NameId = 0;
	void CreatRoadNode()
	{
		if(GameContrl.CurrentLevel == 1)
		{
			GameObject abg = Instantiate (pathNoadPrefab,new Vector3(5,3.5f,1.5f) - new Vector3(7f, 0f, 6f), Quaternion.identity,PathNodes) as GameObject;
			abg.name = "pathNode" + NameId.ToString ();
			NameId++;
		}
		//临时变量
		int temp;
		for(int a=0;a<teerainlist.Count;a++)
		{
			int tempp = GetLayerNum (teerainlist [a].coordinatebuilding);
			for(int b=0;b <tempp;b++)
			{
				if (b == 0) {
					if (b == tempp-1) {
						temp = teerainlist [a].coordinatebuilding.FirstFloor;
						if (temp==0||temp==1||temp==2||temp==3){
							isCreatRodeNodeOne = true;
						}else if (temp>=7&&temp<=25) {
							isCreatRodeNodeTwo=true;
						} else if (temp==5) {
							isCreatRodeNodethree = true;
						}else if (temp==4) {
							isCreatRodeNodefour = true;
						}
					}
				} else if (b == 1) {
					if (b == tempp-1) {
						temp = teerainlist [a].coordinatebuilding.SecondFloor;
						if (temp==0||temp==1||temp==2||temp==3) {
							isCreatRodeNodeOne = true;
						}else if (temp>=7&&temp<=25){
							isCreatRodeNodeTwo=true;
						} else if (temp==5) {
							isCreatRodeNodethree = true;
						}else if (temp==4) {
							isCreatRodeNodefour = true;
						}
					}
				} else if (b == 2) {
					if (b == tempp-1) {
						temp = teerainlist [a].coordinatebuilding.ThridFloor;
						if (temp==0||temp==1||temp==2||temp==3) {
							isCreatRodeNodeOne = true;
						}else if (temp>=7&&temp<=25){
							isCreatRodeNodeTwo=true;
						} else if (temp==5) {
							isCreatRodeNodethree = true;
						}else if (temp==4) {
							isCreatRodeNodefour = true;
						}
					}
				} else if (b == 3){
					if (b == tempp-1){
						temp = teerainlist [a].coordinatebuilding.FourthFloor;
						if (temp==0||temp==1||temp==2||temp==3) {
							isCreatRodeNodeOne = true;
						}else if (temp>=7&&temp<=25){
							isCreatRodeNodeTwo=true;
						} else if (temp==5) {
							isCreatRodeNodethree = true;
						}else if (temp==4) {
							isCreatRodeNodefour = true;
						}
					}
				} else if (b == 4) {
					if (b == tempp-1) {
						temp = teerainlist [a].coordinatebuilding.FifthFloor;
						if (temp == 0 || temp == 1 || temp == 2 || temp == 3) {
							isCreatRodeNodeOne = true;
						} else if (temp >= 7 && temp <= 25) {
							isCreatRodeNodeTwo = true;
						} else if (temp==5) {
							isCreatRodeNodethree = true;
						} else if (temp==4) {
							isCreatRodeNodefour = true;
						}
					}
				}
				if (isCreatRodeNodeOne==true) {
					ga = Instantiate (pathNoadPrefab);
					ga.transform.position = new Vector3 (BuildingLong*(0.5f + teerainlist[a].Coordinates.x) ,BuildingHight*(b+1.3f), BuildingWeight*(0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
					ga.transform.parent = PathNodes;
					ga.name = "pathNode" + NameId.ToString ();
					NameId++;
					isCreatRodeNodeOne=false;
				}else if (isCreatRodeNodeTwo){
					ga = Instantiate (pathNoadPrefab);
					gaa = Instantiate (pathNoadPrefab);
					ga.transform.position = new Vector3 (BuildingLong*(0.5f + teerainlist[a].Coordinates.x) ,BuildingHight*(b+0.8f), BuildingWeight*(0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
					gaa.transform.position = new Vector3 (BuildingLong*(0.5f + teerainlist[a].Coordinates.x) ,BuildingHight*(b+1.1f), BuildingWeight*(0.5f + teerainlist[a].Coordinates.y)) - new Vector3(7f, 0f, 6f);
					ga.transform.parent = PathNodes;
					gaa.transform.parent = PathNodes;
					ga.name = "pathNode" + NameId.ToString ();
					NameId++;
					gaa.name = "pathNode" + NameId.ToString ();
					NameId++;
					isCreatRodeNodeTwo=false;
				}

			}
		}
        //创建节点结束
        creatNodeIsOrEnd = true;
        //可以创建小怪了
        GameContrl.GetInstance.monstercontrl.isArriveCreatMonsterTerm = true;

    }
}
