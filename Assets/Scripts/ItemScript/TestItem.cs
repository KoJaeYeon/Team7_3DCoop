using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestItem : MonoBehaviour,IHitAble
{
    private WeaponType weaponType;
    private GameObject BoxParticle;

    public TMP_Text BoxHpText;
    public TMP_Text BoxWeaponText;
    public TMP_Text BoxPowerUpText;
    public TMP_Text BoxAddPlayerText;

    private int BoxHp;
    public float BoxSpeed;
    private bool isMove;
    private bool isWeapon = false;
    private bool isPowerUp = false;


    private void OnEnable()
    {
        InitBox();
    }
    private void Awake()
    {
        InitBox();
    }

    private void InitBox()
    {
        isMove = true;
        StartCoroutine(ReturnTimer());

        BoxWeaponText.gameObject.SetActive(false);
        BoxPowerUpText.gameObject.SetActive(false);
        BoxAddPlayerText.gameObject.SetActive(false);
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

            ItemText();
            //if (isWeapon)
            //{
            //    //아이템 변경
            //    WeaponManager.Instance.SetWeapon(weaponType);
            //    isWeapon = false;
            //}
            //else if (isPowerUp)
            //{
            //    //파워업 처리
            //    WeaponManager.Instance.PowerUP();
            //    isPowerUp = false;
            //}
            //else
            //{
            //    //플레이어 증가
            //    PlayerManager.Instance.PlayerPlus();
            //}


            Explosion();
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

    private void Explosion()
    {
        BoxParticle = PoolManager.Instance.GetPartivle();
        BoxParticle.transform.position = transform.position;
    }

    private void ItemText()
    {
        BoxHpText.gameObject.SetActive(false);

        if (isWeapon)
        {
            BoxWeaponText.gameObject.SetActive(true);
        }
        else if (isPowerUp)
        {
            BoxPowerUpText.gameObject.SetActive(true);
        }
        else
        {
            BoxAddPlayerText.gameObject.SetActive(true);
        }
    }

    //private IEnumerator WeaponText()
    //{

    //}

    //private IEnumerator PowerUpText()
    //{

    //}

    //private IEnumerator AddPlayerText()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explosion();
            ReturnBox();
        }
    }
}
