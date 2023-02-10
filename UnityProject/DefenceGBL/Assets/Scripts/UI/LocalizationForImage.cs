using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationForImage : MonoBehaviour {

	public Image m_imageSelf;

	void Awake()
	{
		m_imageSelf = this.GetComponent<Image>();
	}

	public Sprite m_spriteCh;
	public Sprite m_spriteEn;

	// Use this for initialization
	void Start()
	{
		m_imageSelf.sprite = GameContrl.LANGUAGE == "zh" ? m_spriteCh : m_spriteEn;
		m_imageSelf.SetNativeSize();
	}
}
