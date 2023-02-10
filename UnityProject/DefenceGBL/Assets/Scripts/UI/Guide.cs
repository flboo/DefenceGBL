using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Guide : MonoBehaviour {

	public GameObject GuideUI;
	public GameObject MisssionUI;
	public GameObject OperationUI;
	public Image Pointer1;
	public Image Pointer2;
    
	void Awake()
	{
		if (GameContrl.CurrentLevel == 1) 
		{
			MisssionUI.SetActive (false);
			OperationUI.SetActive (true);
			Pointer2.color = new Color (1, 1, 1, 0.5f);
			Pointer1.color = new Color (1, 1, 1, 1f);
		} 
		else
		{
            GuideUI.SetActive(false);
		}
	}
    
	/// <summary>
	/// 关闭引导
	/// </summary>
	public void CloseGuideUI()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
        Debug.LogError("aInitAndStartGame  gdsdsdag");
        if (GameContrl.CurrentLevel == 1)
			GameContrl.GetInstance.InitAndStartGame();
		GuideUI.SetActive (false);
	}
	/// <summary>
	/// 向左按钮
	/// </summary>
	public void LeftButton()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
		if(!OperationUI.activeInHierarchy)
		{
			MisssionUI.SetActive (false);
			OperationUI.SetActive (true);
			Pointer2.color = new Color (1,1,1,0.5f);
			Pointer1.color = new Color (1,1,1,1f);
		}
	}
	/// <summary>
	/// 向右按钮
	/// </summary>
	public void RightButton()
	{
		AudioContrl.GetInstance ().PlayAudio ("ClickUI");
		if(!MisssionUI.activeInHierarchy)
		{
			MisssionUI.SetActive (true);
			OperationUI.SetActive (false);
			Pointer1.color = new Color (1,1,1,0.5f);
			Pointer2.color = new Color (1,1,1,1f);
		}
	}
}
