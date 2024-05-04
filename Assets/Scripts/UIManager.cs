using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : Singleton<UIManager>
{
    
    public GameObject setting;
    public GameObject Sound;
    public GameObject Music;
    public GameObject SrStart;
    public GameObject Weapon;
    public Image canvasImage; // ĵ������ �̹��� ���
    public Sprite[] spriteArray; // �̹��� ������ ���� ��������Ʈ �迭
    private int currentSpriteIndex = 0; // ���� ��������Ʈ �ε���
    Slider slider1;
    Slider slider2;


    private void Awake()
    {
        slider1 =GameObject.Find("Sound").GetComponent<Slider>();
        slider2 = GameObject.Find("Music").GetComponent<Slider>();
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
        Time.timeScale = 0f;
    }

    //�ٽý��۹�ư
    public void ReTurnButton()
    {
        SceneManager.LoadScene("MainGame");
        SrStart.SetActive(false);
        Time.timeScale = 1f;
    }

    //�����̵� ��ư
    public void MainButton()
    {
       SceneManager.LoadScene("Main");

    }

    //���ư��� ��ư
    public void BkButton()
    {
        setting.SetActive(false);
        Time.timeScale = 1f;
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
        Weapon.active = true;
        int spriteIndex = (int)weaponType; // ���� ������ �ش��ϴ� ��������Ʈ �ε��� ���
        canvasImage.sprite = spriteArray[currentSpriteIndex]; // ���� ��������Ʈ�� �̹���


    }

}
