using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet_Arrow : Bullet
{
    public override void OnTriggerEnter(Collider other)
    {
        IHitAble hitAble = other.GetComponent<IHitAble>();
        if (hitAble != null)
        {
            if (!explodeActive) // 일반형
            {
                hitAble.Damaged(attackDamage);
                piercing--;
                if (piercing == 0)
                {
                    transform.parent.gameObject.SetActive(false);
                }
            }
            else // 폭발형
            {
                Collider[] bombColliders = Physics.OverlapSphere(other.transform.position, radius, LayerMask.GetMask("EnemyTarget"));
                foreach (Collider bomb in bombColliders)
                {
                    Debug.Log(bomb.name);
                }
                for (int i = 0; i < bombColliders.Length; i++)
                {
                    hitAble = bombColliders[i].GetComponent<IHitAble>();
                    hitAble.Damaged(attackDamage);
                }
                piercing--;
                if (piercing == 0)
                {
                    transform.parent.gameObject.SetActive(false);
                }
            }

        }
        else
        {
            if(other.CompareTag("DeadZone"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
