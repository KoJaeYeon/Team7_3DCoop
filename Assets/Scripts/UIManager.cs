using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public GameObject setting;
    public GameObject Sound;
    public GameObject Music;
    public GameObject SrStart;
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

}
