using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public GameObject[] playerPrefabs;
    
    public static int playerCount = 1;
    public static int playerCountMax = 5;

    public Vector3[] positionOffset;

    private void Start()
    {
        InitPlayer();
    }

    private void OnEnable()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        playerCount = 1;
        playerCountMax = 5;

        DeactivePlayer();

        playerPrefabs[0].transform.position = transform.position + positionOffset[0];
        playerPrefabs[0].gameObject.SetActive(true);
    }

    public void PlayerPlus()
    {
        if(playerCount < playerCountMax)
        {
            playerCount++;

            Vector3 basePosition = playerPrefabs[0].transform.position;

            Vector3 newPosition = basePosition + positionOffset[playerCount - 1];

            playerPrefabs[playerCount - 1].transform.position = newPosition;
            playerPrefabs[playerCount - 1].gameObject.SetActive(true);

            Debug.Log($"���� �÷��̾��� �� : {playerCount}");
        }

        else
        {
            WeaponManager.Instance.PowerUP();

            Debug.Log("�Ŀ���!");
        }
    }

    public void PlayerMinus()
    {
        if(playerCount > 0)
        {
            playerCount--;

            playerPrefabs[playerCount].gameObject.SetActive(false);

            Debug.Log($"���� �÷��̾��� �� : {playerCount}");
        }

        if(playerCount == 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void DeactivePlayer()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPlus();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerMinus();
        }
    }

    public Vector3 GetPlayerPos()
    {
        return transform.GetChild(0).position;
    }
}
