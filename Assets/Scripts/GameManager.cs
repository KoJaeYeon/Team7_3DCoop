using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : Singleton<GameManager>
{
    private float timerDuration = 10;
    private int gameLevel = 1;
    public static float score = 0;
    public static float scoreMultiplier = 1f;

  
    private void Awake()
    {
        InitGame();
    }
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
        SoundManager.Instance.PlayBGM();
        gameLevel = 1;
        scoreMultiplier = 1f;
        score = 0;

        Debug.Log($"InitData : {gameLevel}, {score}, {scoreMultiplier}");
    }

    private void UpdateGameProgressSpeed()
    {
        gameLevel += 1;
        scoreMultiplier += 0.1f;
        SpawnManager.Instance.UpdateLevel(gameLevel);
        UIManager.Instance.LevelUP();
        Debug.Log($"{gameLevel}, {scoreMultiplier}");
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }

    public void GameOver()
    {
        SoundManager.Instance.StopBGM();
        Time.timeScale = 0f;
        Debug.Log("��������");
        UIManager.Instance.Defeat();
    }

    public void ScoreUp()
    {
        score += gameLevel * scoreMultiplier;
        UIManager.Instance.Score((int)score);
    }
}
