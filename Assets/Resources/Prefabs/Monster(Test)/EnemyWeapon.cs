using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    Enemy enemy;

    private void OnEnable()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    public int ReturnEnemyAtk()
    {
        return enemy.EnemyAtk;
    }

}
