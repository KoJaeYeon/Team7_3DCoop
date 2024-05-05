using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    
    public int playerCount = 1;
    public int playerCountMax = 5;

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

            Debug.Log($"{playerCount}, {playerPrefabs[playerCount - 1].name}");
        }

        else
        {
            WeaponManager.Instance.PowerUP();
        }
    }

    private void PlayerMinus()
    {

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
    }
}
