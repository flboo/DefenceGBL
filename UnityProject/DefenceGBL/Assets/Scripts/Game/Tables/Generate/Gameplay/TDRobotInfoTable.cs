//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDRobotInfoTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDRobotInfoTable.Parse, "RobotInfo");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDRobotInfo> m_DataCache = new Dictionary<int, TDRobotInfo>();
        private static List<TDRobotInfo> m_DataList = new List<TDRobotInfo >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDRobotInfo.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDRobotInfo.GetFieldHeadIndex(), "RobotInfoTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDRobotInfo memberInstance = new TDRobotInfo();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDRobotInfo"));
        }

        private static void OnAddRow(TDRobotInfo memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDRobotInfoTable Id already exists {0}", key));
            }
            else
            {
                m_DataCache.Add(key, memberInstance);
                m_DataList.Add(memberInstance);
            }
        }    
        
        public static void Reload(byte[] fileData)
        {
            Parse(fileData);
        }

        public static int count
        {
            get 
            {
                return m_DataCache.Count;
            }
        }

        public static List<TDRobotInfo> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDRobotInfo GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDRobotInfo", key));
                return null;
            }
        }
    }
}//namespace LR