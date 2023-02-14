//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDTaskDaily
    {
        
       
        private EInt m_Id = 0;   
        private string m_Des;   
        private bool m_ShowProgress = false;   
        private EInt m_AddCDTime = 0;   
        private EInt m_Times = 0;   
        private EInt m_Reward = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 任务内容描述
        /// </summary>
        public  string  des {get { return m_Des; } }
       
        /// <summary>
        /// 次数
        /// </summary>
        public  bool  showProgress {get { return m_ShowProgress; } }
       
        /// <summary>
        /// 次数
        /// </summary>
        public  int  addCDTime {get { return m_AddCDTime; } }
       
        /// <summary>
        /// 次数
        /// </summary>
        public  int  times {get { return m_Times; } }
       
        /// <summary>
        /// 奖励钻石数量
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
                    m_Des = dataR.ReadString();
                    break;
                case 2:
                    m_ShowProgress = dataR.ReadBool();
                    break;
                case 3:
                    m_AddCDTime = dataR.ReadInt();
                    break;
                case 4:
                    m_Times = dataR.ReadInt();
                    break;
                case 5:
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
          Dictionary<string, int> ret = new Dictionary<string, int>(6);
          
          ret.Add("Id", 0);
          ret.Add("Des", 1);
          ret.Add("ShowProgress", 2);
          ret.Add("AddCDTime", 3);
          ret.Add("Times", 4);
          ret.Add("Reward", 5);
          return ret;
        }
    } 
}//namespace LR