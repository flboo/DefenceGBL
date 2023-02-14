//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDTaskDailyTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDTaskDailyTable.Parse, "TaskDaily");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDTaskDaily> m_DataCache = new Dictionary<int, TDTaskDaily>();
        private static List<TDTaskDaily> m_DataList = new List<TDTaskDaily >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDTaskDaily.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDTaskDaily.GetFieldHeadIndex(), "TaskDailyTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDTaskDaily memberInstance = new TDTaskDaily();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDTaskDaily"));
        }

        private static void OnAddRow(TDTaskDaily memberInstance)
        {
            int key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDTaskDailyTable Id already exists {0}", key));
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

        public static List<TDTaskDaily> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDTaskDaily GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDTaskDaily", key));
                return null;
            }
        }
    }
}//namespace LR