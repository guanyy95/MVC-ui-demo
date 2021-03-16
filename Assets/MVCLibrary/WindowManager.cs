using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Game.View;
using UnityEngine;

public class WindowManager : MonoSingleton<WindowManager>
{
    private Dictionary<WindowType, BaseWindow> windowDic = new Dictionary<WindowType, BaseWindow>();
    
    // 构造函数
    public WindowManager()
    {
        windowDic.Add(WindowType.StoreWindow, new StoreWindow());
    }

    // 打开窗口
    public BaseWindow OpenWindow(WindowType type)
    {
        BaseWindow window;
        if (windowDic.TryGetValue(type, out window))
        {
            window.Open();
            return window;
        }
        else
        {
            Debug.LogError($"Open Error: {type}");
            return null;
        }
    }
    // 关闭窗口
    public void CloseWindow(WindowType type)
    {
        BaseWindow window;
        if (windowDic.TryGetValue(type, out window))
        {
            window.Close();
        }
        else
        {
            Debug.LogError($"Close Error : {type}");
        }
    }
    // 郁加载
    public void PreLoadWindow(SceneType type)
    {
        foreach (var item in windowDic.Values)
        {
            if (item.GetSceneType() == type)
            {
                item.Preload();
            }
        }
    }
    
    
    public void HideAllWindow(SceneType type, bool isDestory = false)
    {
        foreach (var item in windowDic.Values)
        {
            if (item.GetSceneType() == type)
            {
                if (!isDestory) 
                    item.Close();
                else
                {
                    item.Close();
                }
            }
        }
    }
}
