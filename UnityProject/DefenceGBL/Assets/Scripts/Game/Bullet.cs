using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public BallisticType ballistictype;
	public TowerType towertype;
	public int AttackNum;
	public const float g = 9.8f;  
	public GameObject target;  
	public float speed = 16;
	public float LineSpeed = 8;
	private float verticalSpeed;  
	private Vector3 moveDirection;  
	private float time; 
	float tempDistance;
	float tempTime;
	float riseTime, downTime;
	float tempTan;
	float test;
	bool canAttack = true;
	Vector3 v3;
	private AudioSource m_audiosource;
	void Awake()
	{
		m_audiosource = GetComponent<AudioSource> ();
		canAttack = true;
	}
    GameObject m_objTemp = null;
	void Update()  
	{  
		if(target == null)
		{
			return;
		}
		this.transform.LookAt (target.transform);
		if (this.gameObject.CompareTag ("FireBall")) 
		{
			if (Vector3.Distance(transform.position,v3) <= 0.12f && canAttack)  
			{  
				if(target.layer == 9)
                    m_objTemp=Instantiate(GameContrl.GetInstance.g_EBlast,new Vector3(v3.x,v3.y-1f,v3.z),Quaternion.identity);
				else if(target.layer == 10)
                    m_objTemp=Instantiate(GameContrl.GetInstance.g_EBlast,new Vector3(v3.x,v3.y-0.2f,v3.z),Quaternion.identity);
                m_objTemp.transform.SetParent(UtilTools.Instance.m_Scenes);
                canAttack = false;
				Destroy (gameObject);
				return;  
			}
		}
		if(ballistictype == BallisticType.Parabola)
		{
			tempDistance = Vector3.Distance(transform.position, v3);  
			tempTime = tempDistance / speed;  
			verticalSpeed = g * riseTime;  
			transform.LookAt(v3);  
			tempTan = verticalSpeed / speed; 
			moveDirection = v3 - transform.position;
		
			time += Time.deltaTime;  
			test = verticalSpeed - g * time;  
			transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);  
			transform.Translate(Vector3.up * test * Time.deltaTime,Space.World);   
		}
		else if(ballistictype == BallisticType.StraghtLine)
		{
			transform.position = Vector3.Lerp (transform.position,v3,Time.deltaTime*LineSpeed);
		} 
	}
	/// <summary> 
	/// 设置目标
	/// </summary>
	/// <param name="obg">Obg.</param>
	public void SetTarget(GameObject obg,int anm)
	{
		AttackNum = anm;
		target = obg;
		if (this.gameObject.CompareTag ("FireBall"))
		{
			this.transform.parent = null;
			v3 = new Vector3 (target.transform.position.x, target.transform.position.y + 1f, target.transform.position.z);
		}
		else
			v3 = target.transform.position;	
		tempDistance = Vector3.Distance(transform.position, v3);  
		tempTime = (tempDistance / speed)*1.2f;  
		riseTime = downTime = tempTime / 2;  
	}

	void OnTriggerEnter(Collider other)
	{
		if (canAttack)  
		{
			if(this.gameObject.CompareTag ("FireBall"))
			{
				if(other.gameObject.layer == 9)
				{
					canAttack = false;
					if(m_audiosource.clip != null)
						m_audiosource.Play ();
                    m_objTemp = null;
                    m_objTemp =Instantiate(GameContrl.GetInstance.g_EBlast,new Vector3(v3.x,v3.y,v3.z),Quaternion.identity);
                    m_objTemp.transform.SetParent(UtilTools.Instance.m_Scenes);
					other.gameObject.GetComponent<MonsterSelfContrl> ().GetAttack (AttackNum);
					Destroy (gameObject); 
				}
			}
			else
			{
				canAttack = false;
				if (towertype == TowerType.FlameTower)
				{
					AudioContrl.GetInstance().PlayAudio("Bomb");
					target.GetComponent<MonsterSelfContrl> ().ShowBurningEffect ();
					target.GetComponent<MonsterSelfContrl> ().GetContinuedAttack (10,3);
				}
				else if (towertype == TowerType.IceTower) 
				{
					AudioContrl.GetInstance().PlayAudio("IceAttack");
					target.GetComponent<MonsterSelfContrl> ().Frozen (3);
					target.GetComponent<MonsterSelfContrl> ().Vertigo (3,0.7f);
                    m_objTemp=Instantiate(GameContrl.GetInstance.g_Ice, other.transform.position, Quaternion.identity);
                    m_objTemp.transform.SetParent(UtilTools.Instance.m_Scenes);
                }
				else if(towertype == TowerType.LightningTower)
				{
					AudioContrl.GetInstance().PlayAudio("LightningAttack");
					target.GetComponent<MonsterSelfContrl> ().ShowLightEffect ();
					target.GetComponent<MonsterSelfContrl> ().Vertigo (2,1);
					target.GetComponent<MonsterSelfContrl> ().GetContinuedAttack (10,2);
				}
				target.GetComponent<MonsterSelfContrl> ().GetAttack (AttackNum);
				Destroy (gameObject); 
			}
		}
	}


}
