using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager
{
    public static bool m_bIsFindMarker=true;
    public static bool m_bIsLoading = false;
    #region SingelClass TipsManager
    private static TipsManager m_instance = null;
    public static TipsManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = new TipsManager();
            return m_instance;
        }
    }
    #endregion
    
    private TipsManager()
    {

    }

    #region TipsUI

    public TipsCtrl m_trsTipsCtrl = null;
    public void ShowTipsUI()
    {
        if (m_trsTipsCtrl == null)
        {
            GetTipsUI();
        }
        m_trsTipsCtrl.InitTipsUIPos();
        m_trsTipsCtrl.gameObject.SetActive(true);
    }

    public void HideTipsUI()
    {
        if (m_trsTipsCtrl != null && m_trsTipsCtrl.gameObject.activeSelf)
        {
            m_trsTipsCtrl.HideSelf();
        }
    }

    void GetTipsUI()
    {
       m_trsTipsCtrl = GameObject.Instantiate(Resources.Load<TipsCtrl>("BackUI/UITips"));
    }
    #endregion

    #region MarkerTips
    public MarkerTips m_cMarkerTips = null;

    public void ShowMarkerTipsUI()
    {
        if (m_cMarkerTips == null)
            GetMarkerTipsUI();
        if (!m_cMarkerTips.gameObject.activeSelf)
            m_cMarkerTips.gameObject.SetActive(true);
        m_cMarkerTips.InitPos();
    }

    public void HideMarkerTipsUI()
    {
        if (m_cMarkerTips != null && m_cMarkerTips.gameObject.activeSelf)
        {
            m_cMarkerTips.gameObject.SetActive(false);
        }
    }

    void GetMarkerTipsUI()
    {
        m_cMarkerTips = GameObject.Instantiate(Resources.Load<MarkerTips>("BackUI/MarkerTips"));
       
    }

    #endregion
}


