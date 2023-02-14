//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDWelfare
    {
        
       
        private EInt m_Id = 0;   
        private string m_Name;   
        private EInt m_Target = 0;   
        private EInt m_Reward = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 道具ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 说明
        /// </summary>
        public  string  name {get { return m_Name; } }
       
        /// <summary>
        /// 目标数
        /// </summary>
        public  int  target {get { return m_Target; } }
       
        /// <summary>
        /// 奖励
        /// </summary>
        public  int  reward {get { return m_Reward; } }
       

        public void ReadRow(DataStreamReader dataR, int[] filedIndex)
        {
          //var schemeNames = dataR.GetSchemeName();
          int col = 0;
          while(true)
          {
            col = dataR.MoreFieldOnRow();
            if (col == -1)
            {
              break;
            }
            switch (filedIndex[col])
            { 
            
                case 0:
                    m_Id = dataR.ReadInt();
                    break;
                case 1:
                    m_Name = dataR.ReadString();
                    break;
                case 2:
                    m_Target = dataR.ReadInt();
                    break;
                case 3:
                    m_Reward = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(4);
          
          ret.Add("Id", 0);
          ret.Add("Name", 1);
          ret.Add("Target", 2);
          ret.Add("Reward", 3);
          return ret;
        }
    } 
}//namespace LR