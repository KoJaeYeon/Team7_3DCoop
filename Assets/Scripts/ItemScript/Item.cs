using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour, IHitAble
{
    private WeaponType weaponType;
    private GameObject BoxParticle;
    private BoxCollider boxCollider;

    public TMP_Text BoxHpText;
    public TMP_Text BoxItemText;
    public Sprite[] ItemSprite;
    public Sprite[] WeaponSprite;
    private Image BoxImage;

    private int BoxHp;
    public float BoxSpeed;
    private bool isMove;
    private bool isWeapon = false;
    private bool isPowerUp = false;
    private bool isPlayer = false;


    private void OnEnable()
    {
        InitBox();
        StartCoroutine(ReturnTimer());
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        BoxImage = transform.GetComponentInChildren<Image>();
    }

    private void InitBox()
    {
        isMove = true;
        boxCollider.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
       
        //텍스트 활성화/비활성화
        BoxHpText.gameObject.SetActive(true);
        BoxItemText.gameObject.SetActive(false);
    }

    public void SetBoxHp(int Hp)
    {
        BoxHp = Hp;
        BoxHpText.text = BoxHp.ToString();
    }

    public void SetItem(bool isWeapon, bool isPowerUp, WeaponType weapon = WeaponType.Revolver)
    {
        this.isWeapon = isWeapon;
        this.isPowerUp = isPowerUp;
        this.weaponType = weapon;

        if (!isWeapon && !isPowerUp)
            isPlayer = true;

        SetImage(isWeapon, isPowerUp, isPlayer, weapon);
    }

    private void SetImage(bool isWeapon, bool isPowerUp, bool isPlayer, WeaponType weapon)
    {
        if (isWeapon)
        {
            for(int i = 0; i < WeaponSprite.Length; i++)
            {
                if (WeaponSprite[i].name == weapon.ToString())
                {
                    BoxImage.sprite = WeaponSprite[i];
                    return;
                }
            }
        }
        else if (isPowerUp)
        {
            BoxImage.sprite = ItemSprite[1];
        }
        else if(isPlayer)
        {
            BoxImage.sprite = ItemSprite[0];
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (isMove)
        {
            Vector3 Move = Vector3.back * BoxSpeed * Time.deltaTime;
            transform.Translate(Move);
        }
    }

    public void Damaged(float damage)
    {
        BoxHp -= (int)damage;

        BoxHpText.text = BoxHp.ToString();

        if (BoxHp <= 0)
        {
            isMove = false;
            BoxHpText.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);  
            boxCollider.enabled = false;

            if (isWeapon)
            {
                //아이템 변경
                WeaponManager.Instance.SetWeapon(weaponType);
            }
            else if (isPowerUp)
            {
                //파워업
                WeaponManager.Instance.PowerUP();
            }
            else if(isPlayer)
            {
                //플레이어 증가
                PlayerManager.Instance.PlayerPlus();
            }

            Explosion();
            StartCoroutine(ActiveText());
        }
    }

    private void Explosion() //폭발 파티클
    {
        BoxParticle = PoolManager.Instance.GetPartivle();
        BoxParticle.transform.position = transform.position;
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

    private IEnumerator ActiveText()
    {
        BoxItemText.gameObject.SetActive(true);

        if (isWeapon)
        {
            BoxItemText.text = "New Weapon";
            isWeapon = false;
        }
        else if (isPowerUp)
        {
            BoxItemText.text = "Power Up";
            isPowerUp = false;
        }
        else if(isPlayer)
        {
            BoxItemText.text = "Player++";
            isPlayer = false;
        }

        yield return new WaitForSeconds(1.5f);

        ReturnBox();
    }
}
