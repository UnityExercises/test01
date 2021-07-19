using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary> 猫类 </summary>
class CatClass
{
    private void OnShout()
    {
        Debug.Log("喵……");
        EventTrigger.ExecuteCalls(EventDefine.CatShout,"我来了");
    } 
}

/// <summary> 老鼠1类 </summary>
public class Mouse1Class
{
    public Mouse1Class()
    {
        EventTrigger.RegisterCalls(EventDefine.CatShout, RunCallBack);
    }

    ~Mouse1Class()
    {
        EventTrigger.UnRegisterCalls(EventDefine.CatShout, this.RunCallBack);
    }

    private void RunCallBack(params object[] args)
    {
        Debug.Log("猫来了……快跑！");
    }
}

/// <summary> 老鼠2类 </summary>
class Mouse2Class
{
    public Mouse2Class()
    {
        EventTrigger.RegisterCalls(EventDefine.CatShout, RunCallBack);
    }

    ~Mouse2Class()
    {
        EventTrigger.UnRegisterCalls(EventDefine.CatShout, this.RunCallBack);
    }

    private void RunCallBack(params object[] args)
    {
        Debug.Log("猫来了……快跑！");
    }
}


