using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


namespace Game.View
{
 

/// <summary>
/// Base window几类
/// </summary>
public class BaseWindow
{
 protected Transform _transform;
 protected string resName; // 资源名称

 protected bool resident; // 是否常驻

 protected bool visible = false; // 是否可见

 protected WindowType _selfType; // 窗体类型

 protected SceneType _sceneType; // 场景类型

 // 控件按钮

 protected Button[] buttonList; // 按钮列表

 /*
  * 初始化
  */
 protected virtual void Awake()
 {
  // 隐藏物体也能查找到
  buttonList = _transform.GetComponentsInChildren<Button>(true);
  RegisterUIEvent();
 }

 /*
  * UI事件的注册
  */
 protected virtual void RegisterUIEvent()
 {
  
 }

 /*
  * 添加监听游戏事件
  */
 protected virtual void OnAddListener()
 {
  
 }

 /*
  * 移除监听游戏事件
  */
 protected virtual void OnRemoveListener()
 {
  
 }

 /*
  * 每次打开
  */
 protected virtual void OnEnable()
 {
  
 }

 /*
  * 每次关闭
  */
 protected virtual void OnDisable()
 {
  
 }


/*
 * 每帧更新
 */
    protected virtual void Update(float deltaTime)
    {
     
    }
    
 // ----------------Window Manager----------
 public void Open()
 {
  if (_transform == null)
  {
   if (Create())
   {
    Awake();
   }
  }

  if (_transform.gameObject.activeSelf == false)
  {
   UIRoot.SetParent(_transform, true, _selfType == WindowType.TipWindow);
   _transform.gameObject.SetActive(true);
   visible = true;
   OnEnable();
   OnAddListener();
  }
 }

 public void Close(bool isDestory=false)
 {
  if (_transform.gameObject.activeSelf)
  {
   OnRemoveListener();
   OnDisable();
   if (!isDestory)
   {
    if (resident)
    {
     _transform.gameObject.SetActive(false);
    }
    else
    {
     GameObject.Destroy(_transform.gameObject);
     _transform = null;
    }
   }
   else
   {
    GameObject.Destroy(_transform.gameObject);
    _transform = null;
   }

  

   visible = false;
  }
 }

 public void Preload()
 {
  if (_transform == null)
  {
   if (Create())
   {
    Awake();
   }
  }
 }

 public SceneType GetSceneType()
 {
  return _sceneType;
 }

 public WindowType GetWindowType()
 {
  return _selfType;
 }

 /// <summary>
 /// 是否可见
 /// </summary>
 /// <returns></returns>
 public Transform GetRoot()
 {
  return _transform;
 }

 public bool IsVisible()
 {
  return visible;
 }

 public bool IsResident()
 {
  return resident;
 }

 // ----------------内部---------------
 private bool Create()
 {
  if (string.IsNullOrEmpty(resName))
  {
   return false;
  }

  if (_transform == null)
  {
   var obj = Resources.Load<GameObject>(resName);
   if (obj == null)
   {
    Debug.Log($"未找到UI Prefab{_selfType}");
   }

   _transform = GameObject.Instantiate(obj).transform;
   _transform.gameObject.SetActive(false);
   
   UIRoot.SetParent(_transform, false, _selfType == WindowType.TipWindow);
  }
  return true;
 }
}
}

/// <summary>
/// UI类型
/// </summary>
public enum WindowType
{
    LoginWindow,
    StoreWindow,
    TipWindow,
}

/// <summary>
/// 场景类型, 根据场景类型进行提前加载
/// </summary>
public enum SceneType
{
    None,
    Login,
    Battle,
}
