using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DURATYPE = System.UInt16;
using POSTYPE = System.UInt16;
using DBSERIAL = System.Int64;
using SLOTCODE = System.UInt32;
using CODETYPE = System.UInt32;
using KEYTYPE = System.UInt32;
using LEVELTYPE = System.UInt16;
using SLOTIDX = System.Byte;
using MONEY = System.UInt64;
using DAMAGETYPE = System.UInt32;
using WORD = System.UInt16;
using time_t = System.Int64;

public class DataRow : List<string>{
	public DataRow(string data) : base(){
		string[] datas = data.Split(',');
		this.AddRange(datas);
	}
	public string Pull(){
		string s = this[0];
		this.RemoveAt(0);
		return s;
	}
	public byte Pull(byte t){
		string s = Pull();
		return Convert.ToByte(s);
	}
	public float Pull(float t){
		return float.Parse(Pull());
	}
	public UInt16 Pull(UInt16 t){
		return Convert.ToUInt16(Pull());
	}
	public bool Pull(bool t){
		return Convert.ToBoolean (Pull(1));
	}
	public UInt32 Pull(UInt32 t){
		return Convert.ToUInt32(Pull());
	}
	public Int32 Pull(Int32 t){
		return Convert.ToInt32(Pull());
	}
	public Enum Pull(Enum t){
		return (Enum)Enum.Parse(t.GetType() , Pull());
	}
}

public class DataTable : List<DataRow>{
	public DataTable(string data) : base(){
		string[] rows = data.Split('\n');

		for (int i = 0; i < rows.Length; i++) {
			if (rows[i].StartsWith("//") || string.IsNullOrEmpty(rows[i]))
				continue;
			string[] stows = rows [i].Split ('\t');
			for(int j=0; j<stows.Length; j++)
			{
				this.Add (new DataRow(stows[j].Trim()));
			}
		}
	}
}

public class DataRowT : List<string>{
	public DataRowT(string data) : base(){
		string[] datas = data.Split('\t');
		this.AddRange(datas);
	}
	public string Pull(){
		string s = this[0];
		this.RemoveAt(0);
		return s;
	}
	public byte Pull(byte t){
		string s = Pull();
		return Convert.ToByte(s);
	}
	public float Pull(float t){
		return float.Parse(Pull());
	}
	public UInt16 Pull(UInt16 t){
		return Convert.ToUInt16(Pull());
	}
	public bool Pull(bool t){
		return Convert.ToBoolean (Pull(1));
	}
	public UInt32 Pull(UInt32 t){
		return Convert.ToUInt32(Pull());
	}
	public Int32 Pull(Int32 t){
		return Convert.ToInt32(Pull());
	}
	public Enum Pull(Enum t){
		return (Enum)Enum.Parse(t.GetType() , Pull());
	}
}

public class DataTableT : List<DataRowT>{
	public DataTableT(string data) : base(){
		string[] rows = data.Split('\n');

		for (int i = 0; i < rows.Length; i++) {
			if (rows[i].StartsWith("//") || string.IsNullOrEmpty(rows[i]))
				continue;

			this.Add(new DataRowT(rows[i].Trim()));
		}
	}
}

/// <summary>
/// 静态数据
/// </summary>
public class CoreStaticDataManager{
	private static CoreStaticDataManager m_instance = null;
	public static CoreStaticDataManager instance()
	{
			if (m_instance == null)
				m_instance = new CoreStaticDataManager();
			return m_instance;
	}

	#region test
	public static string dataPath = UnityEngine.Application.dataPath;
	#endregion

	public readonly CoordinateData[] m_arrCoordinateData1;
	public readonly CoordinateData[] m_arrCoordinateData2;
	public readonly CoordinateData[] m_arrCoordinateData3;
	public readonly CoordinateData[] m_arrCoordinateData4;
	public readonly CoordinateData[] m_arrCoordinateData5;
	public readonly TowerDataByName[] m_arrTowerDataByName;
	public readonly MonsterDataByName[] m_arrMonsterDataByName;
	public readonly SkillDataByName[] m_arrSkillDataByName;
	public List<CreatMonsterData> m_arrCreatMonsterData = new List<CreatMonsterData>();

