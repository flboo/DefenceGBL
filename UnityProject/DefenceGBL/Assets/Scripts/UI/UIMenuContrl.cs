using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIMenuContrl : MonoBehaviour {
	public Transform t_ChooseBook;
	public Transform t_SkillBook;
	public Animator a_SkillBook;
	public Animator a_LevelBook;
	bool b_SkillBook;
	bool b_LevelBook;
	Vector3 ChooseLevelBookPos = new Vector3 (0.3f,0.76f,0);
	Vector3 SkillBookPos = new Vector3 (-0.03f,0.76f,0);
	Vector3 TargetPos = new Vector3(0.08f,1.5f,0.4f);
	int CurrentBook;

	public GameObject LevelSelect;
	public GameObject SkillUpdate;

	public GameObject g_EFlashing;
	public GameObject EflashL;
	public GameObject EflashR;
	public AudioSource audioSource;
	public AudioClip UIClick;

    public Transform QuitParentRoot;
    public GameObject g_Quit;

    public void Awake()
    {
        b_LevelBook = false;
        b_SkillBook = false;
        if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.ChineseTraditional)
            GameContrl.LANGUAGE = "zh";
        else
            GameContrl.LANGUAGE = "en";
    }

	public void OpenSkillBook()
	{
		PlayAudio ();
		if (b_LevelBook || IsShowQuit)
			return;
        EflashL.SetActive(false);
        EflashR.SetActive(false);
		b_SkillBook = true;
		a_SkillBook.SetBool ("Open",true);
		Invoke ("ShowSkillUpdate",2.4f);
        t_SkillBook.GetComponent<BoxCollider>().enabled = false;
    }
	void ShowSkillUpdate()
	{
		SkillUpdate.SetActive (true);
	}
	public void CloseSkillBook()
	{
		PlayAudio ();
		b_SkillBook = false;
		Invoke("CloseSkillBookFirst",2f);
		a_SkillBook.SetBool ("Open",false);
		SkillUpdate.SetActive (false);
        t_SkillBook.GetComponent<BoxCollider>().enabled = true;
    }

	void CloseSkillBookFirst()
	{
        EflashL.SetActive(true);
        EflashR.SetActive(true);
    }

	void CloseLevelBookFirst()
	{
		EflashL.SetActive (true);
        EflashR.SetActive(true);
    }

	public void OpenLevelBook()
	{
		PlayAudio ();
		if (b_SkillBook || IsShowQuit)
			return;
        EflashR.SetActive(false);
        EflashL.SetActive(false);
		b_LevelBook = true;
		a_LevelBook.SetBool ("Open",true);
        CancelInvoke("ShowLevelBook");
        Invoke ("ShowLevelBook",2.4f);
	}
	void ShowLevelBook()
	{
        Debug.Log("出现书本关卡");
        LevelSelect.SetActive (true);
	}


	public void CloseLevelBook()
	{
		PlayAudio ();
		b_LevelBook = false;
        CancelInvoke("CloseLevelBookFirst");
		Invoke("CloseLevelBookFirst",2f);
		a_LevelBook.SetBool ("Open",false);
        CancelInvoke("ShowLevelBook");
        LevelSelect.SetActive (false);
        if (a_LevelBook.GetBool("Open")==true)
            a_LevelBook.SetBool("Open", false);
	}

	public void PlayAudio()
	{
		audioSource.clip = UIClick;
		audioSource.Play ();
	}

	void Start()
	{
        CoreStaticDataManager InitCoreStaticData = CoreStaticDataManager.instance();
	}
    int ClickTime = 0;
    float dwBackTime = 0;
    void Update()
	{
		if(Input.GetKeyDown(KeyCode.Delete))
		{
			PlayerPrefs.DeleteAll ();
		}
        if (TipsManager.m_bIsFindMarker&&(Input.GetButtonDown("joystick button 1") || Input.GetKeyDown(KeyCode.Escape)))
        {
            if (b_SkillBook)
            {
                CloseSkillBook();
                return;
            }
            if (b_LevelBook)
            {
                CloseLevelBook();
                return;
            }
            if (!IsShowQuit)
            {
                //Mark丢失显示在正中央

              //  if (!TipsManager.m_bIsFindMarker)
               // {
                  //  g_Quit.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
                  //  g_Quit.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
                  //  g_Quit.transform.localScale = Vector3.one;
               // }
               // else
              //  {
                    g_Quit.transform.localPosition = Vector3.zero;
                    g_Quit.transform.localRotation = Quaternion.identity;
                    g_Quit.transform.localScale = Vector3.one;
              //  }

                IsShowQuit = true;
                g_Quit.SetActive(true);
            }
            else
            {
                NoQuit();
            }
        }
    }
    public bool IsShowQuit = false;
    public void NoQuit()
    {
        PlayAudio();
        g_Quit.SetActive(false);
        IsShowQuit = false;
    }
    public void QuitGame()
    {
        PlayAudio();
        Application.Quit();
    }

}
