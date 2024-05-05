using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;




public class UIManager : MonoBehaviour
{
    
    public GameObject setting;
    public GameObject Sound;
    public GameObject Music;
    public GameObject SrStart;

    public GameObject Weapon;
    public Image canvasImage; 
    public Sprite[] spriteArray; 
    private int ImageIndex = 0; 

    Slider slider1;
    Slider slider2;

    public TMP_Text timetext;
    public TMP_Text scoretext;

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

    }


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


    public void SetWeapon(WeaponType weaponType)
    {
        Debug.Log(weaponType);
        Weapon.SetActive(true);
        ImageIndex = (int)weaponType; // ���� ������ �ش��ϴ� ��������Ʈ �ε��� ���
        canvasImage.sprite = spriteArray[ImageIndex]; // ���� ��������Ʈ�� �̹���


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