	public CoreStaticDataManager()
	{
		m_arrCoordinateData1 = InitStaticCoordinateData ("Terrain1");
		m_arrCoordinateData2 = InitStaticCoordinateData ("Terrain2");
		m_arrCoordinateData3 = InitStaticCoordinateData ("Terrain3");
		m_arrCoordinateData4 = InitStaticCoordinateData ("Terrain4");
		m_arrCoordinateData5 = InitStaticCoordinateData ("Terrain5");
		m_arrTowerDataByName = InitStaticTowerDataByName ();
		m_arrMonsterDataByName = InitStaticMonsterDataByName ();
		m_arrSkillDataByName = InitStaticSkillDataByName();
		if(m_arrCreatMonsterData.Count == 0)
			GetCreatMonsterData("CreateMonster");
	}



	private T[] StaticMultiRowTableInit<T>(string tableName)
	{
		string dataString = UnityEngine.Resources.Load<UnityEngine.TextAsset>(string.Concat("Text/",tableName)).text;

        //UnityEngine.Debug.LogWarning(dataString);

		DataTable cards = new DataTable(dataString);
		T[] tValue = (T[])Activator.CreateInstance(typeof(T[]), cards.Count);
		for (int i = 0; i < tValue.Length; i++) 
		{
			try
			{
				tValue[i] = (T)Activator.CreateInstance(typeof(T), cards[i]);
			}
			catch(Exception e)
			{
				UnityEngine.Debug.Break();
				UnityEngine.Debug.LogWarning("e   "+e.Message+"  i "+i+"  tableName   "+tableName + "  tValue[i]" + cards[i]);
			}
		}
		return tValue;
	}


	private T[] StaticMultiRowTableInitT<T>(string tableName)
	{
		string dataString = UnityEngine.Resources.Load<UnityEngine.TextAsset>(string.Concat("Text/",tableName)).text;

		//UnityEngine.Debug.LogWarning(dataString);

		DataTableT cards = new DataTableT(dataString);
		T[] tValue = (T[])Activator.CreateInstance(typeof(T[]), cards.Count);
		for (int i = 0; i < tValue.Length; i++) 
		{
			try
			{
				tValue[i] = (T)Activator.CreateInstance(typeof(T), cards[i]);
			}
			catch(Exception e)
			{
				UnityEngine.Debug.Break();
				UnityEngine.Debug.LogWarning("e   "+e.Message+"  i "+i+"  tableName   "+tableName);
			}
		}
		return tValue;
	}

	#region 初始化 

	/// <summary>
	/// 读取卡牌静态表
	/// </summary>
	/// <returns>The static card info.</returns>
	private CoordinateData[] InitStaticCoordinateData(string str)
	{
		return StaticMultiRowTableInit<CoordinateData>(str);
	}

    #endregion



	#region 初始化 

	/// <summary>
	/// 读取卡牌静态表
	/// </summary>
	/// <returns>The static card info.</returns>
	private TowerDataByName[] InitStaticTowerDataByName(){
		return StaticMultiRowTableInitT<TowerDataByName>("TowerData");
	}
	private MonsterDataByName[] InitStaticMonsterDataByName(){
		return StaticMultiRowTableInitT<MonsterDataByName>("MonsterData");
	}
	private SkillDataByName[] InitStaticSkillDataByName(){
		return StaticMultiRowTableInitT<SkillDataByName>("SkillData");
	}
	#endregion

	#region 获取
	public TowerDataByName GetTowerDataByName(string m_strId) {
		for (int i = 0; i < m_arrTowerDataByName.Length; i++)
		{
			if (m_arrTowerDataByName[i].m_Name == m_strId)
			{
				return m_arrTowerDataByName[i];
			}
		}
		return null;
	}

