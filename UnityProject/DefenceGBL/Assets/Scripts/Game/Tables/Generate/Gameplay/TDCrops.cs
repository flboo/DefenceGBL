//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDCrops
    {
        
       
        private EInt m_Id = 0;   
        private string m_Name;   
        private string m_NameSpin;   
        private string m_NameAnim1;   
        private string m_NameAnim2;   
        private string m_NameAnim3;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 名称
        /// </summary>
        public  string  name {get { return m_Name; } }
       
        /// <summary>
        /// spin名称
        /// </summary>
        public  string  nameSpin {get { return m_NameSpin; } }
       
        /// <summary>
        /// spin动画名称
        /// </summary>
        public  string  nameAnim1 {get { return m_NameAnim1; } }
       
        /// <summary>
        /// spin动画名称
        /// </summary>
        public  string  nameAnim2 {get { return m_NameAnim2; } }
       
        /// <summary>
        /// spin动画名称
        /// </summary>
        public  string  nameAnim3 {get { return m_NameAnim3; } }
       

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
                    m_NameSpin = dataR.ReadString();
                    break;
                case 3:
                    m_NameAnim1 = dataR.ReadString();
                    break;
                case 4:
                    m_NameAnim2 = dataR.ReadString();
                    break;
                case 5:
                    m_NameAnim3 = dataR.ReadString();
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
          ret.Add("NameSpin", 2);
          ret.Add("NameAnim1", 3);
          ret.Add("NameAnim2", 4);
          ret.Add("NameAnim3", 5);
          return ret;
        }
    } 
}//namespace LR