using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour ,IHitAble
{
    public float EnemyHp;
    public float EnemySpeed;
    public float EnemyMaxSpeed;
    public float TargetDistance;

    //오리지널 플레이어 1명의 위치
    public Transform PlayerTransform;
    private Rigidbody EnemyRigidbody;
    private Animator EnemyAnimator;

    private Vector3 MovePos = Vector3.forward;
    



    private void Awake()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        EnemyAnimator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if(Vector3.Distance(PlayerTransform.position,transform.position) < TargetDistance)
        {
            Vector3 targetPos = PlayerTransform.position - transform.position;
            MovePos = targetPos;
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

  
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Bullet")
    //    {
    //        Damaged();
    //    }
    //}

    public void Damaged(float damage)
    {
        


    }

}
