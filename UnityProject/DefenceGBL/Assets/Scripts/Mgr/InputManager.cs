using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    //
    #region Singleton class
    private static InputManager m_instance = null;
    private static object m_objLock = new object();
    public static InputManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_objLock)
                {
                    if (m_instance == null)
                    {
                        m_instance = new InputManager();
                    }
                }
            }
           return m_instance;
        }
    }
    #endregion
    //
    private InputManager()
    {

    }
    //
    public float m_dwVer;
    public float m_dwHor;

    float GetVer()
    {
        m_dwHor = Input.GetAxisRaw("Vertical");
        return m_dwHor;
    }

    float GetHor()
    {
        m_dwHor = Input.GetAxisRaw("Horizontal");
        return m_dwHor;
    }

    float m_dw5thAxis;
    float GetAxis5th()
    {
        m_dw5thAxis = Input.GetAxis("5th axis");
        return m_dw5thAxis;
    }

    public bool IsClickLeft5th()
    {
        if (GetAxis5th() < -0.6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsClickRight5th()
    {
        if (GetAxis5th() > 0.6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsClickButtonA()
    {
        if (GetHor() < -0.6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsClickButtonS()
    {
        if (GetVer() < -0.6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsClickButtonD()
    {
        if (GetHor() > 0.6f)
        { 
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsClickButtonW()
    {
        
        if (GetVer() > 0.6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 是否点击确定键
    /// </summary>
    public bool IsClickOkButton()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 是否点击返回键
    /// </summary>
    public bool IsClickBack()
    {
        if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 是否点击第二确定键X
    /// </summary>
    public bool IsClickOkXButton()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Q))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}