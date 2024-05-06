using UnityEngine;

public enum WeaponType 
{ 
    Revolver,
    MachineGun,
    RocketLauncher,
    SMG,
    Rifle,
    Bow,
    ThrowingStars
}
public class MyWeapon : MonoBehaviour
{
    private IWeapon weapon;
    private WeaponType weaponType;
    public GameObject[] weaponPrefabs;
    private void Start()
    {
        InitWeapon();
    }
    private void OnEnable()
    {
        InitWeapon();
    }

    public void InitWeapon()
    {
        SetWeapon(WeaponManager.Instance.weaponType);
    }

    public void SetWeapon(WeaponType weaponType)
    {
        //Debug.Log($"SetWeapon : {weaponType}");
        this.weaponType = weaponType;

        DeactiveAllWeapons();

        Component component = gameObject.GetComponent<IWeapon>() as Component;
        if (component != null) Destroy(component);       

        switch (weaponType)
        {
            case WeaponType.Revolver:
                weapon = gameObject.AddComponent<Revolver>();                
                break;
            case WeaponType.MachineGun:
                weapon = gameObject.AddComponent<MachineGun>();
                break;
            case WeaponType.RocketLauncher:
                weapon = gameObject.AddComponent<RocketLauncher>();
                break;
            case WeaponType.SMG:
                weapon = gameObject.AddComponent<SMG>();
                break;
            case WeaponType.Rifle:
                weapon = gameObject.AddComponent<Rifle>();
                break;
            case WeaponType.Bow:
                weapon = gameObject.AddComponent<Bow>();
                break;
            case WeaponType.ThrowingStars:
                weapon = gameObject.AddComponent<ThrowingStar>();
                break;
        }
        
        GameObject weaponPrefab = weaponPrefabs[(int)weaponType];
        if(weaponPrefab != null)
        {
            weaponPrefab.SetActive(true);
        }
    }
    private void Update()
    {
        weapon.Fire();

        if(Input.GetKeyUp(KeyCode.F1))
        {
            SetWeapon(WeaponType.MachineGun);
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            SetWeapon(WeaponType.RocketLauncher);
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            SetWeapon(WeaponType.SMG);
        }
        else if (Input.GetKeyUp(KeyCode.F4))
        {
            SetWeapon(WeaponType.Rifle);
        }
        else if (Input.GetKeyUp(KeyCode.F5))
        {
            SetWeapon(WeaponType.Bow);
        }
        else if (Input.GetKeyUp(KeyCode.F6))
        {
            SetWeapon(WeaponType.ThrowingStars);
        }
        else if (Input.GetKeyUp(KeyCode.F7))
        {
            SetWeapon(WeaponType.Revolver);
        }

    }

    private void DeactiveAllWeapons()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
