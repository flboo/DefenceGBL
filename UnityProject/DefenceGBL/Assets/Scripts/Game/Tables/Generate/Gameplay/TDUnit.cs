//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDUnit
    {
        
       
        private EInt m_Id = 0;   
        private string m_First_part;   
        private string m_Second_part;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 道具ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 计算时间
        /// </summary>
        public  string  first_part {get { return m_First_part; } }
       
        /// <summary>
        /// 售价
        /// </summary>
        public  string  second_part {get { return m_Second_part; } }
       

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
                    m_First_part = dataR.ReadString();
                    break;
                case 2:
                    m_Second_part = dataR.ReadString();
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
          
          ret.Add("Id", 0);
          ret.Add("First_part", 1);
          ret.Add("Second_part", 2);
          return ret;
        }
    } 
}//namespace LR