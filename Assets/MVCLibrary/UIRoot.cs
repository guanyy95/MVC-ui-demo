using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class UIRoot
{
    public static Transform _transform;
    public static Transform recylePool; // 回收的窗体 隐藏
    public static Transform activeLayer; // 前台显示窗口
    public static Transform noticeLayer; // 提示类型窗口
    public static bool isInit = false;
    
    
    public static void Init()
    {
        if (_transform == null)
        {
            var obj = Resources.Load<GameObject>("UI/UIRoot");
            _transform = GameObject.Instantiate(obj).transform;
        }

        if (recylePool == null)
        {
            recylePool = _transform.Find("RecyclePool");
        }
        
        if (activeLayer == null)
        {
            activeLayer = _transform.Find("ActivateLayer");
        }
        
        if (noticeLayer == null)
        {
            noticeLayer = _transform.Find("NoticeLayer");
        }

        isInit = true;
    }

    public static void SetParent(Transform window, bool isOpen, bool isTipWindow=false)
    {
        if (isInit == false)
        {
            Init();
        }

        if (isOpen)
        {
            if (isTipWindow)
            {
                window.SetParent(noticeLayer, false);
            }
            else
            {
                window.SetParent(activeLayer, false);
            }
        }
        else
        {
            window.SetParent(recylePool, false);
        }
    }
}
