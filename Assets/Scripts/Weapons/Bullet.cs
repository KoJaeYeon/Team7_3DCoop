using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float attackDamage = 1f;
    private int piercing = 1;
    private float radius = 0f;
    private bool explodeActive = false;
    public void InitBullet()
    {
        attackDamage = 1f;
        piercing = 1;
        radius = 0f;
        explodeActive = false;
    }

    public void SetBullet(float attackDamage, int piercing, float radus, bool explodeActive)
    {
        this.attackDamage = attackDamage * WeaponManager.Instance.damageMultiplier;
        this.piercing = piercing;
        this.radius = radus;
        this.explodeActive = explodeActive;
    }
    private void OnTriggerEnter(Collider other)
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
                    gameObject.SetActive(false);
                }
            }
            else // 폭발형
            {
                Collider[] bombColliders = Physics.OverlapSphere(other.transform.position, radius, LayerMask.GetMask("EnemyTarget"));
                for (int i = 0; i < bombColliders.Length; i++)
                {
                    hitAble = bombColliders[i].GetComponent<IHitAble>();
                    hitAble.Damaged(attackDamage);
                }
                piercing--;
                if (piercing == 0)
                {
                    gameObject.SetActive(false);
                }
            }

        }
        else
        {
            if(other.CompareTag("DeadZone"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
