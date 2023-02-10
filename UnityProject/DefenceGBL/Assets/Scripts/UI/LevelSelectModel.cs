using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelectModel: MonoBehaviour
{
	public static int[] StarsData = new int[21];
	public UIMenuContrl uiMenuContrl;
	public LevelAttribute[] La;
	public Image S_Chapter;
	public Sprite[] ChapterNums;
	public Sprite[] LevelNums;
	public Sprite[] ChapterNums_EN;
	public Sprite[] LevelNums_EN;
	private int CurrentChapter = 1;
	public DataSave datasave;

	public GameObject g_Mission;
    public GameObject g_Loading;
    public Text Mission1Name;
	public Text Mission2Name;
	public Text Mission3Name;

    public GameObject g_Scene;

	void Awake()
	{
		if(PlayerPrefs.HasKey("StarsData"))
			StarsData = PlayerPrefsX.GetIntArray ("StarsData");
		IniteLevelState ();
    }
	void OnEnable()
	{
		if(PlayerPrefs.HasKey("StarsData"))
			StarsData = PlayerPrefsX.GetIntArray ("StarsData");
		IniteLevelState ();
	}
	/// <summary>
	/// 初始化关卡状态
	/// </summary>
	void  IniteLevelState()
	{
		datasave.GetDataSave ();
		for (int i = 0; i < 5; i++)
		{
			if (i+1+(CurrentChapter-1)*5 <= GameContrl.GetMaxLevel)
			{
				La [i].SetIconImage(2);
			} 
			else if(i+1+(CurrentChapter-1)*5 == GameContrl.GetMaxLevel + 1)
			{
				La [i].SetIconImage(1);
			}
			else if(i+1+(CurrentChapter-1)*5 > GameContrl.GetMaxLevel + 1)
			{
				La [i].SetIconImage(0);
			}
			La [i].SetStars (StarsData[i+1+(CurrentChapter-1)*5]);
			if(Application.systemLanguage == SystemLanguage.English)
			{
				La[i].image_Level.sprite = LevelNums_EN[i+1+(CurrentChapter-1)*5];
				S_Chapter.sprite = ChapterNums_EN [CurrentChapter];
			}
			else
			{
				La[i].image_Level.sprite = LevelNums[i+1+(CurrentChapter-1)*5];
				S_Chapter.sprite = ChapterNums [CurrentChapter];
			}
		}
	}

	int GetLevelAttribute(int aa)
	{
		if(aa%5 == 0)
		{
			return 4;
		}
		else
		{
			return (aa % 5 - 1);
		}
	}

	/// <summary>
	/// 上一章
	/// </summary>
	public void LastPage()
	{
		uiMenuContrl.PlayAudio ();
		CurrentChapter--;
		if(CurrentChapter < 1)
		{
			CurrentChapter = 1;
			return;
		}
		if(Application.systemLanguage == SystemLanguage.English)
			S_Chapter.sprite = ChapterNums_EN [CurrentChapter];
		else
			S_Chapter.sprite = ChapterNums [CurrentChapter];
		IniteLevelState ();
	}
	/// <summary>
	/// 下一章
	/// </summary>
	public void NextPage()
	{
		uiMenuContrl.PlayAudio ();
		CurrentChapter++;
		if(CurrentChapter > 4)
		{
			CurrentChapter = 4;
			return;
		}
		S_Chapter.sprite = ChapterNums [CurrentChapter];
		IniteLevelState ();
	}
	/// <summary>
	/// 关闭
	/// </summary>
	public void Close()
	{
		
	}


	public void StartGame(int level)
	{
		uiMenuContrl.PlayAudio ();
        GameContrl.CurrentLevel = level + 5*(CurrentChapter-1);
        GameContrl.LoadingSceneName = "Game";
        StartCoroutine("AsyncLoad");
    }

    IEnumerator AsyncLoad()
    {
        g_Scene.transform.parent.gameObject.SetActive(false);
        TipsManager.m_bIsLoading = true;
        AsyncOperation op = SceneManager.LoadSceneAsync("Loading");
        while (!op.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene("Loading");
    }


public void ShowMission(int Level)
	{
		g_Mission.SetActive (true);
        switch (Level)
        {
            case 1:
                g_Mission.transform.localPosition = new Vector3(-18,54,0);
                break;
            case 2:
                g_Mission.transform.localPosition = new Vector3(34, -54, 0);
                break;
            case 3:
                g_Mission.transform.localPosition = new Vector3(110, 60, 0);
                break;
            case 4:
                g_Mission.transform.localPosition = new Vector3(130, -54, 0);
                break;
            case 5:
                g_Mission.transform.localPosition = new Vector3(214, 16, 0);
                break;
        }

		if(Application.systemLanguage == SystemLanguage.English)
		{
			Mission1Name.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[Level].x];
			Mission2Name.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[Level].y];
			Mission3Name.text = MissionContrl.MissionName_EN[(int)MissionContrl.MissionNumByLevel[Level].z];
		}
		else
		{
			Mission1Name.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[Level].x];
			Mission2Name.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[Level].y];
			Mission3Name.text = MissionContrl.MissionName[(int)MissionContrl.MissionNumByLevel[Level].z];
		}
	}

	public void DismissMission()
	{
		g_Mission.SetActive (false);
	}


}



