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
    public float BoxSpeed;
    private bool isMove;
    private bool isWeapon = false;
    private bool isPowerUp = false;


    private void OnEnable()
    {
        isMove = true;

        BoxHpText.text = BoxHp.ToString();
        StartCoroutine(ReturnTimer());
    }

    public void SetBoxHp(int Hp)
    {
        BoxHp = Hp;
        #region 체력바 수정
        BoxHpText.text = BoxHp.ToString();
        #endregion
    }

    public void SetItem(bool isWeapon, bool isPowerUp, WeaponType weapon = WeaponType.Revolver)
    {
        this.isWeapon = isWeapon;
        this.isPowerUp = isPowerUp;
        this.weaponType = weapon;
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
            isMove = false;

            if (isWeapon)
            {
                //아이템 변경
                WeaponManager.Instance.SetWeapon(weaponType);
                isWeapon = false;
            }
            else if (isPowerUp)
            {
                //파워업 처리
                WeaponManager.Instance.PowerUP();
                isPowerUp = false;
            }
            else
            {
                //플레이어 증가
                PlayerManager.Instance.PlayerPlus();
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
            Instantiate(BoxParticle, transform.position, Quaternion.identity);
            ReturnBox();
        }

    }
}
