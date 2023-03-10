//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDOrderChatInfoTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDOrderChatInfoTable.Parse, "OrderChatInfo");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDOrderChatInfo> m_DataCache = new Dictionary<int, TDOrderChatInfo>();
        private static List<TDOrderChatInfo> m_DataList = new List<TDOrderChatInfo >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDOrderChatInfo.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDOrderChatInfo.GetFieldHeadIndex(), "OrderChatInfoTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDOrderChatInfo memberInstance = new TDOrderChatInfo();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDOrderChatInfo"));
        }

        private static void OnAddRow(TDOrderChatInfo memberInstance)
        {
            int key = memberInstance.iD;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDOrderChatInfoTable Id already exists {0}", key));
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

        public static List<TDOrderChatInfo> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDOrderChatInfo GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDOrderChatInfo", key));
                return null;
            }
        }
    }
}//namespace LR