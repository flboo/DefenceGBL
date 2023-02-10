using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageCtrl : MonoBehaviour {

	public static SystemLanguage sl;

	public Sprite s_CH;
	public Sprite s_EN;

	Image m_image;

	void Awake()
	{
		m_image = GetComponent<Image> ();
		sl = Application.systemLanguage;
		if(sl == SystemLanguage.Chinese || sl == SystemLanguage.ChineseSimplified || sl == SystemLanguage.ChineseTraditional)
		{
			m_image.sprite = s_CH;
		}
		else if(sl == SystemLanguage.English)
		{
			m_image.sprite = s_EN;
		}
		else
		{
			m_image.sprite = s_CH;
		}
	}

	void OnEnable()
	{
		m_image = GetComponent<Image> ();
		if(sl == SystemLanguage.Chinese || sl == SystemLanguage.ChineseSimplified || sl == SystemLanguage.ChineseTraditional)
		{
			m_image.sprite = s_CH;
		}
		else if(sl == SystemLanguage.English)
		{
			m_image.sprite = s_EN;
		}
		else
		{
			m_image.sprite = s_CH;
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			m_image.sprite = s_CH;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			m_image.sprite = s_EN;
		}
	}

}
