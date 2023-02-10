using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour {

    public GameObject g_UI;


    //IEnumerator Awake()
    //{
    //    Time.timeScale = 1;
    //    yield return new WaitForSeconds(0.5f);
    //    GameObject m_trs = Instantiate(g_UI,this.transform);
    //    m_trs.transform.localPosition = new Vector3(-60,-96,772);

    //}

	IEnumerator Start ()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(GameContrl.LoadingSceneName);
    }

}
