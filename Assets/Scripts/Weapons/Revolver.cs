using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.Revolver);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
