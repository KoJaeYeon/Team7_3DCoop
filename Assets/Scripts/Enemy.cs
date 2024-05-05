using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitAble
{
    public float EnemyHp;
    public float EnemySpeed;
    public float EnemyMaxSpeed;
    public float TargetDistance;
    public int EnemyAtk;

    private bool isMove = true;

    public Transform PlayerTransform;    
    private Rigidbody EnemyRigidbody;
    private Animator EnemyAnimator;
    private CapsuleCollider EnemyCollider;

    private Vector3 MovePos;
    private Vector3 TargetPos;

    

    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        EnemyAnimator = GetComponent<Animator>();
        EnemyCollider = GetComponent<CapsuleCollider>();

        MovePos = transform.forward;
        EnemyAnimator.SetFloat("Run", 1f);

        
    }

    private void OnEnable()
    {
        isMove = true;
    }


    private void FixedUpdate()
    {
        Target();
        EnemyMove();
    }


    private void EnemyMove()
    {
        if (isMove)
        {
            float CurrentSpeed = EnemyRigidbody.velocity.magnitude;

            if (CurrentSpeed > EnemyMaxSpeed)
                EnemyRigidbody.velocity = EnemyRigidbody.velocity.normalized * EnemyMaxSpeed;

            Vector3 EnemyMove = MovePos * EnemySpeed;
            EnemyRigidbody.AddForce(EnemyMove);
        }
    }

    private void Target()
    {
        if (PlayerTransform == null)
            return;

        if (Vector3.Distance(PlayerTransform.position, transform.position) < TargetDistance)
        {
            TargetPos = (PlayerTransform.position - transform.position).normalized;

            float targetAngle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            MovePos = TargetPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnimator.SetBool("Attack", true);
            EnemyAnimator.SetFloat("Run", 0f);
        } 
       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyAnimator.SetBool("Attack", false);
            EnemyAnimator.SetFloat("Run", 1f);
        }
    }

    public void Damaged(float damage)
    {
        EnemyHp -= damage;

        if (EnemyHp <= 0)
        {
            isMove = false;
            StartCoroutine(Dead());
        }
    }

    private IEnumerator Dead()
    {
        EnemyAnimator.SetTrigger("Die");
        
        EnemyRigidbody.velocity = Vector3.zero;
        EnemyRigidbody.useGravity = false;
        EnemyCollider.enabled = false;

        yield return new WaitForSeconds(1.5f);

        ReturnEnemy();
    }

    public void ReturnEnemy()
    {
        gameObject.SetActive(false);
    }
  

}