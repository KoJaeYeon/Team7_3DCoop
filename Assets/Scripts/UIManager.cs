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
    public Image canvasImage; // 캔버스의 이미지 요소
    public Sprite[] spriteArray; // 이미지 변경을 위한 스프라이트 배열
    private int currentSpriteIndex = 0; // 현재 스프라이트 인덱스
    Slider slider1;
    Slider slider2;


    private void Awake()
    {
        slider1 =GameObject.Find("Sound").GetComponent<Slider>();
        slider2 = GameObject.Find("Music").GetComponent<Slider>();
    }

    //시작버튼
    public void StartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    //세팅버튼
    public void SettingButton()
    {
        setting.SetActive(true);
        Time.timeScale = 0f;
    }

    //다시시작버튼
    public void ReTurnButton()
    {
        SceneManager.LoadScene("MainGame");
        SrStart.SetActive(false);
        Time.timeScale = 1f;
    }

    //메인이동 버튼
    public void MainButton()
    {
       SceneManager.LoadScene("Main");

    }

    //돌아가기 버튼
    public void BkButton()
    {
        setting.SetActive(false);
        Time.timeScale = 1f;
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

    public void SetWeapon(WeaponType weaponType)
    {
        Weapon.active = true;
        int spriteIndex = (int)weaponType; // 무기 유형에 해당하는 스프라이트 인덱스 계산
        canvasImage.sprite = spriteArray[currentSpriteIndex]; // 현재 스프라이트로 이미지


    }

}
