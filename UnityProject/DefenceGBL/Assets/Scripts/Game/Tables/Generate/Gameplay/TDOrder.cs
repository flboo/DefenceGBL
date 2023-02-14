//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDOrder
    {
        
       
        private EInt m_Id = 0;   
        private EInt m_Crop1 = 0;   
        private EInt m_Crop2 = 0;   
        private EInt m_Crop3 = 0;   
        private EInt m_Crop4 = 0;   
        private EInt m_Crop5 = 0;   
        private EInt m_Crop6 = 0;   
        private EInt m_Crop7 = 0;   
        private EInt m_Crop8 = 0;   
        private EInt m_Crop9 = 0;   
        private EInt m_Reward = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop1 {get { return m_Crop1; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop2 {get { return m_Crop2; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop3 {get { return m_Crop3; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop4 {get { return m_Crop4; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop5 {get { return m_Crop5; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop6 {get { return m_Crop6; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop7 {get { return m_Crop7; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop8 {get { return m_Crop8; } }
       
        /// <summary>
        /// 农作物
        /// </summary>
        public  int  crop9 {get { return m_Crop9; } }
       
        /// <summary>
        /// 奖励
        /// </summary>
        public  int  reward {get { return m_Reward; } }
       

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
                    m_Crop1 = dataR.ReadInt();
                    break;
                case 2:
                    m_Crop2 = dataR.ReadInt();
                    break;
                case 3:
                    m_Crop3 = dataR.ReadInt();
                    break;
                case 4:
                    m_Crop4 = dataR.ReadInt();
                    break;
                case 5:
                    m_Crop5 = dataR.ReadInt();
                    break;
                case 6:
                    m_Crop6 = dataR.ReadInt();
                    break;
                case 7:
                    m_Crop7 = dataR.ReadInt();
                    break;
                case 8:
                    m_Crop8 = dataR.ReadInt();
                    break;
                case 9:
                    m_Crop9 = dataR.ReadInt();
                    break;
                case 10:
                    m_Reward = dataR.ReadInt();
                    break;
                default:
                    //TableHelper.CacheNewField(dataR, schemeNames[col], m_DataCacheNoGenerate);
                    break;
            }
          }

        }
        
        public static Dictionary<string, int> GetFieldHeadIndex()
        {
          Dictionary<string, int> ret = new Dictionary<string, int>(11);
          
          ret.Add("Id", 0);
          ret.Add("Crop1", 1);
          ret.Add("Crop2", 2);
          ret.Add("Crop3", 3);
          ret.Add("Crop4", 4);
          ret.Add("Crop5", 5);
          ret.Add("Crop6", 6);
          ret.Add("Crop7", 7);
          ret.Add("Crop8", 8);
          ret.Add("Crop9", 9);
          ret.Add("Reward", 10);
          return ret;
        }
    } 
}//namespace LR