using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{

    private float mouseX = 0;
    private float mouseY = 0;
    private float mouseZ = 0;

    Quaternion m_quInit;

    void Awake()
    {
        m_quInit = Camera.main.transform.rotation;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        Quaternion rot;
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            mouseX += Input.GetAxis("Mouse X") * 5;
            if (mouseX <= -180)
            {
                mouseX += 360;
            }
            else if (mouseX > 180)
            {
                mouseX -= 360;
            }
            mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
            mouseY = Mathf.Clamp(mouseY, -85, 85);
        }
        rot = Quaternion.Euler(-mouseY, mouseX, mouseZ);

        Camera.main.transform.rotation = rot * m_quInit;
#endif
    }
}
