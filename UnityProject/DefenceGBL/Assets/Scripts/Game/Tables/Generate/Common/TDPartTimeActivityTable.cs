//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDPartTimeActivityTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDPartTimeActivityTable.Parse, "PartTimeActivity");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDPartTimeActivity> m_DataCache = new Dictionary<int, TDPartTimeActivity>();
        private static List<TDPartTimeActivity> m_DataList = new List<TDPartTimeActivity >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDPartTimeActivity.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDPartTimeActivity.GetFieldHeadIndex(), "PartTimeActivityTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDPartTimeActivity memberInstance = new TDPartTimeActivity();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDPartTimeActivity"));
        }

        private static void OnAddRow(TDPartTimeActivity memberInstance)
        {
            int key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDPartTimeActivityTable Id already exists {0}", key));
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

        public static List<TDPartTimeActivity> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDPartTimeActivity GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDPartTimeActivity", key));
                return null;
            }
        }
    }
}//namespace LR