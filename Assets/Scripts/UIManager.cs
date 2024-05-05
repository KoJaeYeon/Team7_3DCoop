using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("Gameobject")]
    public GameObject setting;
    public GameObject Sound;
    public GameObject Music;
    public GameObject SrStart;

    [Header("Weaponimage")]
    private WeaponType weapon;
    public Image canvasImage;
    public Sprite[] spriteArray;

    [Header("Slider")]
    Slider slider1;
    Slider slider2;

    [Header("Text")]
    public TMP_Text timetext;
    public TMP_Text scoretext;

    [Header("Time")]
    private float time = 0;
    private int hour;
    private int minute;
    private int second;
    private bool isTime = false;



    private void Awake()
    {
        time = 0;

        isTime = true;

        StartCoroutine(TimeCount(time));

        SetWeapon(WeaponManager.Instance.weaponType);

        setting.SetActive(false);

    }

    public void SetWeapon(WeaponType weaponType)
    {
        Debug.Log($"JiheWeapon : {weaponType}");
        weapon = weaponType;


        switch (weaponType)
        {
            case WeaponType.Revolver:
                canvasImage.sprite = spriteArray[0];

                break;
            case WeaponType.MachineGun:
                canvasImage.sprite = spriteArray[1];
                break;
            case WeaponType.RocketLauncher:
                canvasImage.sprite = spriteArray[2];
                break;
            case WeaponType.SMG:
                canvasImage.sprite = spriteArray[3];
                break;
            case WeaponType.Rifle:
                canvasImage.sprite = spriteArray[4];
                break;
            case WeaponType.Bow:
                canvasImage.sprite = spriteArray[5];
                break;
            case WeaponType.ThrowingStars:
                canvasImage.sprite = spriteArray[6];
                break;
        }

        
    }
    private void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.F1))
        {
            SetWeapon(WeaponType.MachineGun);
            Debug.Log("f1");
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            SetWeapon(WeaponType.RocketLauncher);
            Debug.Log("f2");
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            SetWeapon(WeaponType.SMG); Debug.Log("f3");
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


    //���� �̹��� ������Ʈ
    //public void SetWeapon()
    //{
    //    Debug.Log("�����̹���");
    //    weapon = (weapon + 1) % spriteArray.Length; // ���� ��������Ʈ �ε��� ���
    //    canvasImage.sprite = spriteArray[weapon]; // ���� ��������Ʈ�� �̹��� ����
    //}



    //���۹�ư
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //���ù�ư
    public void SettingButton()
    {
        setting.SetActive(true);
        Time.timeScale = 0;
    }

    //�ٽý��۹�ư
    public void ReTurnButton()
    {
        SceneManager.LoadScene("SampleScene");
        SrStart.SetActive(false);
        Time.timeScale = 1;

    }

    //�����̵� ��ư
    public void MainButton()
    {
       SceneManager.LoadScene("Main");
        Time.timeScale = 1;

    }

    //���ư��� ��ư
    public void BkButton()
    {
        setting.SetActive(false);
        Time.timeScale = 1;
    }

    //�Ҹ� ��ư
    public void SoundX()
    { 
       Sound.SetActive(true);
        slider1.value = 0;
    }
    public void SoundO()
    {
        Sound.SetActive(false);
        slider1.value = 1;
    }

    //���ǹ�ư
    public void MusicX()
    {
        Music.SetActive(true);
        slider2.value = 0;

    }
    public void MusicO()
    {
        Music.SetActive(false);
        slider2.value = 1;
    }

    

    IEnumerator TimeCount(float time)
    {

        while (isTime)
        {
            time += Time.deltaTime;//��� �ð� ����

            //���� �ð� ��, ��, �ʷ� ��ȯ�Ͽ� UIǥ��
            hour = (int)(time / 3600);
            minute = (int)(time % 3600 / 60);
            second = (int)(time % 60);
            timetext.text = "Time : " + hour.ToString("00") + " : " + minute.ToString("00") + " : " + second.ToString("00");
           

            yield return null;

        }


    }

    public void Score(int score)
    {

        scoretext.text = "Score : " + score;
    }


}
