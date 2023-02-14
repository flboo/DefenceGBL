using UnityEngine;
using UnityEngine.SceneManagement;
public class UtilTools
{
	#region SingleClass
	private static  UtilTools m_instance = null;
	public static UtilTools Instance {
		get {
			if (m_instance==null|| m_instance.m_objUtilTools==null)
			{
				m_instance = new UtilTools();
			}
			return m_instance;
		}
	}
	#endregion

	public GameObject m_objUtilTools = null;
    //
    GameObject m_objImgTarget;
    public Transform m_trsImgTarget;
    public Transform m_Scenes;

	public UtilTools()
    {
		m_objUtilTools = new GameObject("UtilTools");  //不同场景之间的使用
        m_objImgTarget = GameObject.Find("ImageTarget");
        m_trsImgTarget = m_objImgTarget.transform;
        m_Scenes = m_trsImgTarget.Find("Scene");
    }
}