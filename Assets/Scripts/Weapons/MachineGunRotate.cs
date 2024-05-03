using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunRotate : MonoBehaviour
{
    public Transform barrelTrans;
    public float rotateSpeed;

    void Update()
    {
        barrelTrans.Rotate(new Vector3(0,0,rotateSpeed* Time.deltaTime));
    }
}
