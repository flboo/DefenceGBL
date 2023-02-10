using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraContrl : MonoBehaviour {

	private Transform g_Camera;
    float rotationSpeed = 15;

    void  Awake()
	{
		g_Camera = this.transform;
        
	}

	void Update()
	{
#if UNITY_EDITOR
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        g_Camera.RotateAround(Vector3.zero, Vector3.up, -rotation * Time.deltaTime);
#else
        float rotation = Input.GetAxis("X axis") * rotationSpeed;
        g_Camera.RotateAround(Vector3.zero, Vector3.up, -rotation * Time.deltaTime);
#endif
    }





}
