using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTips : MonoBehaviour
{

    Transform m_trsSelf;
    public GameObject m_objBackTips;

    float m_dwShowTimes = 0;
    float m_dwShowMaxTimes = 2.0f;
    void Awake()
    {
        m_trsSelf = this.transform;
    }

    private void Update()
    {
        //Update 里面来做控制 
        if (!m_isShowBackTip)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
            {
                m_isShowBackTip = true;
                m_dwShowTimes = 0;
                SetTipShow();
            }
        }
        else
        {
            if (m_dwShowTimes < m_dwShowMaxTimes)
            {
                m_dwShowTimes+=0.02f;
                if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
            else
            {
                CancleTips();
            }  
        }
        //Test
       
    }

    private void LateUpdate()
    {
      //  if (m_trsSelf.localPosition != m_v3InitPos)
           // InitPos();
    }

    Vector3 m_v3InitPos = new Vector3(0, 0.04f, 1);
    private void OnEnable()
    {
        CancleTips();
    }
    
    public void InitPos()
    {
        if (Camera.main == null)
            return;
        m_trsSelf.SetParent(Camera.main.transform);
        m_trsSelf.localScale = new Vector3(0.0046f, 0.0046f, 0.0046f);
        m_trsSelf.localEulerAngles = Vector3.zero;
        m_trsSelf.localPosition = new Vector3(0, 0.04f, 1);
    }

    bool m_isShowBackTip=false;
    public void SetTipShow()
    {
        if (!m_objBackTips.activeSelf)
            m_objBackTips.SetActive(true);
    }

    void CancleTips()
    {
        m_isShowBackTip = false;
        if (m_objBackTips.activeSelf)
            m_objBackTips.SetActive(false);
    }

}