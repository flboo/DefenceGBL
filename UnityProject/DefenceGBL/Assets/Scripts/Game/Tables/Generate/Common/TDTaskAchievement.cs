//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDTaskAchievement
    {
        
       
        private EInt m_Id = 0;   
        private string m_Des;   
        private string m_Num;   
        private string m_RewardType;   
        private EInt m_RewardNum = 0;   
        private string m_Img;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 任务内容
        /// </summary>
        public  string  des {get { return m_Des; } }
       
        /// <summary>
        /// 次数
        /// </summary>
        public  string  num {get { return m_Num; } }
       
        /// <summary>
        /// 奖励类型
        /// </summary>
        public  string  rewardType {get { return m_RewardType; } }
       
        /// <summary>
        /// 数值
        /// </summary>
        public  int  rewardNum {get { return m_RewardNum; } }
       
        /// <summary>
        /// icon
        /// </summary>
        public  string  img {get { return m_Img; } }
       

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
                    m_Num = dataR.ReadString();
                    break;
                case 3:
                    m_RewardType = dataR.ReadString();
                    break;
                case 4:
                    m_RewardNum = dataR.ReadInt();
                    break;
                case 5:
                    m_Img = dataR.ReadString();
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
          ret.Add("Num", 2);
          ret.Add("RewardType", 3);
          ret.Add("RewardNum", 4);
          ret.Add("Img", 5);
          return ret;
        }
    } 
}//namespace LR