	public MonsterDataByName GetMonsterDataByName(string m_strId) {
		for (int i = 0; i < m_arrMonsterDataByName.Length; i++)
		{
			if (m_arrMonsterDataByName[i].m_Name == m_strId)
			{
				return m_arrMonsterDataByName[i];
			}
		}
		return null;
	}
	public SkillDataByName GetSkillDataByName(string m_strId) {
		for (int i = 0; i < m_arrSkillDataByName.Length; i++)
		{
			if (m_arrSkillDataByName[i].m_Name == m_strId)
			{
				return m_arrSkillDataByName[i];
			}
		}
		return null;
	}
	public CreatMonsterData GetCreateMonsterDataByName(string m_strId) {
		for (int i = 0; i < m_arrCreatMonsterData.Count; i++)
		{
			if (m_arrCreatMonsterData[i].Level == m_strId)
			{
				return m_arrCreatMonsterData[i];
			}
		}
		return null;
	}
		
	/// <summary>
	/// 获得创建怪物数据
	/// </summary>
	/// <param name="tableName">Table name.</param>
	private void GetCreatMonsterData(string tableName)
	{
		string dataString = UnityEngine.Resources.Load<UnityEngine.TextAsset>(string.Concat("Text/",tableName)).text;
		string[] rows = dataString.Split('\n');

		for (int i = 0; i < rows.Length; i++) 
		{
			if (rows[i].StartsWith("//") || string.IsNullOrEmpty(rows[i]))
				continue;
			CreatMonsterData cmd = new CreatMonsterData ();
			string[] stows = rows [i].Split ('\t');
			cmd.Level = stows [1];
			cmd.BandNum = int.Parse (stows [3]);
			cmd.mb1.Band = int.Parse (stows [4]);

			cmd.mb1.Monstertype1 = int.Parse (stows [5]);
			cmd.mb1.Monstertype1Num = int.Parse (stows [6]);
			cmd.mb1.Monstertype2 = int.Parse (stows [7]);
			cmd.mb1.Monstertype2Num = int.Parse (stows [8]);
			cmd.mb1.Monstertype3 = int.Parse (stows [9]);
			cmd.mb1.Monstertype3Num = int.Parse (stows [10]);

			cmd.mb2.Band = int.Parse (stows [11]);
			cmd.mb2.Monstertype1 = int.Parse (stows [12]);
			cmd.mb2.Monstertype1Num = int.Parse (stows [13]);
			cmd.mb2.Monstertype2 = int.Parse (stows [14]);
			cmd.mb2.Monstertype2Num = int.Parse (stows [15]);
			cmd.mb2.Monstertype3 = int.Parse (stows [16]);
			cmd.mb2.Monstertype3Num = int.Parse (stows [17]);

			cmd.mb3.Band = int.Parse (stows [18]);
			cmd.mb3.Monstertype1 = int.Parse (stows [19]);
			cmd.mb3.Monstertype1Num = int.Parse (stows [20]);
			cmd.mb3.Monstertype2 = int.Parse (stows [21]);
			cmd.mb3.Monstertype2Num = int.Parse (stows [22]);
			cmd.mb3.Monstertype3 = int.Parse (stows [23]);
			cmd.mb3.Monstertype3Num = int.Parse (stows [24]);

			cmd.mb4.Band = int.Parse (stows [25]);
			cmd.mb4.Monstertype1 = int.Parse (stows [26]);
			cmd.mb4.Monstertype1Num = int.Parse (stows [27]);
			cmd.mb4.Monstertype2 = int.Parse (stows [28]);
			cmd.mb4.Monstertype2Num = int.Parse (stows [29]);
			cmd.mb4.Monstertype3 = int.Parse (stows [30]);
			cmd.mb4.Monstertype3Num = int.Parse (stows [31]);

			m_arrCreatMonsterData.Add (cmd);
		}
	}
	#endregion
}

/// <summary>
/// 地形数据
/// </summary>
public class CoordinateData
{
	public CoordinateData(DataRow data)
	{
		m_x = data.Pull(m_x);
		m_y = data.Pull(m_y);
		m_first = data.Pull(m_first);
		m_second = data.Pull(m_second);
		m_thrid = data.Pull(m_thrid);
		m_fourth = data.Pull(m_fourth);
		m_fifth = data.Pull(m_fifth);
	}
	public int m_x;
	public int m_y;
	public int m_first;
	public int m_second;
	public int m_thrid;
	public int m_fourth;
	public int m_fifth;
}

