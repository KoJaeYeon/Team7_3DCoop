using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
 

    //���۹�ư
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //���ù�ư
    public void SettingButton()
    {
        setting.SetActive(true);
    }

    //�ٽý��۹�ư
    public void ReTurnButton()
    {
        SceneManager.LoadScene("SampleScene");
        SrStart.SetActive(false);
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


}
