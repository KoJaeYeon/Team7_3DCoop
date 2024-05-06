using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using Unity.Profiling.Editor;


public class UIManager : Singleton<UIManager>
{


    [Header("Gameobject")]
    public GameObject setting;
    public GameObject Sound;
    public GameObject Music;
    public GameObject restart;
    public Animator potionAin;

    [Header("Weaponimage")]
    private int weapon;
    public Image canvasImage;
    public Sprite[] spriteArray;

    [Header("Slider")]
    Slider slider1;
    Slider slider2;

    [Header("Text")]
    public TMP_Text timetext;
    public TMP_Text scoretext;
    public TMP_Text poweruptext;
    

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

        weapon = 0;

        StartCoroutine(TimeCount(time));

        Debug.Log("start : " + weapon);

        setting.SetActive(false);

        potionAin.enabled = false;

    }

    
    public void SetWeapon(WeaponType weapontype)
    {
        canvasImage.sprite = spriteArray[(int)weapontype]; // ���� ��������Ʈ�� �̹��� ����
    }


    //���۹�ư
    public void StartButton()
    {
        SceneManager.LoadScene("MainGame");
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
        SceneManager.LoadScene("MainGame");
        restart.SetActive(false);
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

    public void PworeUpUi(int Pcount)
    {

        poweruptext.text = Pcount.ToString();
        potionAin.enabled = true;

        Invoke("Power", 0.6f);

    }

    public void Power()
    {
        potionAin.enabled = false;
    }


}
