using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void function_f(float a);
public delegate void function();


public class FunctionDelegate : MonoBehaviour
{
    public static FunctionDelegate Instance;
    public function Function;

    void Awake()
    {
        Instance = this;

    }

    void Update()
    {
        if (Function != null) 
            Function();
    }
}


public class ProcessFunction
{
    int i;
    float m_start;
    float m_end;
    float m_current;
    float m_speed;
    function m_funcEnd;
    function m_keep;
    function m_funcDur;
    function_f m_funcf;
    float m_delayTime;


    public ProcessFunction(function func)
    {
        m_keep = func;
        FunctionDelegate.Instance.Function += KeepUpdate; 
    }

    void KeepUpdate()
    {
        m_keep();
    }

    public void StopKeepUpdate()
    {
        FunctionDelegate.Instance.Function -= KeepUpdate;
    }

    public ProcessFunction(float delaytime, float start, float end, float time, function_f funcf, function funcEnd)
    {
        m_delayTime = delaytime;
        m_start = start;
        m_current = start;
        m_end = end;
        m_funcEnd = funcEnd;
        m_funcf = funcf;
        m_speed = (end - start) / time;
        FunctionDelegate.Instance.Function += AddUpdatef;
    }


    void AddUpdatef()
    {
        if (m_delayTime > 0)
        {
            m_delayTime -= Time.deltaTime;
        }
        else
        {
            m_delayTime = 0;
            m_current += m_speed * Time.deltaTime;
            if ((m_current - m_start) * (m_current - m_end) > 0)
            {
                m_current = m_end;
                m_funcf(m_current);
                FunctionDelegate.Instance.Function -= AddUpdatef;
                if (m_funcEnd != null)
                {
                    m_funcEnd();
                }
            }
            else
            {
                m_funcf(m_current);
            }
        }
    }


    public void StopUpdatef()
    {
        FunctionDelegate.Instance.Function -= AddUpdatef;
    }


}




