//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDOnlineReward
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_Second = 0;   
        private EInt m_RewardType = 0;   
        private string m_Reward;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// Name
        /// </summary>
        public  int  second {get { return m_Second; } }
       
        /// <summary>
        /// RewardType(0:金币  1：道具  2：美分)
        /// </summary>
        public  int  rewardType {get { return m_RewardType; } }
       
        /// <summary>
        /// reward(:keu:value ==> 0:金币  1:横向  2:纵向   3炸弹  4彩色)(道具案例：1|5,2|5,3|5,4|5)
        /// </summary>
        public  string  reward {get { return m_Reward; } }
       

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
                    m_Second = dataR.ReadInt();
                    break;
                case 2:
                    m_RewardType = dataR.ReadInt();
                    break;
                case 3:
                    m_Reward = dataR.ReadString();
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
          ret.Add("Second", 1);
          ret.Add("RewardType", 2);
          ret.Add("Reward", 3);
          return ret;
        }
    } 
}//namespace LR