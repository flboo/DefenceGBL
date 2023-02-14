//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDTaskDayLimit
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_OpenDay = 0;   
        private string m_TotalAmount;   
        private string m_OpenDayTitle;   
        private string m_AdditionLimit;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 第几天打开
        /// </summary>
        public  int  openDay {get { return m_OpenDay; } }
       
        /// <summary>
        /// 至当天总收益
        /// </summary>
        public  string  totalAmount {get { return m_TotalAmount; } }
       
        /// <summary>
        /// 第几天打开
        /// </summary>
        public  string  openDayTitle {get { return m_OpenDayTitle; } }
       
        /// <summary>
        /// 额外条件
        /// </summary>
        public  string  additionLimit {get { return m_AdditionLimit; } }
       

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
                    m_OpenDay = dataR.ReadInt();
                    break;
                case 2:
                    m_TotalAmount = dataR.ReadString();
                    break;
                case 3:
                    m_OpenDayTitle = dataR.ReadString();
                    break;
                case 4:
                    m_AdditionLimit = dataR.ReadString();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(5);
          
          ret.Add("Id", 0);
          ret.Add("OpenDay", 1);
          ret.Add("TotalAmount", 2);
          ret.Add("OpenDayTitle", 3);
          ret.Add("AdditionLimit", 4);
          return ret;
        }
    } 
}//namespace LR