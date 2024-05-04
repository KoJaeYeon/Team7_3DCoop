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

    //시작버튼
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //세팅버튼
    public void SettingButton()
    {
        setting.SetActive(true);
    }

    //다시시작버튼
    public void ReTurnButton()
    {
        SceneManager.LoadScene("SampleScene");
        SrStart.SetActive(false);
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

}
