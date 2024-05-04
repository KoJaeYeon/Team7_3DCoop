using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Collider[] colls;
    public Vector3 boxSize = new Vector3(2, 2, 2);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colls = Physics.OverlapBox(transform.position,boxSize * 0.5f,transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(Vector3.zero, boxSize);
    }
}

