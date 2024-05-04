using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStar : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.ThorwingStars);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
