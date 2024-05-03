using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon,IWeapon
{
    private void Awake()
    {
        rapidSpeed = 1f;
        bulletSpeed = 1f;
        attackDamage = 1f;
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    public override void Fire()
    {
        base.Fire();
    }
}
