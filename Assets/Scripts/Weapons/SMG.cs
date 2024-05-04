using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.SMG);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
