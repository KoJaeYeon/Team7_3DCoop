using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float currentTime = 0f;
    private float timerDuration = 60f;
    private int gameLevel = 1;
    public static float score = 0;
    public static float scoreMultiplier = 1f;

  
    private void Awake()
    {
        InitGame();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerDuration);
            UpdateGameProgressSpeed();
        }
    }   
    
    private void InitGame()
    {
        gameLevel = 1;
        scoreMultiplier = 1f;
        score = 0;

        Debug.Log($"InitData : {gameLevel}, {score}, {scoreMultiplier}");
    }

    private void UpdateGameProgressSpeed()
    {
        gameLevel += 1;
        scoreMultiplier += 0.1f;

        Debug.Log($"{gameLevel}, {scoreMultiplier}");
    }
}
