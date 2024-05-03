using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour ,IHitAble
{
    public float EnemyHp;
    public float EnemySpeed;
    public float EnemyMaxSpeed;
    public float TargetDistance;
    public int EnemyAtk;

    private bool OnAttack = true;

    //�������� �÷��̾� 1���� ��ġ
    public Transform PlayerTransform;    
    private Rigidbody EnemyRigidbody;
    private Animator EnemyAnimator;

    private Vector3 MovePos = Vector3.forward;
    private Vector3 TargetPos;



    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        EnemyAnimator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if(Vector3.Distance(PlayerTransform.position,transform.position) < TargetDistance)
        {
            TargetPos = (PlayerTransform.position - transform.position).normalized;

            MovePos = TargetPos;

            float targetAngle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }


        EnemyMove();
    }


    private void EnemyMove()
    {
        float CurrentSpeed = EnemyRigidbody.velocity.magnitude;

        if (CurrentSpeed > EnemyMaxSpeed)
            EnemyRigidbody.velocity = EnemyRigidbody.velocity.normalized * EnemyMaxSpeed;

        Vector3 EnemyMove = MovePos * EnemySpeed;
        EnemyRigidbody.AddForce(EnemyMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack());
            OnAttack = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnAttack = false;
        }
    }

    private IEnumerator Attack()
    {
        while (OnAttack)
        {
            // ���� �ִϸ��̼� ����
            //����
            Debug.Log("���� ����");
            yield return new WaitForSeconds(2.0f);
            //���� �ִϸ��̼� �ߴ�

        }
        Debug.Log("���� �ߴ�");
        
    }




    public void Damaged(float damage)
    {
        


    }

}
