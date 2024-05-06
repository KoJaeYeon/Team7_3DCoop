using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public Camera camera;

    //시작버튼
    public void StartButton()
    {
        Debug.Log("dsf");
        SceneLoadManager.Instance.StartButton();
    }
}
