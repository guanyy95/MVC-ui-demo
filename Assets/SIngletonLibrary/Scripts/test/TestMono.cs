using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMono : MonoSingleton<TestMono>
{
    public TestMono()
    {
        
        // destoryOnLoad = true;
    }

    public void Test()
    {
        Debug.Log("MonoSingleton....");
    }

    void Start()
    {
        AddSceneChangeEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
