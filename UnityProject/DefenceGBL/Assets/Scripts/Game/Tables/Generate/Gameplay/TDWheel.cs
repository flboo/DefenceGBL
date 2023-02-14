//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDWheel
    {
        
       
        private EInt m_Id = 0;   
        private string m_Name;   
        private EInt m_Type = 0;   
        private EInt m_Num = 0;   
        private EInt m_Rate = 0;   
        private string m_Icon;  
        
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
        /// 类型（1 钻石  2 红包）
        /// </summary>
        public  int  type {get { return m_Type; } }
       
        /// <summary>
        /// 数量
        /// </summary>
        public  int  num {get { return m_Num; } }
       
        /// <summary>
        /// 概率
        /// </summary>
        public  int  rate {get { return m_Rate; } }
       
        /// <summary>
        /// Icon
        /// </summary>
        public  string  icon {get { return m_Icon; } }
       

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
                    m_Type = dataR.ReadInt();
                    break;
                case 3:
                    m_Num = dataR.ReadInt();
                    break;
                case 4:
                    m_Rate = dataR.ReadInt();
                    break;
                case 5:
                    m_Icon = dataR.ReadString();
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
          ret.Add("Name", 1);
          ret.Add("Type", 2);
          ret.Add("Num", 3);
          ret.Add("Rate", 4);
          ret.Add("Icon", 5);
          return ret;
        }
    } 
}//namespace LR