/// <summary>
/// 塔数据
/// </summary>
public class TowerDataByName
{
	public TowerDataByName(DataRowT data)
	{
		m_Name = data.Pull();
		m_Level = data.Pull(m_Level);
		m_MaxLevel = data.Pull(m_MaxLevel);
		m_AttackNum = data.Pull(m_AttackNum);
		m_AttackNumUpgrade = data.Pull(m_AttackNumUpgrade);
		m_AttackRange = data.Pull(m_AttackRange);
		m_AttackRangeUpgrade = data.Pull(m_AttackRangeUpgrade);
		m_AttackSpeed = data.Pull(m_AttackSpeed);
		m_AttackSpeedUpgrade = data.Pull(m_AttackSpeedUpgrade);
		m_IsAOE = data.Pull(m_IsAOE);
		m_BuildPrice = data.Pull(m_BuildPrice);
		m_BuildPriceUpgrade = data.Pull(m_BuildPriceUpgrade);
		m_DismantlePrice = data.Pull(m_DismantlePrice);
		m_skills = data.Pull(m_skills);
	}
	public string m_Name;
	public int m_Level;
	public int m_MaxLevel;
	public int m_AttackNum;
	public int m_AttackNumUpgrade;
	public float m_AttackRange;
	public float m_AttackRangeUpgrade;
	public float m_AttackSpeed;
	public float m_AttackSpeedUpgrade;
	public bool m_IsAOE;
	public int m_BuildPrice;
	public int m_BuildPriceUpgrade;
	public float m_DismantlePrice;
	public int m_skills;
}

/// <summary>
/// 怪物数据
/// </summary>
public class MonsterDataByName
{
	public MonsterDataByName(DataRowT data)
	{
		m_Name = data.Pull ();
		m_HP = data.Pull (m_HP);
		m_Speed = data.Pull (m_Speed);
	}
	public string m_Name;
	public int m_HP;
	public float m_Speed;
}

/// <summary>
/// 技能数据
/// </summary>
public class SkillDataByName
{
	public SkillDataByName(DataRowT data)
	{
		m_id = data.Pull (m_id);
		m_Name = data.Pull ();
		m_Level = data.Pull (m_Level);
		m_MaxLevel = data.Pull (m_MaxLevel);
		m_Instant = data.Pull (m_Instant);
		m_IsAOE = data.Pull (m_IsAOE);
		m_AOERange = data.Pull (m_AOERange);
		m_AOERangeUpgrade = data.Pull (m_AOERangeUpgrade);
		m_AttackNum = data.Pull (m_AttackNum);
		m_AttackNumUpgrade = data.Pull (m_AttackNumUpgrade);
		m_LastTime = data.Pull (m_LastTime);
		m_LastTimeUpgrade = data.Pull (m_LastTimeUpgrade);
		m_CD = data.Pull (m_CD);
		m_CDDown = data.Pull (m_CDDown);
		m_CoinCost = data.Pull (m_CoinCost);
		m_SlowDown = data.Pull (m_SlowDown);
		m_SlowDownUpgrade = data.Pull (m_SlowDownUpgrade);
		m_Stars = data.Pull (m_Stars);
		m_StarsUpgrade = data.Pull (m_StarsUpgrade);
	}
	public int m_id;
	public string m_Name;
	public int m_Level;
	public int m_MaxLevel;
	public int m_Instant;
	public int m_IsAOE;
	public float m_AOERange;
	public float m_AOERangeUpgrade;
	public int m_AttackNum;
	public float m_AttackNumUpgrade; 
	public int m_LastTime;
	public int m_LastTimeUpgrade;
	public int m_CD;
	public float m_CDDown;
	public int m_CoinCost;
	public float m_SlowDown;
	public float m_SlowDownUpgrade;
	public int m_Stars;
	public int m_StarsUpgrade;
}





public class CreatMonsterData
{
	public string Level;
	public int BandNum;
	public MonsterBand mb1 = new MonsterBand ();
	public MonsterBand mb2 = new MonsterBand ();
	public MonsterBand mb3 = new MonsterBand ();
	public MonsterBand mb4 = new MonsterBand ();
}

public class MonsterBand
{
	public int Band;
	public int Monstertype1;
	public int Monstertype1Num;
	public int Monstertype2;
	public int Monstertype2Num;
	public int Monstertype3;
	public int Monstertype3Num;
}