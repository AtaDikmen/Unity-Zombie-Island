using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    public AudioClip butonSesi;
    private AudioSource aSource;
    public GameObject AnaMenuC, HowtoPlay, Keyboards, Object, Zombies, Weapons;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void KeyboardsEkrani()
    {
        HowtoPlay.SetActive(false);
        Object.SetActive(false);

        Keyboards.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }

    public void MainMenu()
    {
        HowtoPlay.SetActive(false);
        Keyboards.SetActive(false);
        Object.SetActive(false);
        Zombies.SetActive(false);
        Weapons.SetActive(false);

        AnaMenuC.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }

    public void HowToPlayEkrani()
    {
        AnaMenuC.SetActive(false);
        Keyboards.SetActive(false);

        HowtoPlay.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }

    public void ZombiesEkrani()
    {
        Object.SetActive(false);
        Weapons.SetActive(false);

        Zombies.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }

    public void GameObjectEkrani()
    {
        Keyboards.SetActive(false);
        Zombies.SetActive(false);

        Object.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }
    
    public void WeaponsEkrani()
    {
        Keyboards.SetActive(false);
        Zombies.SetActive(false);

        Weapons.SetActive(true);
        aSource.PlayOneShot(butonSesi, 1f);
    }
}
