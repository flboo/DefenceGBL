using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointerPosition : MonoBehaviour 
{
    public void SetGazedAt(bool gazedAt)
    {
        GameContrl.GetInstance.g_Ponter = this.gameObject;
        if (gazedAt)
        {
            GameContrl.GetInstance.t_ERange.position = this.transform.position + Vector3.up * 1f;
            GameContrl.GetInstance.t_ERange.gameObject.SetActive(true);
            GameContrl.m_eCurReticleFoceState = eReticleFoceState.eFoceTerrain;
            Debug.LogWarning("GetPointerPosition  =" + GameContrl.m_eCurReticleFoceState);
        }
        else
        {
            GameContrl.GetInstance.t_ERange.gameObject.SetActive(false);
            GameContrl.m_eCurReticleFoceState = eReticleFoceState.eNone;
            Debug.LogWarning("GetPointerPosition   =" + GameContrl.m_eCurReticleFoceState);
        }
    }

    public void OnGazeEnter()
    {
        //GameContrl.GetInstance.PointerPos = this.transform;
    }

    public void OnGazeExit()
    {
        GameContrl.GetInstance.t_ERange.gameObject.SetActive(false);
    }

    public void OnGazeTrigger()
    {

    }
    GameObject bb;
    GameObject cc;
    GameObject dd;
    public void ReleaseSkill()
    {
        //Debug.Log("释放技能");
        if (!GameContrl.IsPlaying || UIGameContrl.m_currentshowUI != UIGameContrl.CurrentShowUI.SkillUI || !GameContrl.instance.IsCanCheck)
			return;

        //GameContrl.instance.SetHandleShake();

        //释放技能
        switch (GameContrl.ChoosedSkillType)
		{
		case SkillsType.FireBall:
			if (GameContrl.GetInstance.skillcontrl.CanFire == false) {
				return;
			}
			GameContrl.GetInstance.skillcontrl.CanFire = false;
			GameContrl.GetInstance.skillcontrl.Fire_time = Time.time;
			GameObject aa = Instantiate (GameContrl.GetInstance.g_FireBall, new Vector3 (2.5f, 6.44f, -2.25f), Quaternion.identity);
			aa.transform.parent = GameContrl.GetInstance.t_MainCamera;
			aa.transform.localPosition = new Vector3 (0, -0.76f, 1.35f);
            //aa.GetComponent<Bullet> ().SetTarget (GameContrl.GetInstance.g_Ponter,Mathf.FloorToInt(30*(1 + (GameContrl.FireBallLevel-1)*0.3f)));
            aa.GetComponent<Bullet>().SetTarget(GameContrl.GetInstance.g_Ponter, Mathf.FloorToInt(30 * (1 + (GameContrl.FireBallLevel - 1) * 0.3f)));
            aa.transform.SetParent(UtilTools.Instance.m_Scenes);
                AudioContrl.GetInstance ().PlayAudio ("FireBall");
                break;
		case SkillsType.Tornado:
			if (GameContrl.GetInstance.skillcontrl.CanTornado == false)
			{
				return;
			}
			GameContrl.GetInstance.skillcontrl.CanTornado = false;
			GameContrl.GetInstance.skillcontrl.Tornado_time = Time.time;
			if(GameContrl.GetInstance.g_Ponter.layer == 10)
			{
				if(GameContrl.GetInstance.g_Ponter.CompareTag("Building_Step"))
					bb = Instantiate (GameContrl.GetInstance.g_Tornado, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+0.5f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
				else
					bb = Instantiate (GameContrl.GetInstance.g_Tornado, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+1f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
			}
			else if(GameContrl.GetInstance.g_Ponter.layer == 9)
				bb = Instantiate (GameContrl.GetInstance.g_Tornado, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
                bb.transform.SetParent(UtilTools.Instance.m_Scenes);
                break;

		case SkillsType.Swamp:
			if (GameContrl.GetInstance.skillcontrl.CanSwamp == false)
			{
				return;
			}
			GameContrl.GetInstance.skillcontrl.CanSwamp = false;
			GameContrl.GetInstance.skillcontrl.Swamp_time = Time.time;
			if(GameContrl.GetInstance.g_Ponter.layer == 10)
			{
				if(GameContrl.GetInstance.g_Ponter.CompareTag("Building_Step"))
					cc = Instantiate (GameContrl.GetInstance.g_Swamp, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+0.5f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
				else
					cc = Instantiate (GameContrl.GetInstance.g_Swamp, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+1f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
			}
			else if(GameContrl.GetInstance.g_Ponter.layer == 9)
				cc = Instantiate (GameContrl.GetInstance.g_Swamp, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
                cc.transform.SetParent(UtilTools.Instance.m_Scenes);
                break;

		case SkillsType.Duwu:
			if (GameContrl.GetInstance.skillcontrl.CanDuwu == false)
			{
				return;
			}
			GameContrl.GetInstance.skillcontrl.CanDuwu = false;
			GameContrl.GetInstance.skillcontrl.Duwu_time = Time.time;
			if(GameContrl.GetInstance.g_Ponter.layer == 10)
			{
				if(GameContrl.GetInstance.g_Ponter.CompareTag("Building_Step"))
					dd = Instantiate (GameContrl.GetInstance.g_Duwu, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+0.5f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
				else
					dd = Instantiate (GameContrl.GetInstance.g_Duwu, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y+1f,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
			}
			else if(GameContrl.GetInstance.g_Ponter.layer == 9)
				dd = Instantiate (GameContrl.GetInstance.g_Duwu, new Vector3(GameContrl.GetInstance.g_Ponter.transform.position.x, GameContrl.GetInstance.g_Ponter.transform.position.y,GameContrl.GetInstance.g_Ponter.transform.position.z), Quaternion.identity);
                dd.transform.SetParent(UtilTools.Instance.m_Scenes);
                break;

		}
	}
}
