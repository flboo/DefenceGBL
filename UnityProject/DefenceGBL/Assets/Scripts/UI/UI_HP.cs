using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    public Image image;

    public void CheckHP(int m_hp, int m_maxhp)
    {
        if(!this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        image.fillAmount = (m_hp * 1.0f / m_maxhp * 1.0f);
        //Invoke("Hide", 1f);
    }

    void Hide()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
