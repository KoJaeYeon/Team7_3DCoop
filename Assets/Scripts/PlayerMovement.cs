using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 moveDir = new Vector3(horizontal, 0, 0).normalized;

        playerRigidbody.velocity = moveDir * moveSpeed;
    }
}
