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
    private TMP_Text BoxWeaponText;
    private TMP_Text BoxPowerUpText;
    private TMP_Text BoxAddPlayerText;

    private int BoxHp;
    private int PlayerCount;
    public float BoxSpeed;
    private bool isMove;
    private bool isWeapon = false;
    private bool isPowerUp = false;


    private void OnEnable()
    {
        isMove = true;

        BoxHp = Random.Range(1, 10);
        PlayerCount = Random.Range(1, 10);

        BoxHpText.text = BoxHp.ToString();
        StartCoroutine(ReturnTimer());
    }

    private void Awake()
    {
        BoxHpText = transform.GetComponentInChildren<TMP_Text>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetItem(bool isWeapon,bool isPowerUp, WeaponType weapon = WeaponType.Revolver)
    {
        this.isWeapon = isWeapon;
        this.isPowerUp = isPowerUp;
        this.weaponType = weapon;
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
            if (isWeapon)
            {
                WeaponManager.Instance.SetWeapon(weaponType);
                isWeapon = false;
            }
            else if (isPowerUp)
            {
                //파워업 처리
                isPowerUp = false;  
            }
            else
            {
                //플레이어 증가 처리
            }

            Instantiate(BoxParticle,transform.position, Quaternion.identity);
            ReturnBox();
        }
    }

    public void ReturnBox()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator ReturnTimer()
    {
        yield return new WaitForSeconds(20.0f);
        ReturnBox();
    }

    private void PowerUp()
    {

    }

    private void AddPlayer()
    {

    }


    //public WeaponType DropWeapon()
    //{
    //    int RandomSelect = Random.Range(1, 7);

    //    switch(RandomSelect)
    //    {
    //        case 1:
    //            weaponType = WeaponType.Revolver;
    //            break;
    //        case 2:
    //            weaponType = WeaponType.MachineGun;
    //            break;
    //        case 3:
    //            weaponType = WeaponType.RocketLauncher;
    //            break;
    //        case 4:
    //            weaponType = WeaponType.SMG;
    //            break;
    //        case 5:
    //            weaponType = WeaponType.Rifle;
    //            break;
    //        case 6:
    //            weaponType = WeaponType.Bow;
    //            break;
    //        case 7:
    //            weaponType = WeaponType.ThrowingStars;
    //            break;
    //    }

    //    return weaponType;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(BoxParticle, transform.position, Quaternion.identity);
            ReturnBox();
        }

    }
}
