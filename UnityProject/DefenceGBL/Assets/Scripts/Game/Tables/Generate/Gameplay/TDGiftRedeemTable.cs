//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public static partial class TDGiftRedeemTable
    {
        private static TDTableMetaData m_MetaData = new TDTableMetaData(TDGiftRedeemTable.Parse, "GiftRedeem");
        public static TDTableMetaData metaData
        {
            get { return m_MetaData; }
        }
        
        private static Dictionary<int, TDGiftRedeem> m_DataCache = new Dictionary<int, TDGiftRedeem>();
        private static List<TDGiftRedeem> m_DataList = new List<TDGiftRedeem >();
        
        public static void Parse(byte[] fileData)
        {
            m_DataCache.Clear();
            m_DataList.Clear();
            DataStreamReader dataR = new DataStreamReader(fileData);
            int rowCount = dataR.GetRowCount();
            int[] fieldIndex = dataR.GetFieldIndex(TDGiftRedeem.GetFieldHeadIndex());
    #if (UNITY_STANDALONE_WIN) || UNITY_EDITOR || UNITY_STANDALONE_OSX
            dataR.CheckFieldMatch(TDGiftRedeem.GetFieldHeadIndex(), "GiftRedeemTable");
    #endif
            for (int i = 0; i < rowCount; ++i)
            {
                TDGiftRedeem memberInstance = new TDGiftRedeem();
                memberInstance.ReadRow(dataR, fieldIndex);
                OnAddRow(memberInstance);
                memberInstance.Reset();
                CompleteRowAdd(memberInstance);
            }
            Log.i(string.Format("Parse Success TDGiftRedeem"));
        }

        private static void OnAddRow(TDGiftRedeem memberInstance)
        {
            int key = memberInstance.id;
            if (m_DataCache.ContainsKey(key))
            {
                Log.e(string.Format("Invaild,  TDGiftRedeemTable Id already exists {0}", key));
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

        public static List<TDGiftRedeem> dataList
        {
            get 
            {
                return m_DataList;
            }    
        }

        public static TDGiftRedeem GetData(int key)
        {
            if (m_DataCache.ContainsKey(key))
            {
                return m_DataCache[key];
            }
            else
            {
                Log.w(string.Format("Can't find key {0} in TDGiftRedeem", key));
                return null;
            }
        }
    }
}//namespace LR