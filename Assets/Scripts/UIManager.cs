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


    //무기 이미지 업데이트
    //public void SetWeapon()
    //{
    //    Debug.Log("무기이미지");
    //    weapon = (weapon + 1) % spriteArray.Length; // 다음 스프라이트 인덱스 계산
    //    canvasImage.sprite = spriteArray[weapon]; // 현재 스프라이트로 이미지 변경
    //}



    //시작버튼
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //세팅버튼
    public void SettingButton()
    {
        setting.SetActive(true);
        Time.timeScale = 0;
    }

    //다시시작버튼
    public void ReTurnButton()
    {
        SceneManager.LoadScene("SampleScene");
        SrStart.SetActive(false);
        Time.timeScale = 1;

    }

    //메인이동 버튼
    public void MainButton()
    {
       SceneManager.LoadScene("Main");
        Time.timeScale = 1;

    }

    //돌아가기 버튼
    public void BkButton()
    {
        setting.SetActive(false);
        Time.timeScale = 1;
    }

    //소리 버튼
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

    //음악버튼
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
            time += Time.deltaTime;//경과 시간 누적

            //걍과 시간 시, 분, 초로 변환하여 UI표시
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
