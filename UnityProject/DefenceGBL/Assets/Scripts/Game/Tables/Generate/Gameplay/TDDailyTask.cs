//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDDailyTask
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_TaskDay = 0;   
        private string m_TaskTitle;   
        private EInt m_TaskLimit = 0;   
        private EFloat m_TaskAward = 0.0f;   
        private EInt m_TaskType = 0;   
        private string m_MissionID;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 第几天的任务
        /// </summary>
        public  int  taskDay {get { return m_TaskDay; } }
       
        /// <summary>
        /// 任务名称
        /// </summary>
        public  string  taskTitle {get { return m_TaskTitle; } }
       
        /// <summary>
        /// 任务数值
        /// </summary>
        public  int  taskLimit {get { return m_TaskLimit; } }
       
        /// <summary>
        /// 任务奖励数值
        /// </summary>
        public  float  taskAward {get { return m_TaskAward; } }
       
        /// <summary>
        /// 任务类型
        /// </summary>
        public  int  taskType {get { return m_TaskType; } }
       
        /// <summary>
        /// MissionID
        /// </summary>
        public  string  missionID {get { return m_MissionID; } }
       

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
                    m_TaskDay = dataR.ReadInt();
                    break;
                case 2:
                    m_TaskTitle = dataR.ReadString();
                    break;
                case 3:
                    m_TaskLimit = dataR.ReadInt();
                    break;
                case 4:
                    m_TaskAward = dataR.ReadFloat();
                    break;
                case 5:
                    m_TaskType = dataR.ReadInt();
                    break;
                case 6:
                    m_MissionID = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(7);
          
          ret.Add("Id", 0);
          ret.Add("TaskDay", 1);
          ret.Add("TaskTitle", 2);
          ret.Add("TaskLimit", 3);
          ret.Add("TaskAward", 4);
          ret.Add("TaskType", 5);
          ret.Add("MissionID", 6);
          return ret;
        }
    } 
}//namespace LR