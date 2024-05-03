using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 moveDir = new Vector3(Horizontal, 0, 0);

        playerRigidbody.velocity = moveDir * moveSpeed;
    }
}
