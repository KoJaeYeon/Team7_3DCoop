using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadManager : Singleton<SceneLoadManager>
{
    private void Awake()
    {
        if(Instance != this) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
        }        
    }

    //시작버튼
    public void StartButton()
    {
        SceneManager.LoadScene("MainGame");
    }
}
