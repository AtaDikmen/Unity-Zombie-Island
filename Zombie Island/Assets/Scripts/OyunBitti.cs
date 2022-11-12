using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    public Text sure;

    void Start()
    {
        puan.text = "Scor:" + PlayerPrefs.GetInt("puan");
        sure.text = PlayerPrefs.GetString("sure");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void YenidenOyna()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
}
