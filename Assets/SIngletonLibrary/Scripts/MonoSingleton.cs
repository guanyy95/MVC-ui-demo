using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (MonoSingletonObject.go == null)
            {
                MonoSingletonObject.go = new GameObject("MonoSingletonObject");
                DontDestroyOnLoad(MonoSingletonObject.go);
            }

            if (MonoSingletonObject.go != null && _instance == null)
            {
                _instance = MonoSingletonObject.go.AddComponent<T>();
            }
            return _instance;
        }
    }
    
    
    public static bool destoryOnLoad = false;

    /// <summary>
    /// 回收场景切换组件
    /// </summary>
    public void AddSceneChangeEvent()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        if (destoryOnLoad == true)
        {
            if (_instance != null)
            {
                DestroyImmediate(_instance);
                Debug.Log(_instance == null);
            }
        }
    }
}


// 缓存一个gameobject 对象
public class MonoSingletonObject
{
    public static GameObject go;
}