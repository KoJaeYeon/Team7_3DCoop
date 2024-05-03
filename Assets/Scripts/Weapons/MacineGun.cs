using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacineGun : Weapon,IWeapon
{
    private void Awake()
    {
        rapidSpeed = 0.5f;
        bulletSpeed = 2f;
        attackDamage = 2f;
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
