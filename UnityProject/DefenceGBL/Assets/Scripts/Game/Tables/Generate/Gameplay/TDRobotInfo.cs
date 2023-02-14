//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDRobotInfo
    {
        
       
        private EInt m_ID = 0;   
        private string m_RobotName;   
        private string m_RobotPortrail;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 用户id
        /// </summary>
        public  int  iD {get { return m_ID; } }
       
        /// <summary>
        /// 用户名称
        /// </summary>
        public  string  robotName {get { return m_RobotName; } }
       
        /// <summary>
        /// 用户头像
        /// </summary>
        public  string  robotPortrail {get { return m_RobotPortrail; } }
       

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
                    m_RobotName = dataR.ReadString();
                    break;
                case 2:
                    m_RobotPortrail = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(3);
          
          ret.Add("ID", 0);
          ret.Add("RobotName", 1);
          ret.Add("RobotPortrail", 2);
          return ret;
        }
    } 
}//namespace LR