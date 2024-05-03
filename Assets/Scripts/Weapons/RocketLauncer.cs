using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncer : Weapon,IWeapon
{
    private void Awake()
    {
        rapidSpeed = 0.2f;
        bulletSpeed = 2.5f;
        attackDamage = 20f;
        radius = 2.5f;
        explodeActive = true;
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
