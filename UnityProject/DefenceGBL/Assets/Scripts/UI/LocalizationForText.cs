using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationForText : MonoBehaviour {

    public Text m_textSelf;

    void Awake()
    {
        m_textSelf = this.GetComponent<Text>();
    }

    public string m_strCh;
    public string m_strEn;

	// Use this for initialization
	void Start () {
        m_textSelf.text = GameContrl.LANGUAGE == "zh" ? m_strCh : m_strEn;
	}
}
