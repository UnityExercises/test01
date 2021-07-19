using System.Collections.Generic;


public enum EventDefine
{
    None,
    CatShout = 1,                   //猫叫事件
}

/// <summary>
/// 通知者类
/// </summary>
public class EventTrigger
{
    /// <summary>
    /// 绑定函数
    /// </summary>
    /// <param name="args">可变参数传递</param>
    public delegate void OnCallBack(params object[] args);

    /// <summary> 回调列表 </summary>
    private static Dictionary<EventDefine, List<OnCallBack>> mCallsDic = new Dictionary<EventDefine, List<OnCallBack>>();
  
    /// <summary> 添加绑定回调 </summary>
    public static void RegisterCalls(EventDefine eventKey, OnCallBack callBack)
    {
        if ( null == callBack)
            return;

        if (!mCallsDic.ContainsKey(eventKey))
        {
            List<OnCallBack> tempList = new List<OnCallBack>();
            tempList.Add(callBack);
            mCallsDic.Add(eventKey, tempList);
        }
        else
        {
            if (!mCallsDic[eventKey].Contains(callBack))
            {
                mCallsDic[eventKey].Add(callBack);
            }
        }
    }
    
    /// <summary> 去除指定的绑定回调 </summary>
    public static void UnRegisterCalls(EventDefine eventKey,OnCallBack callBack)
    {
        if (null == callBack || !mCallsDic.ContainsKey(eventKey))
            return;

        if (mCallsDic[eventKey].Contains(callBack))
        {
            mCallsDic[eventKey].Remove(callBack);
        }
    }

    /// <summary> 执行绑定回调 </summary>
    public static void ExecuteCalls(EventDefine eventKey,params object[] args)
    {
        int iCount = mCallsDic.Count;
        if (iCount <= 0 || !mCallsDic.ContainsKey(eventKey))
        {
            return;
        }

        List<OnCallBack> CallList = mCallsDic[eventKey];
        for (int i = 0,listCount = CallList.Count; i < listCount; i++)
        {
            try
            {
                CallList[i](args);
            }
            catch(System.Exception ex)
            {
                UnityEngine.Debug.LogException(ex);
            }
        }
    }

    /// <summary> 清空绑定回调 </summary>
    public void ClearAllCalls()
    {
        mCallsDic.Clear();
    }
}
