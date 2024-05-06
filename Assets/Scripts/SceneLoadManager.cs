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

    //���۹�ư
    public void StartButton()
    {
        SceneManager.LoadScene("MainGame");
    }
}
