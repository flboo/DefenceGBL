using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffects : MonoBehaviour {

	public SkillsType skilltype;


	private float time;
	private AudioSource m_audiosource;
	void Awake ()
	{
		m_audiosource = GetComponent<AudioSource> ();
		if(m_audiosource.clip != null)
			m_audiosource.Play ();
		GameContrl.GetInstance.datasave.GetDataSave ();
		if(skilltype == SkillsType.FireBall)
		{

		}
		else if(skilltype == SkillsType.Tornado)
		{
			time = GameContrl.CurrentChoosedSkillAttribute.LastTime + (GameContrl.TornadoLevel-1) * GameContrl.CurrentChoosedSkillAttribute.LastTimeUpgrade;
		}
		else if(skilltype == SkillsType.Swamp)
		{
			time = GameContrl.CurrentChoosedSkillAttribute.LastTime + (GameContrl.SwampLevel-1) * GameContrl.CurrentChoosedSkillAttribute.LastTimeUpgrade;
		}
		else if(skilltype == SkillsType.Duwu)
		{
			time = GameContrl.CurrentChoosedSkillAttribute.LastTime + (GameContrl.DuwuLevel-1) * GameContrl.CurrentChoosedSkillAttribute.LastTimeUpgrade;
		}
		Destroy (this.gameObject,time);
	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		if(other.CompareTag ("Goblin") || other.CompareTag ("RidingGoblin") || other.CompareTag ("Witch") || other.CompareTag ("Skeleton") || other.CompareTag ("Giant"))
		{
			yield return new WaitForSeconds (0.4f);
			if(skilltype == SkillsType.FireBall)
			{

			}
			else if(skilltype == SkillsType.Tornado)
			{
				other.gameObject.GetComponent<MonsterSelfContrl> ().GetAttack (Mathf.FloorToInt(GameContrl.CurrentChoosedSkillAttribute.AttackNum*(1 + (GameContrl.TornadoLevel-1)*GameContrl.CurrentChoosedSkillAttribute.AttackNumUpgrade)));
				other.gameObject.GetComponent<MonsterSelfContrl> ().Vertigo (3*(1+(GameContrl.TornadoLevel - 1)*1),GameContrl.CurrentChoosedSkillAttribute.SlowDown + (GameContrl.TornadoLevel-1)*GameContrl.CurrentChoosedSkillAttribute.SlowDownUpgrade);
			}
			else if(skilltype == SkillsType.Swamp)
			{
				other.gameObject.GetComponent<MonsterSelfContrl> ().GetAttack (Mathf.FloorToInt(GameContrl.CurrentChoosedSkillAttribute.AttackNum*(1 + (GameContrl.SwampLevel-1)*GameContrl.CurrentChoosedSkillAttribute.AttackNumUpgrade)));
				other.gameObject.GetComponent<MonsterSelfContrl> ().Vertigo (3*(1+(GameContrl.SwampLevel - 1)*1),GameContrl.CurrentChoosedSkillAttribute.SlowDown + (GameContrl.SwampLevel-1)*GameContrl.CurrentChoosedSkillAttribute.SlowDownUpgrade);
			}
			else if(skilltype == SkillsType.Duwu)
			{
				other.gameObject.GetComponent<MonsterSelfContrl> ().GetAttack (Mathf.FloorToInt(GameContrl.CurrentChoosedSkillAttribute.AttackNum*(1 + (GameContrl.DuwuLevel-1)*GameContrl.CurrentChoosedSkillAttribute.AttackNumUpgrade)));
				other.gameObject.GetComponent<MonsterSelfContrl> ().Vertigo (3*(1+(GameContrl.DuwuLevel - 1)*1),GameContrl.CurrentChoosedSkillAttribute.SlowDown + (GameContrl.DuwuLevel-1)*GameContrl.CurrentChoosedSkillAttribute.SlowDownUpgrade);
			}
		}
	}
}
