using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class UIManager : Singleton<UIManager>
{
    [Header("Gameobject")]
    public GameObject setting;
    public GameObject Sound;
    public GameObject restart;
    public GameObject defeat;
    public Animator potionAin;

    [Header("Weaponimage")]
    private int weapon;
    public Image canvasImage;
    public Sprite[] spriteArray;

    [Header("Sound")]
    public Slider soundSlider;
    public Sprite volumeOnImage;
    public Sprite volumeOffImage;
    private float volumeSize;
    

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

    private void OnEnable()
    {
        soundSlider.onValueChanged.AddListener(OnVolumeChanged);
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
        restart.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGame");
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

    public void SoundMuteButton()
    {
        if(Sound.GetComponent<Image>().sprite == volumeOnImage)
        {
            Sound.GetComponent<Image>().sprite = volumeOffImage;
            soundSlider.value = 0;
        }
    }

    public void Defeat()
    {
        defeat.SetActive(true);
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

    void OnVolumeChanged(float volume)
    {
        if(volume > 0)
        {
            Sound.GetComponent<Image>().sprite = volumeOnImage;
        }

        SoundManager.Instance.GetBgm().volume = volume;
    }
}
