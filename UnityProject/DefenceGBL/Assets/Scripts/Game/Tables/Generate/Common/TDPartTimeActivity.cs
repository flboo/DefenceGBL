//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDPartTimeActivity
    {
        
       
        private EInt m_Id = 0;   
        private string m_Name;   
        private EInt m_Time = 0;   
        private string m_Desc1;   
        private string m_Desc2;   
        private EInt m_Power = 0;   
        private EInt m_TypeReward = 0;   
        private EInt m_Reward = 0;   
        private string m_IconName;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// id
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 名称
        /// </summary>
        public  string  name {get { return m_Name; } }
       
        /// <summary>
        /// 时间（s）
        /// </summary>
        public  int  time {get { return m_Time; } }
       
        /// <summary>
        /// 描述
        /// </summary>
        public  string  desc1 {get { return m_Desc1; } }
       
        /// <summary>
        /// 描述2
        /// </summary>
        public  string  desc2 {get { return m_Desc2; } }
       
        /// <summary>
        /// 功力为攻击力
        /// </summary>
        public  int  power {get { return m_Power; } }
       
        /// <summary>
        /// 奖励类型1仙玉2红包
        /// </summary>
        public  int  typeReward {get { return m_TypeReward; } }
       
        /// <summary>
        /// 奖励数
        /// </summary>
        public  int  reward {get { return m_Reward; } }
       
        /// <summary>
        /// icon名称
        /// </summary>
        public  string  iconName {get { return m_IconName; } }
       

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
                    m_Time = dataR.ReadInt();
                    break;
                case 3:
                    m_Desc1 = dataR.ReadString();
                    break;
                case 4:
                    m_Desc2 = dataR.ReadString();
                    break;
                case 5:
                    m_Power = dataR.ReadInt();
                    break;
                case 6:
                    m_TypeReward = dataR.ReadInt();
                    break;
                case 7:
                    m_Reward = dataR.ReadInt();
                    break;
                case 8:
                    m_IconName = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(9);
          
          ret.Add("Id", 0);
          ret.Add("Name", 1);
          ret.Add("Time", 2);
          ret.Add("Desc1", 3);
          ret.Add("Desc2", 4);
          ret.Add("Power", 5);
          ret.Add("TypeReward", 6);
          ret.Add("Reward", 7);
          ret.Add("IconName", 8);
          return ret;
        }
    } 
}//namespace LR