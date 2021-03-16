using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestMono.Instance.Test();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("02");
        }
    }
}
