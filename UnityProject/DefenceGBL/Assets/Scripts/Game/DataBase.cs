using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



/// <summary>
/// 塔类型
/// </summary>
public enum TowerType
{
	IronTower = 0, //铁塔
	LightningTower = 1, //雷电塔
	IceTower = 2, 	//冰霜塔
	FlameTower = 3 //火焰塔
}

/// <summary>
/// 怪物类型
/// </summary>
public enum MonsterType
{
	Goblin = 0,  //哥布林
	RidingGoblin = 1, //骑羊哥布林
	Witch = 2,	//女巫
	Skeleton = 3, // 骷髅怪
	Giant = 4, 	//山巨人
}

/// <summary>
/// 技能类型
/// </summary>
public enum SkillsType
{
	/// <summary>
	/// 火球术
	/// </summary>
	FireBall = 0, 
	/// <summary>
	///  龙卷风
	/// </summary>
	Tornado = 1,
	/// <summary>
	/// 沼泽术
	/// </summary>
	Swamp = 2, 
	/// <summary>
	/// 毒雾术
	/// </summary>
	Duwu = 3, 
}

/// <summary>
/// 塔的改变
/// </summary>
public enum TowerProgramme
{
	UpGradeTower = 0,
	DismantleTower = 1
}

/// <summary>
/// 攻击类型
/// </summary>
public enum AttackType
{
	
}
/// <summary>
/// 弹道类型
/// </summary>
public enum BallisticType
{
	StraghtLine,
	Parabola
}


/// <summary>
/// 建筑物类型
/// </summary>
public enum BuildingType
{
	Empty = -1,
	GrassFloor = 0,
	EarthFloor = 1,
	SlateFloor = 2,
	SandFloor = 3,
	ArchBridge = 4,
	TopBridge = 5,
	BaseFloor = 6,
	EnergyCircle = 7,
	Tree = 8,
	WitheredTree = 9,
	Torch = 10,
}

/// <summary>
/// 每个坐标上最多五层,
/// </summary>
public class CoordinateBuildings
{
	public int FirstFloor = 0;
	public int SecondFloor = 0;
	public int ThridFloor = 0;
	public int FourthFloor = 0;
	public int FifthFloor = 0;
}

/// <summary>
/// 地形属性
/// </summary>
public class CoordinateAttribute
{
	/// <summary>
	/// 坐标
	/// </summary>
	public Vector2 Coordinates;
	/// <summary>
	/// 坐标上对应建筑
	/// </summary>
	public CoordinateBuildings coordinatebuilding;
	/// <summary>
	/// 最后一层建筑标识
	/// </summary>
	public int LastNum;
}
/// <summary>
/// 完整地图的属性
/// </summary>
public class TerrainAttribute:List<CoordinateAttribute>
{
	public TerrainAttribute(CoordinateAttribute coor)
	{
		
	}
}

/// <summary>
/// 塔属性
/// </summary>
public class TowerData
{
	/// <summary>
	/// 攻击类型
	/// </summary>
	public int AttackType;
	/// <summary>
	/// 攻击范围
	/// </summary>
	public float AttackRange;
	/// <summary>
	/// 攻击力
	/// </summary>
	public float AttackNum;
}
/// <summary>
/// 怪物属性
/// </summary>
public class MonsterAttribute
{
	/// <summary>
	/// 怪物种类
	/// </summary>
	public string name;
	/// <summary>
	/// 生命值
	/// </summary>
	public int HP;
	/// <summary>
	/// 速度
	/// </summary>
	public float Speed;
}

/// <summary>
/// 技能属性
/// </summary>
public class SkillAttribute
{
	/// <summary>
	/// id
	/// </summary>
	public int id;
	/// <summary>
	/// 名称
	/// </summary>
	public string name;
	/// <summary>
	/// 等级
	/// </summary>
	public int Level;
	/// <summary>
	/// 最大等级
	/// </summary>
	public int MaxLevel;
	/// <summary>
	/// 是否瞬发
	/// </summary>
	public int Instant;
	/// <summary>
	/// 是否群攻
	/// </summary>
	public int IsAOE;
	/// <summary>
	/// The AOE range.
	/// </summary>
	public float AOERange;
	/// <summary>
	/// 群攻范围增长 加法
	/// </summary>
	public float AOERangeUpgrade;
	/// <summary>
	/// 伤害
	/// </summary>
	public int AttackNum;
	/// <summary>
	/// 攻击力升级 乘法
	/// </summary>
	public float AttackNumUpgrade;
	/// <summary>
	/// 持续时间
	/// </summary>
	public int LastTime;
	/// <summary>
	/// 持续时间升级  加法
	/// </summary>
	public int LastTimeUpgrade;
	/// <summary>
	/// 冷却时间
	/// </summary>
	public int CD;
	/// <summary>
	/// 冷却时间缩减 减法
	/// </summary>
	public float CDDown;
	/// <summary>
	/// 金币消耗
	/// </summary>
	public int CoinCost;
	/// <summary>
	/// 减速
	/// </summary>
	public float SlowDown;
	/// <summary>
	/// 减速升级  加法
	/// </summary>
	public float SlowDownUpgrade;
	/// <summary>
	/// 升级需要星星
	/// </summary>
	public int Stars;
	/// <summary>
	/// 星星升级增长
	/// </summary>
	public int StartsUpgrade;

}

/// <summary>
/// 塔属性
/// </summary>
public class TowerAttribute
{
	/// <summary>
	/// 名称
	/// </summary>
	public string name;
	/// <summary>
	/// 等级
	/// </summary>
	public int level;
	/// <summary>
	/// 伤害
	/// </summary>
	public int AttackNum;
	/// <summary>
	/// 攻击范围
	/// </summary>
	public float AttackRange;
	/// <summary>
	/// 攻击速度
	/// </summary>
	public float AttackSpeed;
	/// <summary>
	/// 攻击速度加成
	/// </summary>
	public float AttackSpeedUpgrade;
	/// <summary>
	/// 是否AOE
	/// </summary>
	public bool IsAOE;
	/// <summary>
	/// 建造价格
	/// </summary>
	public int BuildPrice;
	/// <summary>
	/// 拆迁费
	/// </summary>
	public float DismantlePrice;
	/// <summary>
	/// 塔技能
	/// </summary>
	public int Skills;
}

public enum eReticleFoceState
{
    /// <summary>
    /// 对转地面
    /// </summary>
    eFoceTerrain,
    /// <summary>
    /// 对准塔
    /// </summary>
    eFoceTower,
    /// <summary>
    /// 对转基座
    /// </summary>
    eFoceBase,
    /// <summary>
    /// 对转None
    /// </summary>
    eNone,
}