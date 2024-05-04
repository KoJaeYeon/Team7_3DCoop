using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour,IHitAble
{
    private WeaponType weaponType;
    public GameObject BoxParticle;
    private TMP_Text BoxHpText;

    private int BoxHp;
    public float BoxSpeed;
    private bool isMove;


    private void OnEnable()
    {
        isMove = true;
        BoxHp = (int)Random.Range(1, 10);
        BoxHpText.text = BoxHp.ToString();
        
    }

    private void Awake()
    {
        BoxHpText = transform.GetComponentInChildren<TMP_Text>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(isMove)
        {
            Vector3 Move = Vector3.back * BoxSpeed * Time.deltaTime;
            transform.Translate(Move);
        }
    }

    public void Damaged(float damage)
    {
        BoxHp -= (int)damage;

        BoxHpText.text = BoxHp.ToString();

        if(BoxHp <= 0)
        {
            WeaponManager.Instance.SetWeapon(DropWeapon());
            Instantiate(BoxParticle,transform.position, Quaternion.identity);               
            ReturnBox();
        }
    }

    public void ReturnBox()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //플레이어에게 피해를 입힌다.
            Instantiate(BoxParticle, transform.position, Quaternion.identity);
            ReturnBox();
        }

    }

    public WeaponType DropWeapon()
    {
        int RandomSelect = Random.Range(1, 7);

        switch(RandomSelect)
        {
            case 1:
                weaponType = WeaponType.Revolver;
                break;
            case 2:
                weaponType = WeaponType.MachineGun;
                break;
            case 3:
                weaponType = WeaponType.RocketLauncer;
                break;
            case 4:
                weaponType = WeaponType.SMG;
                break;
            case 5:
                weaponType = WeaponType.Rifle;
                break;
            case 6:
                weaponType = WeaponType.Bow;
                break;
            case 7:
                weaponType = WeaponType.ThorwingStars;
                break;
        }

        return weaponType;
    }
}
