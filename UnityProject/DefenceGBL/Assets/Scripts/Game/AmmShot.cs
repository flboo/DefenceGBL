using UnityEngine;
using System.Collections;
using System;
public class AmmShot : MonoBehaviour  
{  
	public const float g = 9.8f;  

	public GameObject target;  
	public float speed = 10;  
	private float verticalSpeed;  
	private Vector3 moveDirection;  

	void Start()  
	{  
		float tmepDistance = Vector3.Distance(transform.position, target.transform.position);  
		float tempTime = tmepDistance / speed;  
		float riseTime, downTime;  
		riseTime = downTime = tempTime / 2;  
		verticalSpeed = g * riseTime;  
		transform.LookAt(target.transform.position);  

		float tempTan = verticalSpeed / speed; 

		moveDirection = target.transform.position - transform.position;  
	}  
	private float time;  
	void Update()  
	{  
		if (transform.position.y < target.transform.position.y)  
		{  
			//finish  
			return;  
		}  
		time += Time.deltaTime;  
		float test = verticalSpeed - g * time;  
		transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);  
		transform.Translate(Vector3.up * test * Time.deltaTime,Space.World);   
	}  
}  
