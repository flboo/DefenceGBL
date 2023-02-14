//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDOrderChatInfo
    {
        
       
        private EInt m_ID = 0;   
        private EInt m_TargetLevel = 0;   
        private EInt m_RobotId = 0;   
        private string m_ChatType;   
        private string m_SkipScheme;   
        private string m_ChatInfo;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 聊天id
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 目标订单等级
        /// </summary>
        public  int  targetLevel {get { return m_TargetLevel; } }
       
        /// <summary>
        /// 所属人员id(-1 ：我  其它：robotid)
        /// </summary>
        public  int  robotId {get { return m_RobotId; } }
       
        /// <summary>
        /// 类型（Word：文字描述  Order：订单信息 ）Pack：红包
        /// </summary>
        public  string  chatType {get { return m_ChatType; } }
       
        /// <summary>
        /// 跳转方案
        /// </summary>
        public  string  skipScheme {get { return m_SkipScheme; } }
       
        /// <summary>
        /// 内容
        /// </summary>
        public  string  chatInfo {get { return m_ChatInfo; } }
       

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
                    m_ID = dataR.ReadInt();
                    break;
                case 1:
                    m_TargetLevel = dataR.ReadInt();
                    break;
                case 2:
                    m_RobotId = dataR.ReadInt();
                    break;
                case 3:
                    m_ChatType = dataR.ReadString();
                    break;
                case 4:
                    m_SkipScheme = dataR.ReadString();
                    break;
                case 5:
                    m_ChatInfo = dataR.ReadString();
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
          
          ret.Add("ID", 0);
          ret.Add("TargetLevel", 1);
          ret.Add("RobotId", 2);
          ret.Add("ChatType", 3);
          ret.Add("SkipScheme", 4);
          ret.Add("ChatInfo", 5);
          return ret;
        }
    } 
}//namespace LR