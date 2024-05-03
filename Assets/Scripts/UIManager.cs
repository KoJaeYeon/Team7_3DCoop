using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public GameObject main;

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingButton()
    { 
        main.SetActive(true);
    }

    public void ReTurnButton()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void MainButton()
    {
       SceneManager.LoadScene("Main");

    }

    public void BkButton()
    {
        main.SetActive(false);
    }

}
