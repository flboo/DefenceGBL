//Auto Generate Don't Edit it
using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Qarth;

namespace GameWish.Game
{
    public partial class TDGiftRedeem
    {
        
       
        private EInt m_Id = 0;   
        private string m_Name;   
        private string m_Desc;   
        private EInt m_CashNum = 0;   
        private EInt m_OrderNum = 0;   
        private string m_Icon;   
        private EInt m_InviteNum = 0;  
        
        //private Dictionary<string, TDUniversally.FieldData> m_DataCacheNoGenerate = new Dictionary<string, TDUniversally.FieldData>();
      
        /// <summary>
        /// 道具ID
        /// </summary>
        public  int  id {get { return m_Id; } }
       
        /// <summary>
        /// 名称
        /// </summary>
        public  string  name {get { return m_Name; } }
       
        /// <summary>
        /// 描述
        /// </summary>
        public  string  desc {get { return m_Desc; } }
       
        /// <summary>
        /// 金额
        /// </summary>
        public  int  cashNum {get { return m_CashNum; } }
       
        /// <summary>
        /// 订单数
        /// </summary>
        public  int  orderNum {get { return m_OrderNum; } }
       
        /// <summary>
        /// Icon
        /// </summary>
        public  string  icon {get { return m_Icon; } }
       
        /// <summary>
        /// 邀请人数
        /// </summary>
        public  int  inviteNum {get { return m_InviteNum; } }
       

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
                    m_Desc = dataR.ReadString();
                    break;
                case 3:
                    m_CashNum = dataR.ReadInt();
                    break;
                case 4:
                    m_OrderNum = dataR.ReadInt();
                    break;
                case 5:
                    m_Icon = dataR.ReadString();
                    break;
                case 6:
                    m_InviteNum = dataR.ReadInt();
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
          ret.Add("Name", 1);
          ret.Add("Desc", 2);
          ret.Add("CashNum", 3);
          ret.Add("OrderNum", 4);
          ret.Add("Icon", 5);
          ret.Add("InviteNum", 6);
          return ret;
        }
    } 
}//namespace LR