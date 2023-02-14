//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDTaskAchievementTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDTaskAchievementTable.Parse, "TaskAchievement");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDTaskAchievement> m_DataCache = new Dictionary<int, TDTaskAchievement>();
        private static List<TDTaskAchievement> m_DataList = new List<TDTaskAchievement >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDTaskAchievement.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDTaskAchievement.GetFieldHeadIndex(), "TaskAchievementTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDTaskAchievement memberInstance = new TDTaskAchievement();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDTaskAchievement"));
        }

        private static void OnAddRow(TDTaskAchievement memberInstance)
        {
            int key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDTaskAchievementTable Id already exists {0}", key));
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

        public static List<TDTaskAchievement> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDTaskAchievement GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDTaskAchievement", key));
                return null;
            }
        }
    }
}//namespace LR