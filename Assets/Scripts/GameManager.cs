using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : Singleton<GameManager>
{
    private float timer = 0f;
    public static int score;
    private void Awake()
    {
    }
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if(timer > 60.0f)
        {
            timer = 0f;
        }
    }

    
}
