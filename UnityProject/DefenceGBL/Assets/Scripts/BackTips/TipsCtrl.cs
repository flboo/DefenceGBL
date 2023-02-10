using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TipsCtrl : MonoBehaviour
{
    Transform m_trsSelf;
    bool m_IsFollow = false;
    private void Awake()
    {
        m_trsSelf = this.transform;
    }

    public void InitTipsUIPos()
    {
         // if (TipsManager.m_bIsFindMarker)
         //{
         // }
         // else
         // {
         //   m_trsSelf.SetParent(null, false);
         // /     m_trsSelf.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
         //   m_trsSelf.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
         //   m_trsSelf.localScale = new Vector3(0.01f, 0.01f, 0.01f);
         //   }
    }

    public void CloseUIBtn()
    {
        HideSelf();
    }

    public void CloseGameBtn()
    {
        if (!TipsManager.m_bIsFindMarker)
        {
            Application.Quit();
            return;
        }
      
    }

    public void HideSelf()
    {
        m_trsSelf.gameObject.SetActive(false);
    }
}
